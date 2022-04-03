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

namespace IndieGames.windows.pages
{
    /// <summary>
    /// Логика взаимодействия для invoicePage.xaml
    /// </summary>
    public partial class InvoicePage : Page
    {
        MainPage mainPage = (MainPage)App.Current.MainWindow.Content;
        public InvoicePage(string clientName)
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString();
            login.Text = clientName;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            ((MainPage)App.Current.MainWindow.Content).frameContent.Content = null;
        }

        private void printer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                close.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "check");
                }
            }
            finally
            {
                this.IsEnabled = true;
                close.Visibility = Visibility.Visible;
            }
        }
    }
}
