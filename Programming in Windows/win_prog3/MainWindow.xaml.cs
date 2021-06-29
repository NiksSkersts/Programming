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

namespace win_prog3
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

        private void btn_sum(object sender, RoutedEventArgs e)
        {
            var shown = false;
            var sum_c = 0;
            string numbers_c = numbers.Text;
            for (var i = 0; i < numbers_c.Length; i++)
            {
                if (char.IsDigit(numbers_c[i])) sum_c += numbers_c[i] - '0';
                ;
                if (char.IsLetter(numbers_c[i]))
                {
                    if (shown == false)
                    {
                        sum.Text = Convert.ToString("ERROR!");
                        if (MessageBox.Show("remove all letters?", "oopsy", MessageBoxButton.YesNo) ==
                            MessageBoxResult.Yes) sum.Text = Convert.ToString(sum_c);
                    }

                    shown = true;
                }
            }

            sum.Text = Convert.ToString(sum_c);
        }
    }
}