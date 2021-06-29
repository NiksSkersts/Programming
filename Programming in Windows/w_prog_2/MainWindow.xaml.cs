using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
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

namespace w_prog_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool game_done = false;
        private Random rnd = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void oops(object sender, RoutedEventArgs e)
        {
            game_done = true;
            btn.Background = Brushes.Green;
            MessageBox.Show("oof");
        }

        private void move_mouse(object sender, RoutedEventArgs e)
        {
            if (game_done == true) return;
            btn.Margin = new Thickness(rnd.Next(0, (int) window.Width), rnd.Next((int) window.Height), 0, 0);
        }
    }
}