using Library.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
    /// Логика взаимодействия для AddBooksWindows.xaml
    /// </summary>
    public partial class AddBooksWindows : Window
    {
        public Books newbook { get; set; }
        private int errorcount = 0;
        public AddBooksWindows()
        {
            InitializeComponent();

            newbook = new Books();
            DataContext = newbook;


            ComboBox_Publisher.ItemsSource = Connection.library.Publisher.ToList();
            ComboBox_LBC.ItemsSource = Connection.library.LBC.ToList();
            ComboBox_Genrename.ItemsSource = Connection.library.Genre.ToList();
        }



        private void GotoBack(object sender, RoutedEventArgs e)
        {
            new BooksWindows().Show();
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
            AddBook.IsEnabled = errorcount == 0;
        }

        private void ADDBook(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";

            newbook.Publisher_id = ComboBox_Publisher.SelectedIndex + 1;
            newbook.LBC_Id = ComboBox_LBC.SelectedIndex + 1;        
            newbook.Genre_id = ComboBox_Genrename.SelectedIndex + 1;
            newbook.AuthorSign = AuthorSign(TextBox_Author.Text.Trim());

            Connection.library.Books.Add(newbook);

            try
            {
                Connection.library.SaveChanges();
                new BooksWindows().Show();
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

        private void LoadServicePhoto(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Png image|*.png";
            string filepath = string.Empty;

            if (fileDialog.ShowDialog() == true)
            {
                filepath = fileDialog.FileName;
            }
            else
            {
                return;
            }


            string filename = System.IO.Path.GetFileName(filepath);
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            exePath = System.IO.Path.GetDirectoryName(exePath);

            if (File.Exists($"{exePath}/ImageBooks/{filename}"))
            {
                filename = new Random().Next(int.MaxValue) + filename;
            }

            File.Copy(filepath, $"{exePath}/ImageBooks/{filename}");
            MainImage.Source = new BitmapImage(new Uri($"pack://siteoforigin:,,,/ImageBooks/{filename}"));

            newbook.Image = $"/ ImageBooks /{ filename}";
        }

        public static string AuthorSign(string author)
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            exePath = System.IO.Path.GetDirectoryName(exePath);
            string result = "";
            author = author.ToLower(); //толстой л.н.
            using (StreamReader sw = new StreamReader($"{exePath}/Resource/Аторский знак.txt", System.Text.Encoding.UTF8))
            {
                string line = "";
                while ((line = sw.ReadLine()) != null)
                {
                    string[] values = line.Split('\t');

                    string count = values[0], code = values[1], text = values[2];

                    if (author.StartsWith(text))
                    {
                        if (author == text)
                        {
                            result = $"{code}";
                            return result;
                        }
                        result = $"{code}";
                    }

                    if (author == text)
                    {
                        result = $"{code}";
                    }

                }

            };
            return result;
        }
    }
}
