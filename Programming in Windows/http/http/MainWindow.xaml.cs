using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace http
{
    //https://saezndaree.wordpress.com/2009/03/29/how-to-redirect-the-consoles-output-to-a-textbox-in-c/
    public partial class MainWindow : Window
    {
        private string url;

        private string source;

        //console to textbox
        private TextWriter _writer = null;

        public MainWindow()
        {
            InitializeComponent();
            FormConsole_Load();
        }

        public void GetUrl()
        {
            url = http_url.Text;
        }

        public void GetWeb()
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(url);
                webRequest.Method = "GET";
                var webResponse = (HttpWebResponse) webRequest.GetResponse();
                var webSource = new StreamReader(webResponse.GetResponseStream());
                source = webSource.ReadToEnd();
                webResponse.Close();
                ParseHtml();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot open URL :(", "ERR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public void ParseHtml()
        {
            result.Text = "";
            if (bank.IsChecked == true)
                foreach (Match item in Regex.Matches(source, @"[A-Z]{2}\d{2}[A-Z]{4}\d{13}"))
                    Console.WriteLine(item.Value);
            if (phone.IsChecked == true)
                foreach (Match item in Regex.Matches(source, @"\b\d{8}\b"))
                    Console.WriteLine(item.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetUrl();
            GetWeb();
        }

        private void FormConsole_Load()
        {
            // Instantiate the writer
            _writer = new TextBoxStreamWriter(result);
            // Redirect the out Console stream
            Console.SetOut(_writer);
        }
    }

    //Get Console Writeline to output to textbox
    public class TextBoxStreamWriter : TextWriter
    {
        private TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}