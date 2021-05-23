using Library.Model;
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
using System.Windows.Shapes;

namespace Library.WindowsPages
{
    /// <summary>
    /// Логика взаимодействия для UpdateReaderWindow.xaml
    /// </summary>
    public partial class UpdateReaderWindow : Window
    {
        public Readers reader { get; set; }
        public int errorcount = 0;
        public UpdateReaderWindow(Readers select)
        {
            InitializeComponent();
            DataContext = reader = select;

        }

      

        private void GotoBack(object sender, RoutedEventArgs e)
        {
            var serviceEntry = Connection.library.Entry<Readers>(reader);
            serviceEntry.Reload();
            new ReadersWindow().Show();
            Close();
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
            UpdateReader.IsEnabled = errorcount == 0;
        }

        private void UpdateReaders(object sender, RoutedEventArgs e)
        {
            Connection.library.SaveChanges();
            new ReadersWindow().Show();
            Close();
        }

      
    }
}
