using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using System;
using System.Runtime.InteropServices;

namespace win_prog_notepad
{
    public partial class MainWindow : Window
    {
        public string file_name = "";
        private int init_numb = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void box_100(object sender, TextChangedEventArgs e)
        {
            char_text.Text = "chars: " +
                             new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd).Text.Length;
            word_wrap();
        }

        private void word_wrap()
        {
            int total = new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd).Text.Length;
            for (var i = 0; i < total; i++)
                if (i > init_numb)
                    init_numb = i;
            if (!wordwrap.IsChecked)
                textbox.Document.PageWidth = init_numb * textbox.FontSize;
            else
                textbox.Document.PageWidth = textbox.ActualWidth;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (file_name != "")
                File.WriteAllText(file_name,
                    new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd).Text);
            else
                save_as();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            file_name = "";
            textbox.Document.Blocks.Clear();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            save_as();
        }

        private void save_as()
        {
            //https://www.wpf-tutorial.com/dialogs/the-savefiledialog/
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.DefaultExt = "txt";
            save.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            if (save.ShowDialog() == true)
                File.WriteAllText(save.FileName,
                    new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd).Text);
            file_name = save.FileName;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            textbox.Document.Blocks.Clear();
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            if (open.ShowDialog() == true)
            {
                file_name = open.FileName;
                textbox.AppendText(File.ReadAllText(file_name));
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            //http://csharp.net-informations.com/gui/cs-font-dialog-box.htm
            //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.fontdialog.color?view=netcore-3.1
            FontDialog font = new FontDialog();
            FontFamilyConverter conv = new FontFamilyConverter();
            font.ShowDialog();
            textbox.FontSize = (double) font.Font.Size;
            textbox.FontFamily = (System.Windows.Media.FontFamily) conv.ConvertFromString(font.Font.Name);
            if (font.Font.Bold)
                textbox.FontWeight = FontWeights.Bold;
            else
                textbox.FontWeight = FontWeights.Normal;
            if (font.Font.Italic)
                textbox.FontStyle = FontStyles.Italic;
            else
                textbox.FontStyle = FontStyles.Normal;
        }
    }
}