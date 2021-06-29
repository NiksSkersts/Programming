using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes
{
    public class NotesViewModel
    {
        public NotesViewModel()
        {
            for (var i = 0; i < 10; i++) AddNote("TEST", "Some Text");
        }

        private Random NumberGenerator = new();
        public ObservableCollection<Note> Notes { get; set; } = new();

        public void AddNote(string message, string header)
        {
            Notes.Add(new Note()
            {
                Header = header,
                Message = message,
                Angle = 5 - NumberGenerator.Next(11),
                Location = CreateNotOverlapPoint()
            });
        }

        public void AddNote(Note note)
        {
            note.Location = CreateNotOverlapPoint();
            Notes.Add(note);
        }

        public Point CreateNotOverlapPoint()
        {
            Point p;
            var intersects = false;
            do
            {
                p = new Point(NumberGenerator.NextDouble() * 1200, NumberGenerator.NextDouble() * 800);

                intersects = false;
                foreach (var item in Notes)
                {
                    var r = item.Location;

                    if (p.X >= r.X && p.X <= r.X + 150 && p.Y >= r.Y && p.Y <= r.Y + 150 ||
                        p.X >= r.X && p.X <= r.X + 150 && p.Y + 150 >= r.Y && p.Y + 150 <= r.Y + 150 ||
                        p.X + 150 >= r.X && p.X + 150 <= r.X + 150 && p.Y >= r.Y && p.Y <= r.Y + 150 ||
                        p.X + 150 >= r.X && p.X + 150 <= r.X + 150 && p.Y + 150 >= r.Y && p.Y + 150 <= r.Y + 150)

                    {
                        intersects = true;
                        break;
                    }
                }
            } while (intersects);

            return p;
        }
    }
}