using System.ComponentModel;

namespace Notes
{
    public class NewNoteViewModel : INotifyPropertyChanged
    {
        private Note note = new();

        public Note Note
        {
            get => note;
            set
            {
                note = value;
                Changed("Note");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}