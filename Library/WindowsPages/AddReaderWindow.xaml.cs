using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace Library.WindowsPages
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindow.xaml
    /// </summary>
    public partial class AddReaderWindow : Window
    {
        public Readers newreaders { get; set; }
        public List<Readers> readers { get; set; }

        public int errorcount = 0;
        public bool key;

        public AddReaderWindow(bool selected)
        {
            InitializeComponent();
            key = selected;
            newreaders = new Readers();
            DataContext = newreaders;
            readers = Connection.library.Readers.ToList();
        }

        private void AddReaders(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";
            Connection.library.Readers.Add(newreaders);
            try
            {
                Connection.library.SaveChanges();
                new ReadersWindow().Show();
                Close();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var enityError in ex.EntityValidationErrors)
                {
                    foreach (var validationError in enityError.ValidationErrors)
                    {
                        ErrorLabel.Content += validationError.ErrorMessage + "\n";
                    }
                }
            }
        }

        private void Texbox_error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                errorcount++;

                var errorToolTip = new ToolTip();
                errorToolTip.Content = e.Error.ErrorContent;
                (sender as TextBox).ToolTip = errorToolTip;
            }
            if (e.Action == ValidationErrorEventAction.Removed)
            {
                errorcount--;
            }
            AddReader.IsEnabled = errorcount == 0;
        }

        private void GotoBack(object sender, RoutedEventArgs e)
        {
            if(key == false)
            {
                new ReadersWindow().Show();
                Close();
            }
            else
            {
                new AddOrderBook().Show();
                Close();
            }

        }

    }
}
