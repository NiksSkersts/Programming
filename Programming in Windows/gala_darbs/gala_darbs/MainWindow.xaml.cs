using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using MessageBox = System.Windows.MessageBox;
using System.Net;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using gala_darbs.Properties;
using System.Windows.Controls.Primitives;
using gala_darbs.Models;
using System.Configuration;

#region Comments4Later

//Warning : Perf of app is much better when launched from the build folder rather than the emulator(VS).

#endregion

namespace gala_darbs
{
    //get lines of code : https://stackoverflow.com/questions/1244729/how-do-you-count-the-lines-of-code-in-a-visual-studio-solution
    //https://www.codeproject.com/Questions/534277/Howplustopluscreateplustransparentpluscanvaspluson
    //https://stackoverflow.com/questions/21461017/wpf-window-with-transparent-background-containing-opaque-controls
    //https://stackoverflow.com/questions/12977924/how-to-properly-exit-a-c-sharp-application
    //http://prog3.com/sbdm/blog/jiankunking/article/details/20611383
    //https://stackoverflow.com/questions/1345391/set-focus-on-textbox-in-wpf
    public partial class MainWindow : Window
    {
        #region Attributes

        //This is the part where I declare the stuff I am gonna use later in this class.

        //Arrays
        private string[] commands = new string[10];
        private byte[] rgb = new byte[3];

        //default values
        private double fontsize = Properties.Settings.Default.Def_FontSize;
        private FontFamily fontname = Properties.Settings.Default.Def_FontFam;
        private string font_name = "Ariel";
        private string newline_delim = "[|NEWLINE|]";
        private string nextval_delim = "[|NEXTVALUE|]";
        private const string _fileName = "data.txt";
        private const string _settings = "settings.txt";
        private bool insert_mode = false;
        private bool menu_mode = false;
        private bool listbox_enabled = false;
        private bool open_file_mode = false;
        private int prev_sel = -1;
        private bool lcked = false;

        //rest of the peasantry
        private string menu_funk;
        private string menu_ord;
        private string menu_ord_two;
        private int index;

        //and that thing
        private TextRange range;
        private FontFamilyConverter conv = new FontFamilyConverter();
        public ObservableCollection<Text> Texts;
        private List<string> hists;
        private Settings settings;
        private SettingsView settingsView;

        //https://forgetcode.com/csharp/1188-looping-through-a-list-with-for-and-foreach
        //https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?redirectedfrom=MSDN&view=net-5.0
        //This is the part where I make regex patterns, because I am a lazy fuck and can't be bothered to edit them in a function.
        // how to understand?  string + pattern + function + second function(if combined)
        private string pattern_get_int = @"\D+";
        private string pattern_get_txt = @".txt";

        private string pattern_get_rtf = @".rtf";

        //https://stackoverflow.com/questions/14815105/regular-expression-get-filename-without-extention-from-full-filepath
        private string pattern_get_filename = @"[^\\\/]+(?=\.[\w]+$)|[^\\\/]+$";

        //http://geekswithblogs.net/mbcrump/archive/2010/06/17/configuring-applicationuser-settings-in-wpf-the-easy-way.aspx
        private string pattern_write_quit = Properties.Settings.Default.WriteandQuit;
        private string pattern_write = Properties.Settings.Default.Write;
        private string pattern_quit = Properties.Settings.Default.Quit;
        private string pattern_open = Properties.Settings.Default.OpenFile;
        private string pattern_background = Properties.Settings.Default.RTB_Background;
        private string pattern_foreground = Properties.Settings.Default.RTB_Foreground;
        private string pattern_font_size = Properties.Settings.Default.FontSize;
        private string pattern_font_name = Properties.Settings.Default.FontName;
        private string pattern_curl = Properties.Settings.Default.Curl;
        private string pattern_add = Properties.Settings.Default.Add;
        private string pattern_save = Properties.Settings.Default.Save;
        private string pattern_help = Properties.Settings.Default.Help;

        #region StringStorage

