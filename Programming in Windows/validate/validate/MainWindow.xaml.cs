using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Text.RegularExpressions;

namespace validate
{
    // data sources
    // https://www.tutorialspoint.com/wpf/wpf_data_binding.htm
    //https://www.abhith.net/blog/c-sharp-get-last-n-characters-from-a-string/
    //https://stackoverflow.com/questions/6018167/multiple-field-validator-in-wpf-search-form
    public partial class MainWindow : Window
    {
        private Person person = new();
        public bool error = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = person;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((Validation.GetHasError(NameBox) || Validation.GetHasError(DateBox) ||
                 Validation.GetHasError(NumberBox) || Validation.GetHasError(PageBox) ||
                 Validation.GetHasError(EmailBox)) == false)
                MessageBox.Show("All Clear");
            else
                MessageBox.Show("Fix all the errors");
        }
    }

    public class Person
    {
        public string name_text;
        public string date;
        public string number;
        public string page;
        public string email;

        public string Name
        {
            get => name_text;
            set => name_text = value;
        }

        public string Date
        {
            get => date;
            set => date = value;
        }

        public string Number
        {
            get => number;
            set => number = value;
        }

        public string Page
        {
            get => page;
            set => page = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }
    }

    public class Name_Rule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var val = value as string;
            if (Regex.IsMatch(val, @"^([A-Z]\w{3,20})$")) return ValidationResult.ValidResult;
            return new ValidationResult(false, null);
        }
    }

    public class Date_Rule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var val = value as string;
            int year;
            if (val.Length == 10)
            {
                year = Convert.ToInt32(val.Substring(val.Length - 4));
                if (year > 1950 && year < 2001) return ValidationResult.ValidResult;
                return new ValidationResult(false, null);
            }

            if (Regex.IsMatch(val, @"^(\d{2}.\d{2}.\d{4})$") || Regex.IsMatch(val, @"^(\d{2}.\d{2}.\d{4})$"))
                return ValidationResult.ValidResult;
            return new ValidationResult(false, null);
        }
    }

    public class Number_Rule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var val = value as string;
            if (Regex.IsMatch(val, @"^(\d{8})$") || Regex.IsMatch(val, @"^([+]371\s\d{8})$"))
                return ValidationResult.ValidResult;
            return new ValidationResult(false, null);
        }
    }

    public class Page_Rule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var val = value as string;
            if (Regex.IsMatch(val, @"^([w]{3}[.]\w{1,100}[.]\w{2,10})$") ||
                Regex.IsMatch(val, @"^([w]{3}[.]\w{1,50}[.]\w{1,10}[.]\w{2,10})$")) return ValidationResult.ValidResult;
            return new ValidationResult(false, null);
        }
    }

    public class Email_Rule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var val = value as string;
            if (Regex.IsMatch(val, @"^(\w{1,100}[@]\w{1,50}[.]\w{2,10})$") ||
                Regex.IsMatch(val, @"^(\w{1,100}[@]\w{1,50}[.]\w{2,10}[.]\w{2,10})$"))
                return ValidationResult.ValidResult;
            return new ValidationResult(false, null);
        }
    }
}