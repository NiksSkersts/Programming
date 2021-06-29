using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gala_darbs.Models
{
    public class SettingsView : INotifyPropertyChanged
    {
        private string save = Properties.Settings.Default.Save;
        private string add = Properties.Settings.Default.Add;
        private string curl = Properties.Settings.Default.Curl;
        private string fontName = Properties.Settings.Default.FontName;
        private string fontSize = Properties.Settings.Default.FontSize;
        private string rTB_Foreground = Properties.Settings.Default.RTB_Foreground;
        private string rTB_Background = Properties.Settings.Default.RTB_Background;
        private string openFile = Properties.Settings.Default.OpenFile;
        private string quit = Properties.Settings.Default.Quit;
        private string write = Properties.Settings.Default.Write;
        private string writeandQuit = Properties.Settings.Default.WriteandQuit;
        private System.Windows.Media.FontFamily def_fontfam = Properties.Settings.Default.Def_FontFam;
        private double def_fontsize = Properties.Settings.Default.Def_FontSize;

        public string WriteandQuit
        {
            get => writeandQuit;
            set
            {
                writeandQuit = value;
                Changed("WriteandQuit");
            }
        }

        public string Write
        {
            get => write;
            set
            {
                write = value;
                Changed("Write");
            }
        }

        public string Quit
        {
            get => quit;
            set
            {
                quit = value;
                Changed("Quit");
            }
        }

        public string OpenFile
        {
            get => openFile;
            set
            {
                openFile = value;
                Changed("OpenFile");
            }
        }

        public string RTB_Background
        {
            get => rTB_Background;
            set
            {
                rTB_Background = value;
                Changed("RTB_Background");
            }
        }

        public string RTB_Foreground
        {
            get => rTB_Foreground;
            set
            {
                rTB_Foreground = value;
                Changed("RTB_Foreground");
            }
        }

        public string FontSize
        {
            get => fontSize;
            set
            {
                fontSize = value;
                Changed("FontSize");
            }
        }

        public string FontName
        {
            get => fontName;
            set
            {
                fontName = value;
                Changed("FontName");
            }
        }

        public string Curl
        {
            get => curl;
            set
            {
                curl = value;
                Changed("Curl");
            }
        }

        public string Add
        {
            get => add;
            set
            {
                add = value;
                Changed("Add");
            }
        }

        public string Save
        {
            get => save;
            set
            {
                save = value;
                Changed("Save");
            }
        }

        public System.Windows.Media.FontFamily Def_FontFam
        {
            get => def_fontfam;
            set
            {
                def_fontfam = value;
                Changed("Def_FontFam");
            }
        }

        public double Def_FontSize
        {
            get => def_fontsize;
            set
            {
                def_fontsize = value;
                Changed("Def_FontSize");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetSettings()
        {
            Properties.Settings.Default.WriteandQuit = writeandQuit;
            Properties.Settings.Default.Write = write;
            Properties.Settings.Default.Quit = quit;
            Properties.Settings.Default.OpenFile = openFile;
            Properties.Settings.Default.RTB_Background = rTB_Background;
            Properties.Settings.Default.RTB_Foreground = rTB_Foreground;
            Properties.Settings.Default.FontSize = fontSize;
            Properties.Settings.Default.FontName = fontName;
            Properties.Settings.Default.Curl = curl;
            Properties.Settings.Default.Add = add;
            Properties.Settings.Default.Save = save;
            Properties.Settings.Default.Def_FontFam = def_fontfam;
            Properties.Settings.Default.Def_FontSize = def_fontsize;
        }

        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}