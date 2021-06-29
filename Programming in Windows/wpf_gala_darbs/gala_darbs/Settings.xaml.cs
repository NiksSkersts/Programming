using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using gala_darbs.Models;

namespace gala_darbs
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingsView settingsView = new SettingsView();

        public Settings()
        {
            InitializeComponent();
            this.DataContext = settingsView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            settingsView.SetSettings();
            Properties.Settings.Default.Save();
            this.DialogResult = true;
            this.Close();
        }
    }
}