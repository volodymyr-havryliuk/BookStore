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
using HomeLibrary;

namespace BookCatalog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxBookId = MyBookCollection.GetMyCollection().Count;
        MessageBoxResult result;

        public MainWindow()
        {
            InitializeComponent();
            ListOfBooks.ItemsSource = MyBookCollection.GetMyCollection();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var nextId = maxBookId + 1;
            MyBookCollection.AddBook(new Book(++maxBookId)
            {
                Author = BookAuthor.Text,
                Format = (BookFormat)BookFormat.SelectedItem,
                IsRead = (bool)BookIsRead.IsChecked,
                Title = BookTitle.Text,
                Year = Int32.Parse(BookYear.Text)
            });
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBox.Show("Delete selected book?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            if (result == MessageBoxResult.Yes && e.OriginalSource is Button && ((Button)e.OriginalSource).Name == "DeleteBookButton")
            {
                MyBookCollection.GetMyCollection().Remove((Book)ListOfBooks.SelectedItem);
            }
        }
    }
}