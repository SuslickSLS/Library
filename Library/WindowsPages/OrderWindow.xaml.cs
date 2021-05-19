using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Library.Model;

namespace Library.WindowsPages
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
     
   

    public partial class OrderWindow : Window
    {

       public ObservableCollection<Issuance_Books>  issuance_Books { get; set; }
       public OrderWindow()
        {
            InitializeComponent();
            issuance_Books = new ObservableCollection<Issuance_Books>(Connection.library.Issuance_Books);
            DataContext = this;
        }

        private void GoToBack(object sender, RoutedEventArgs e)
        {
            new BooksWindows().Show();
            Close();
        }
    }
}
