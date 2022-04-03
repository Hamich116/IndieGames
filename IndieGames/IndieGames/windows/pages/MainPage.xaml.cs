using IndieGames.windows.pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace IndieGames
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public gamesStoreEntities context = new gamesStoreEntities();

        public MainPage()
        {
            InitializeComponent();
        }

        private void ToLibraryClick(object sender, RoutedEventArgs e)
        {
            LibraryPage page = new LibraryPage((Client)DataContext);
            page.DataContext = page.DataContext;
            frameContent.Content = page;
        }

        private void ToStoreClick(object sender, RoutedEventArgs e)
        {
            StorePage page = new StorePage((Client)DataContext);
            page.DataContext = DataContext;
            frameContent.Content = page; 
        }

        private void ToPaymentClick(object sender, RoutedEventArgs e)
        {
            PaymentPage page = new PaymentPage();
            page.DataContext = DataContext;
            frameContent.Content = page;
        }
    }
}