        //selection of premade texts to use. For most part, so I don't have to repeat myself.
        // How to understand? string + text + name
        private string text_help = "//TODO add help info, but that doesn't count in my exec code, so probably na";
        private string text_error = "err?";
        private string text_io_error = "Do you wanna input path to file first?";

        #endregion

        #endregion

        #region Events

        //Events, hopefully never to touch again
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BasicFunc(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BasicFunc(1);
        }

        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listview.SelectedIndex == -1) ClearText(1);
            if (listbox_enabled == true)
            {
                listbox_enabled = false;
                setter.IsEnabled = true;
            }

            try
            {
                InitRTB();
                if (prev_sel <= Texts.Count && prev_sel >= 0) Save(prev_sel);
                LoadTextIntoView(Texts[listview.SelectedIndex].Content, Texts[listview.SelectedIndex].FontSize,
                    Texts[listview.SelectedIndex].FontName);
            }
            catch (ArgumentOutOfRangeException)
            {
                prev_sel = -1;
            }

            prev_sel = listview.SelectedIndex;
            ShowMenu();
        }

        private void New_Page_Button(object sender, RoutedEventArgs e)
        {
            InitRTB();
            if ((range.Text != null || range.Text != "") && listview.SelectedIndex == -1)
            {
                AddToList("New Entry", range.Text, fontsize, fontname);
                ClearText(1);
            }
            else
            {
                AddToList("New Entry", "", fontsize, fontname);
            }

            listview.SelectedItem = Texts.Count;
            ShowMenu();
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
            ShowMenu();
        }

        private void Grid_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (windows.WindowState == WindowState.Maximized && lcked == false)
            {
                lcked = true;
                BasicFunc(2);
            }

            if (windows.WindowState != WindowState.Maximized && lcked == false)
            {
                lcked = true;
                BasicFunc(1);
            }

            lcked = false;
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            @char.Text = "chars: " +
                         new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd).Text.Length;
            ShowMenu();
        }

        private void Save_To_Disk_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog save = new Microsoft.Win32.SaveFileDialog();
            save.DefaultExt = "rtf";
            save.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            if (save.ShowDialog() == true) FileIO(0, 12, save.FileName);
        }

        private void Open_From_Disk(object sender, RoutedEventArgs e)
        {
            open_file_mode = true;
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.DefaultExt = "txt";
            open.Filter = "Text Files (*.txt)|*.txt";
            if (open.ShowDialog() == true)
                if (Regex.IsMatch(open.FileName, pattern_get_txt))
                {
                    var content = FileIO(1, 10, open.FileName);
                    AddToList(open.SafeFileName, content, fontsize, fontname);
                }

            open_file_mode = false;
        }

        private void textbox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.I && menu_mode == false && insert_mode == false &&
                listbox_enabled == false)
            {
                //https://stackoverflow.com/questions/18991415/ignore-keydown-if-the-text-of-a-richtextbox-wont-change
                e.Handled = true;
                Insert();
            }

            if (e.Key == System.Windows.Input.Key.Escape)
            {
                e.Handled = true;
                Rewind();
            }

            if (e.Key == System.Windows.Input.Key.OemSemicolon && insert_mode == false && menu_mode == false &&
                listbox_enabled == false)
            {
                e.Handled = true;
                Menu();
            }

            if (e.Key == System.Windows.Input.Key.Enter && menu_mode == true && insert_mode == false &&
                listbox_enabled == false)
            {
                e.Handled = true;
                Execute();
            }

            if ((e.Key == System.Windows.Input.Key.OemMinus || e.Key == System.Windows.Input.Key.OemPlus) &&
                menu_mode == true && insert_mode == false && listbox_enabled == false)
            {
                InitRTB();
                e.Handled = true;
                if (e.Key == System.Windows.Input.Key.OemMinus)
                    Index(1);
                else
                    Index(0);
            }

            if (e.Key == System.Windows.Input.Key.Delete && insert_mode == false && menu_mode == false) Remove();
            ShowMenu();
        }

        private void RemoveEntry(object sender, RoutedEventArgs e)
        {
            Remove();
        }

        private void RenameEntry(object sender, RoutedEventArgs e)
        {
            Rename();
            ShowMenu();
        }

        private void Mouse_RenameEntry(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (prev_sel == listview.SelectedIndex)
            {
                Rename();
                ShowMenu();
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Rename();
            ShowMenu();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke((Action) (() => { settings = new Settings(); }));
            if (settings.ShowDialog() == true)
            {
            }
            //// None of them worked ...
            //ConfigurationManager.RefreshSection("userSettings");
            //ConfigurationManager.RefreshSection("applicationSettings");
            //Properties.Settings.Default.Reload();
        }

        private void DockPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.Rtf, true) || sender == e.Source) e.Effects = DragDropEffects.None;
        }

        private void DockPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // for more than one file
                var files = (string[]) e.Data.GetData(DataFormats.FileDrop);

                foreach (var item in files)
                {
                    string fina;
                    var fna = Regex.Match(item, pattern_get_filename);
                    if (fna.Success)
                        fina = fna.ToString();
                    else
                        break;
                    var content = FileIO(1, 10, item);
                    AddToList(fina, content, fontsize, fontname);
                }
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //Loaded and Closing
            // More info @ https://stackoverflow.com/questions/41262925/save-application-data-on-closing
            this.Loaded += (s, e) =>
            {
                //Populate Text class with data from file specified in _fileName. Task is running in a Background Thread.
                Task.Run(() => LoadData()).ContinueWith(task => { listview.ItemsSource = Texts; },
                    System.Threading.CancellationToken.None, TaskContinuationOptions.None,
                    TaskScheduler.FromCurrentSynchronizationContext());
            };
            this.Closing += (s, e) => SaveData();
            ClearArray();
            InitRTB();
            ChangeFont(fontsize, font_name, 3);
            InitHist();

            listview.ItemsSource = Texts;
            //Init listview to avoid crashing. Index -1 is a no.no
            listview.SelectedIndex = 0;
        }

        private void InitHist()
        {
            Texts = new ObservableCollection<Text>();
            hists = new List<string>();
            settingsView = new SettingsView();
        }

        private void InitRTB()
        {
            range = new TextRange(textbox.Document.ContentStart, textbox.Document.ContentEnd);
        }

        private void Insert()
        {
            if (insert_mode == false)
            {
                //textbox.Focus();
                textbox.IsReadOnly = false;
                insert_mode = true;
                Keyboard.Focus(textbox);
                textbox.CaretPosition = textbox.CaretPosition.DocumentEnd;

                //https://stackoverflow.com/questions/42429765/set-caret-cursor-position-in-richtextbox-wpf
            }
        }

        private void Menu()
        {
            ClearText(0);
            // menu focus - init
            menu_mode = true;
            menu.IsReadOnly = false;
            menu.IsEnabled = true;
            menu_ord = "";
            Keyboard.Focus(menu);
        }

        private void GetCommand()
        {
            //https://www.dotnetperls.com/regex-split-numbers
            var o = 0;
            // murder a string : https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
            //Get commands from "menu" textbox
            //testing local functions : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/local-functions
            menu_funk = menu.Text;
            if (menu_funk.Length > 5)
            {
                SubGetOrd(1);
                SubGetSpecific();
            }
            else
            {
                SubGetOrd(0);
            }

            void SubGetOrd(byte a)
            {
                commands = menu_funk.Split(' ');
                menu_ord = commands[0].ToLower();
                if (a == 1) menu_ord_two = commands[1];
            }

            void SubGetSpecific()
            {
                if (menu_ord == pattern_background || menu_ord == pattern_foreground)
                {
                    var numbers = Regex.Split(commands[1], pattern_get_int);
                    foreach (var item in numbers)
                    {
                        var i = Convert.ToByte(numbers[o]);
                        rgb[o] = i;
                        o++;
                    }
                }
                else if (menu_ord == pattern_font_size)
                {
                    var numbers = Regex.Split(commands[1], pattern_get_int);
                    fontsize = Convert.ToInt32(numbers[0]);
                }
                else if (menu_ord == pattern_font_name)
                {
                    font_name = "";
                    for (var i = 1; i < commands.Length; i++) font_name = font_name + commands[i] + " ";
                }
            }
        }

        private void Index(byte a)
        {
            if (a == 1)
            {
                index++;
                if (index > hists.Count) index = 0;
            }
            else
            {
                index--;
                if (index < 0) index = hists.Count;
            }

            try
            {
                menu.Text = hists[index];
            }
            catch (Exception)
            {
                return;
            }
        }

        private void Execute()
        {
            //in case I forget Regex : https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-5.0
            InitRTB();
            GetCommand();
            AddToHist();
            //commands
            if (menu_ord == pattern_write)
            {
                FileIO(0, 12, menu_ord_two);

                Affirm();
            }
            else if (menu_ord == pattern_quit)
            {
                BasicFunc(0);
                Affirm();
                Affirm();
            }
            else if (menu_ord == pattern_write_quit)
            {
                FileIO(0, 12, menu_ord_two);
                BasicFunc(0);
                Affirm();
            }
            else if (menu_ord == pattern_open)
            {
                ClearText(1);
                FileIO(0, 11, menu_ord_two);
                Affirm();
            }
            else if (menu_ord == pattern_background)
            {
                ChangeColor(rgb[0], rgb[1], rgb[2], 0);
                Affirm();
            }
            else if (menu_ord == pattern_foreground)
            {
                ChangeColor(rgb[0], rgb[1], rgb[2], 1);
                Affirm();
            }
            else if (menu_ord == pattern_font_size)
            {
                ChangeFont(fontsize, font_name, 0);
                Affirm();
            }
            else if (menu_ord == pattern_font_name)
            {
                //https://www.dotnetperls.com/font
                // for further ref - https://www.dotnetperls.com/uppercase-first-letter
                ChangeFont(fontsize, font_name, 1);
                Affirm();
            }
            else if (menu_ord == pattern_curl)
            {
                GetHTML();
                Affirm();
            }
            else if (menu_ord == pattern_add)
            {
                AddToList(menu_ord_two, range.Text, fontsize, fontname);
                Affirm();
            }
            else if (menu_ord == pattern_save)
            {
                Save(listview.SelectedIndex);
                Affirm();
            }
            else
            {
                menu.Text = text_error;
            }

            void AddToHist()
            {
                hists.Add(menu_funk);
            }

            ClearArray();
            Rewind();
        }

        private void Affirm()
        {
            menu.Text = "Command Executed";
        }

        private void ClearArray()
        {
            //Iztīrīt Array
            Array.Clear(commands, 0, commands.Length);
            //more at https://stackoverflow.com/questions/2673512/how-to-clear-an-array
        }

        private void ClearText(int a)
        {
            if (a == 0) this.Dispatcher.Invoke(() => { menu.Text = ""; });
            if (a == 1) range.Text = "";
            // more at https://stackoverflow.com/questions/9732709/the-calling-thread-cannot-access-this-object-because-a-different-thread-owns-it
        }

        private void Rewind()
        {
            try
            {
                if (listview.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
                {
                    var index = listview.SelectedIndex;
                    if (index >= 0)
                    {
                        var item = listview.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
                        if (item != null) item.Focus();
                    }
                }
                else
                {
                    listview.SelectedItem = 0;
                }
            }
            catch (Exception)
            {
                listview.Focus();
            }

            //Delay tasks: https://stackoverflow.com/questions/48087378/how-to-call-a-method-after-certain-time-has-passed-in-c-sharp
            if (insert_mode == true)
            {
                textbox.IsReadOnly = true;
                insert_mode = false;
            }

            if (menu_mode == true)
            {
                Task.Delay(new TimeSpan(0, 0, 1)).ContinueWith(o => { ClearText(0); });
                menu_mode = false;
                menu.IsEnabled = false;
                menu.IsReadOnly = true;
            }

            if (listbox_enabled == true)
            {
                listbox_enabled = false;
                setter.IsEnabled = true;
            }
        }

        private string FileIO(byte ret, byte func, string url)
        {
            //0 and 10 are empty do nothing ret vals; DO NOT USE THEM!
            if (ret == 1)
            {
                string content;
                using (var sr = new StreamReader(url))
                {
                    content = sr.ReadToEnd();
                }

                return content;
            }

            if (Regex.IsMatch(url, pattern_get_rtf))
            {
                if (func == 11)
                    using (var fStream = new FileStream(url, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        range.Load(fStream, System.Windows.DataFormats.Rtf);
                    }

                if (func == 12)
                    using (var fStream = new FileStream(url, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        if (Regex.IsMatch(url, pattern_get_rtf)) range.Save(fStream, System.Windows.DataFormats.Rtf);
                    }

                return "";
            }
            else if (Regex.IsMatch(url, pattern_get_txt))
            {
                if (func == 11)
                    using (var sr = new StreamReader(url))
                    {
                        range.Text = sr.ReadToEnd();
                    }
                else if (func == 12)
                    using (var sr = new StreamWriter(url))
                    {
                        sr.Write(range.Text);
                    }
            }

            //Get text and save it to a file.
            return "";
        }

        private void GetHTML()
        {
            try
            {
                var webRequest = (HttpWebRequest) HttpWebRequest.Create(menu_ord_two);
                webRequest.Method = "GET";
                var webResponse = (HttpWebResponse) webRequest.GetResponse();
                var webSource = new StreamReader(webResponse.GetResponseStream());
                range.Text = webSource.ReadToEnd();
                webResponse.Close();
            }
            catch (Exception)
            {
                menu.Text = text_io_error;
            }
        }

        private void ChangeColor(byte a, byte b, byte c, byte d)
        {
            //needs rewamp
            if (d == 0)
            {
                //Konvertē uz Hex.
                Properties.Settings.Default.RTB_Background_Color =
                    (Color) ColorConverter.ConvertFromString("#" + a.ToString("X2") + b.ToString("X2") +
                                                             c.ToString("X2"));
                textbox.Background = new SolidColorBrush(Color.FromRgb(a, b, c));
            }

            if (d == 1)
            {
                Properties.Settings.Default.RTB_Foreground_Color =
                    (Color) ColorConverter.ConvertFromString("#" + a.ToString("X2") + b.ToString("X2") +
                                                             c.ToString("X2"));
                textbox.Foreground = new SolidColorBrush(Color.FromRgb(a, b, c));
            }
        }

        private void ChangeFont(double a, string c, byte b)
        {
            //font size part
            if (b == 0)
            {
                //https://www.reddit.com/r/commandline/comments/3yb1g7/standard_terminal_size/
                var s = (double) new FontSizeConverter().ConvertFrom(a);
                Texts[listview.SelectedIndex].FontSize = s;
                range.ApplyPropertyValue(Inline.FontSizeProperty, s);
            }

            if (b == 1 && c != null)
            {
                textbox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, c);
                Texts[listview.SelectedIndex].FontName = (System.Windows.Media.FontFamily) conv.ConvertFromString(c);
                LoadTextIntoView(Texts[listview.SelectedIndex].Content, Texts[listview.SelectedIndex].FontSize,
                    Texts[listview.SelectedIndex].FontName);
            }
        }

        public void AddToList(string header, string content, double fontsize, FontFamily fontname)
        {
            Texts.Add(new Text()
            {
                Header = header,
                Content = content,
                FontSize = fontsize,
                FontName = fontname
            });
        }

        private void Save(int selection)
        {
            if (selection >= 0 && selection <= Texts.Count)
                Texts[selection].Content = range.Text;
            else
                AddToList("New Entry", range.Text, fontsize, fontname);
        }

        private void BasicFunc(byte a)
        {
            if (a == 0)
            {
                Save(listview.SelectedIndex);
                System.Windows.Application.Current.Shutdown();
            }

            if (a == 1) this.WindowState = WindowState.Minimized;
            if (a == 2) windows.WindowState = WindowState.Normal;
        }

        private void SaveData()
        {
            //https://www.c-sharpcorner.com/UploadFile/mahesh/split-string-in-C-Sharp/
            using (var sw = new StreamWriter(_fileName))
            {
                foreach (var item in Texts)
                    sw.Write(
                        $"{newline_delim}{item.Header}{nextval_delim}{item.Content}{nextval_delim}{item.FontSize}{nextval_delim}{item.FontName}");
            }

            Properties.Settings.Default.Save();
        }

        private void LoadData()
        {
            //More @: http://zetcode.com/csharp/readtext/
            //Not purrrfect, It adds empty spaces in the end. Cheeky fucker.
            //warning: deal with it later
            InitHist();
            if (File.Exists(_fileName))
                //CSV supposedly is rather complicated. Fallback - TXT
                using (var sr = new StreamReader(_fileName))
                {
                    var lines = sr.ReadToEnd();
                    var lines_saved = lines.Split(new string[] {newline_delim}, StringSplitOptions.None);
                    foreach (var item in lines_saved)
                    {
                        var columns = item.Split(new string[] {nextval_delim}, StringSplitOptions.None);
                        if (columns.Length == 4)
                            Texts.Add(new Text()
                            {
                                Header = columns[0],
                                Content = columns[1],
                                FontSize = Convert.ToDouble(columns[2]),
                                FontName = (System.Windows.Media.FontFamily) conv.ConvertFromString(columns[3])
                            });
                    }
                }

            //set saved settings for bg and fg.
            this.Dispatcher.Invoke(() =>
            {
                var converter = new System.Windows.Media.BrushConverter();
                ;
                textbox.Background =
                    (Brush) converter.ConvertFromString(Properties.Settings.Default.RTB_Background_Color.ToString());
                textbox.Foreground =
                    (Brush) converter.ConvertFromString(Properties.Settings.Default.RTB_Foreground_Color.ToString());
            });
        }

        private void Rename()
        {
            listbox_enabled = true;
            setter.IsEnabled = false;
            ListBoxItem listBoxItem =
                (ListBoxItem) listview.ItemContainerGenerator.ContainerFromItem(listview.SelectedItem);
            listview.ScrollIntoView(listBoxItem);
            Keyboard.Focus(listBoxItem);
        }

        private void ShowMenu()
        {
            if (menu_mode == true)
                show_mode.Text = "Menu Mode";
            else if (insert_mode == true)
                show_mode.Text = "Insert Mode";
            else if (listbox_enabled == true)
                show_mode.Text = "File Rename Mode";
            else
                show_mode.Text = "";
        }

        private void Remove()
        {
            prev_sel = -1;
            Texts.RemoveAt(listview.SelectedIndex);
            listview.SelectedIndex = Texts.Count - 1;
            Rewind();
            ShowMenu();
        }

        private void LoadTextIntoView(string content, double fontsize, FontFamily fontname)
        {
            range.Text = content;
            range.ApplyPropertyValue(Inline.FontSizeProperty, fontsize);
            textbox.FontFamily = fontname;
        }
    }
}
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
//https://stackoverflow.com/questions/3176602/how-to-force-a-number-to-be-in-a-range-in-c

//https://stackoverflow.com/questions/2395438/convert-system-drawing-color-to-rgb-and-hex-value
//https://stackoverflow.com/questions/10062376/creating-solidcolorbrush-from-hex-color-value
//https://stackoverflow.com/questions/2109756/how-do-i-get-the-color-from-a-hexadecimal-color-code-using-net
//https://stackoverflow.com/questions/3315088/how-do-i-serialize-a-system-windows-media-color-object-to-an-srgb-string
//https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.fontfamily?view=net-5.0