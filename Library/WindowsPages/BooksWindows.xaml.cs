using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.Model;

namespace Library.WindowsPages
{
    /// <summary>
    /// Логика взаимодействия для BooksWindows.xaml
    /// </summary>
    public partial class BooksWindows : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Books> books;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Books> Book
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Book"));
                }
            }
        }
        public BooksWindows()
        {
            InitializeComponent();
            Book = Connection.library.Books.ToObservableCollection();
            DataContext = this;
        }

        private void AddBookWindow(object sender, RoutedEventArgs e)
        {

            new AddBooksWindows().Show();
            this.Close();
        }

        private void TextBox_BookTitleChange(object sender, TextChangedEventArgs e)
        {
            FindSort();
        }

        private void GoToRedactionWindow(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);
            Books selected = button.Tag as Books;
            new UpdateBooksWindow(selected).Show();
            Close();

        }

        private void Sort(object sender, SelectionChangedEventArgs e)
        {
            FindSort();
        }

        private void FindSort()
        {
            Book = Connection.library.Books.ToObservableCollection();

            if (comboBoxSort != null)
            {
                if (comboBoxSort.SelectedIndex == 0)
                {
                    Book = Book.OrderBy(s => s.Author).ToObservableCollection();
                }
                else if (comboBoxSort.SelectedIndex == 1)
                {
                    Book = Book.OrderByDescending(s => s.Author).ToObservableCollection();
                }
            }
            if (Booktitle_TextBox.Text != null && Booktitle_TextBox.Text != "")
            {
                Book = Book.Where(s => s.Book_title.ToUpper().StartsWith(Booktitle_TextBox.Text.ToUpper())).ToObservableCollection();
            }
        }

        private void GotoExtraditionPage(object sender, RoutedEventArgs e)
        {
            
        }

        private void GoToBack(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
