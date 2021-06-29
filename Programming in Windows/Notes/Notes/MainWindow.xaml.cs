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

namespace Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool startMove;
        private Point start;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var notesViewModel = (NotesViewModel) this.DataContext;
            var newNoteWindow = new NewNoteWindow();
            if (newNoteWindow.ShowDialog() == true) notesViewModel.AddNote(newNoteWindow.notesViewModel.Note);
        }

        private void dockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var elem = sender as FrameworkElement;
            var note = (Note) ((DockPanel) sender).DataContext;
            startMove = true;
            start = e.GetPosition(this);
            elem.CaptureMouse();
            e.Handled = true;
        }

        private void dockPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (startMove)
            {
                Point p = e.GetPosition(this);
                var note = (Note) ((DockPanel) sender).DataContext;
                Point newLoc = new Point(note.Location.X + (p.X - start.X), note.Location.Y + (p.Y - start.Y));
                start = p;
                note.Location = newLoc;
            }
        }

        private void dockPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (startMove)
            {
                startMove = false;
                var elem = sender as FrameworkElement;
                elem.ReleaseMouseCapture();
                e.Handled = true;
            }
        }

        private void dockPanel_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var note = (Note) ((DockPanel) sender).DataContext;
            note.Angle += e.Delta / 100;
        }
    }
}