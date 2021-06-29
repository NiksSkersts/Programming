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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace game_
{
    public partial class MainWindow : Window
    {
        private int orig_top_one = 41;
        private int orig_top_two = 607;
        private int orig_left_three = 533;
        private int orig_left_four = 117;
        private int left = 0;
        private int top = 0;
        private DispatcherTimer dt = new DispatcherTimer();

        private bool is_game_on = false;
        private bool second_loop = false;

        public MainWindow()
        {
            InitializeComponent();
            dt.Interval = TimeSpan.FromMilliseconds(10);
            dt.Tick += Dt_Tick;
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            double c_f_loc = Canvas.GetLeft(car_four);
            double c_t_loc = Canvas.GetLeft(car_three);
            double c_o_loc = Canvas.GetTop(car_one);
            double c_tw_loc = Canvas.GetTop(car_two);
            if (second_loop == false)
            {
                left++;
                Canvas.SetTop(car_one, orig_top_one);
                Canvas.SetTop(car_two, orig_top_two);
                Canvas.SetLeft(car_four, orig_left_four + left);
                Canvas.SetLeft(car_three, orig_left_three - left);
                if (c_f_loc > canva.Width && c_t_loc < 0)
                {
                    second_loop = true;
                    red_top.Fill = new SolidColorBrush(Colors.Red);
                    red_top_two.Fill = new SolidColorBrush(Colors.Black);
                    red_bott.Fill = new SolidColorBrush(Colors.Black);
                    red_bott_two.Fill = new SolidColorBrush(Colors.Green);
                }

                top = 0;
            }

            if (second_loop == true)
            {
                Canvas.SetLeft(car_four, orig_left_four);
                Canvas.SetLeft(car_three, orig_left_three);
                top++;
                Canvas.SetTop(car_one, orig_top_one + top);
                Canvas.SetTop(car_two, orig_top_two - top);
                if (c_o_loc > canva.Height && c_tw_loc < 0)
                {
                    second_loop = false;
                    red_top.Fill = new SolidColorBrush(Colors.Black);
                    red_top_two.Fill = new SolidColorBrush(Colors.Red);
                    red_bott.Fill = new SolidColorBrush(Colors.Green);
                    red_bott_two.Fill = new SolidColorBrush(Colors.Black);
                }

                left = 0;
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (is_game_on == false)
            {
                start.Content = "stop";
                dt.Start();
                is_game_on = true;
            }
            else
            {
                start.Content = "start";
                is_game_on = false;
                dt.Stop();
            }
        }
    }
}