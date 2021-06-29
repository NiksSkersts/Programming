using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Notes
{
    public class Note : INotifyPropertyChanged
    {
        private string header;
        private string message;
        private Color color;
        private Point location;
        private int angle;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Header
        {
            get => header;
            set
            {
                header = value;
                Changed("Header");
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                Changed("Message");
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                Changed("Color");
            }
        }

        public Point Location
        {
            get => location;
            set
            {
                location = value;
                Changed("Location");
            }
        }

        public int Angle
        {
            get => angle;
            set
            {
                angle = value;
                Changed("Angle");
            }
        }

        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Note()
        {
            color = (Color) ColorConverter.ConvertFromString("#FFFF2821");
        }
    }
}