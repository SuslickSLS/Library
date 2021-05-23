using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
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
       public Books Books;
       public OrderWindow()
        {
            InitializeComponent();
            issuance_Books = new ObservableCollection<Issuance_Books>(Connection.library.Issuance_Books);
            DataContext = this;

            Books = new Books();
        }

        private void GoToBack(object sender, RoutedEventArgs e)
        {
            new BooksWindows().Show();
            Close();
        }

        private void DeletOrder(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                var result = MessageBox.Show("Вы хотите вернуть книгу", "Возврат", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    int id = (int)button.Tag;
                    Issuance_Books issuance = Connection.library.Issuance_Books.Find(id);
                    issuance_Books.Remove(issuance);
                    Connection.library.Issuance_Books.Remove(issuance);
                    Books = Connection.library.Books.Find(issuance.Books_id);
                    Books.count++;
                    
                    try
                    {
                        
                        Connection.library.SaveChanges();                        
                    }
                    catch (DbUpdateException)
                    {
                        MessageBox.Show("При удалении произошла ошибка.");
                        Connection.library.Issuance_Books.Add(issuance);
                        issuance_Books.Add(issuance);

                    }
                    Connection.library.SaveChanges();
                }
            }
        }
    }
}
