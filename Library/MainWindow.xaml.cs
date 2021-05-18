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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.WindowsPages;


namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Connection.library = new LibraryModel();
        }

        private void GoToBooksWindow(object sender, RoutedEventArgs e)
        {
            new BooksWindows().Show();
            Close();
        }

        private void GoToReaderWindow(object sender, RoutedEventArgs e)
        {
            new ReadersWindow().Show();            
            Close();
        }
    }
}
