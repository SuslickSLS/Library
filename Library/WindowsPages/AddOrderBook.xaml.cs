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
using Library.Model;

namespace Library.WindowsPages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderBook.xaml
    /// </summary>
    public partial class AddOrderBook : Window
    {
        public Order newOrder { get; set; }
        public Books book { get; set; }
        public Issuance_Books  newissuanceBooks { get; set; }
        public AddOrderBook()
        {
            InitializeComponent();

            book = new Books();
            newOrder = new Order();
            newissuanceBooks = new Issuance_Books();

            ReadersComboBox.ItemsSource = Connection.library.Readers.ToList() ;
            BooksComboBox.ItemsSource = Connection.library.Books.ToList().Where(x => x.count > 0);
        }

        private void AddOrderBookButton(object sender, RoutedEventArgs e)
        {
            if (ReadersComboBox.SelectedItem == null || BooksComboBox.SelectedItem == null)
            {
                MessageBox.Show("Не все значения выбраны");
            }
            else
            {
                try
                {
                    
                    newOrder.Readers_id = (ReadersComboBox.SelectedItem as Readers).Reader_ticket;                  
                    newOrder.Date_order = DateTime.Now;
                    newOrder.Date_end_order = DateTime.Now.AddDays(7);

                    Connection.library.Order.Add(newOrder);

                    newissuanceBooks.Books_id = (BooksComboBox.SelectedItem as Books).Book_id;
                    newissuanceBooks.Order_id = newOrder.Order_id;
                    Connection.library.Issuance_Books.Add(newissuanceBooks);

                    book = BooksComboBox.SelectedItem as Books;
                    book.count--;
                    Connection.library.SaveChanges();
                    MessageBox.Show("Успешно", "Библиотека");
                    new BooksWindows().Show();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении!", "Библиотека");
                }
            }
        }

        private void GoToAddReaders(object sender, RoutedEventArgs e)
        {
            new AddReaderWindow(true).Show();
            Close();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            new BooksWindows().Show();
            Close();
        }
    }
}
