using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace gala_darbs
{
    [Serializable]
    public class Text : INotifyPropertyChanged
    {
        private string header;
        private string content;
        private double fontsize;
        private FontFamily fontname;

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

        public string Content
        {
            get => content;
            set
            {
                content = value;
                Changed("Content");
            }
        }

        public double FontSize
        {
            get => fontsize;
            set
            {
                fontsize = value;
                Changed("FontSize");
            }
        }

        public FontFamily FontName
        {
            get => fontname;
            set
            {
                fontname = value;
                Changed("FontName");
            }
        }

        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}