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
    /// Логика взаимодействия для ReadersWindow.xaml
    /// </summary>
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data.Entity.Infrastructure;
    using Library.Model;


    public partial class ReadersWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Readers> readers;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Readers> Reader
        {
            get
            {
                return readers;
            }
            set
            {
                readers = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Reader"));
                }
            }
        }

        public ReadersWindow()
        {
            InitializeComponent();
            Reader = Connection.library.Readers.ToObservableCollection();
            DataContext = this;
        }

        private void AddReadersWindow(object sender, RoutedEventArgs e)
        {
            new AddReaderWindow().Show();
            Close();
        }

        private void TextBox_FIOChange(object sender, TextChangedEventArgs e)
        {
            FindSort();
        }

        private void Sort_Last_name(object sender, SelectionChangedEventArgs e)
        {
            FindSort();
        }


        private void FindSort()
        {
            Reader = Connection.library.Readers.ToObservableCollection();

            if (comboBoxSort != null)
            {
                if (comboBoxSort.SelectedIndex == 0)
                {
                    Reader = Reader.OrderBy(s => s.Reader_surname).ToObservableCollection();
                }
                else if (comboBoxSort.SelectedIndex == 1)
                {
                    Reader = Reader.OrderByDescending(s => s.Reader_surname).ToObservableCollection();
                }
            }
            if (Fio_TextBox.Text != null && Fio_TextBox.Text != "")
            {
                Reader = Reader.Where(s => s.Reader_name.ToUpper().StartsWith(Fio_TextBox.Text.ToUpper()) || s.Reader_surname.ToUpper().StartsWith(Fio_TextBox.Text.ToUpper()) || s.Reader_MiddleName.ToUpper().StartsWith(Fio_TextBox.Text.ToUpper())).ToObservableCollection();
            }
        }

        private void GoToRedactionWindow(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);
            Readers selected = button.Tag as Readers;
            new UpdateReaderWindow(selected).Show();
            Close();
            //NavigationService.Navigate(new RedactionReadersPage(selected));
        }

        private void DeleteReader(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                var result = MessageBox.Show("Вы хотите удалить читателя", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    int id = (int)button.Tag;
                    Readers readers = Connection.library.Readers.Find(id);
                    Reader.Remove(readers);
                    Connection.library.Readers.Remove(readers);
                    try
                    {
                        Connection.library.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        MessageBox.Show("При удалении произошла ошибка.");
                        Connection.library.Readers.Add(readers);
                        Reader.Add(readers);

                    }
                    Connection.library.SaveChanges();
                }
            }
        }

        private void GoToBack(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
