using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace w_prog_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            number_one.Text += b.Content.ToString();
        }

        private void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception exc)
            {
                number_two.Text = "Error!";
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            number_one.Text = "";
        }

        private void Off_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void result()
        {
            string op;
            var iOp = 0;
            if (number_one.Text.Contains("+"))
            {
                iOp = number_one.Text.IndexOf("+");
            }
            else if (number_one.Text.Contains("-"))
            {
                iOp = number_one.Text.IndexOf("-");
            }
            else if (number_one.Text.Contains("*"))
            {
                iOp = number_one.Text.IndexOf("*");
            }
            else if (number_one.Text.Contains("/"))
            {
                iOp = number_one.Text.IndexOf("/");
            }
            else
            {
                //error    
            }

            op = number_one.Text.Substring(iOp, 1);
            var op1 = Convert.ToDouble(number_one.Text.Substring(0, iOp));
            var op2 = Convert.ToDouble(number_one.Text.Substring(iOp + 1, number_two.Text.Length - iOp - 1));

            if (op == "+")
                result_2.Text += "=" + (op1 + op2);
            else if (op == "-")
                result_2.Text += "=" + (op1 - op2);
            else if (op == "*")
                result_2.Text += "=" + op1 * op2;
            else
                result_2.Text += "=" + op1 / op2;
        }
    }
}