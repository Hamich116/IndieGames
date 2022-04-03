using IndieGames.windows;
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
    /// Логика взаимодействия для LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        MainPage mainPage = (MainPage)App.Current.MainWindow.Content;
        public LibraryPage(Client client)
        {
            List<ClientsAndGame> clientsAndGame = new List<ClientsAndGame>();
            try
            {
                clientsAndGame = mainPage.context.ClientsAndGames.Where(c => c.ClientId == client.Id).ToList();
            }
            catch (Exception)
            {
                new CustomMessageBox("Потеряно соединение", "Пожалуйста, перепроверьте соединение с интернетом и запустите программу еще раз").ShowDialog();
                this.IsEnabled = false;
            }
             
            List<Game> games = new List<Game>();
            foreach (var clientAndGame in clientsAndGame)
            {
                games.Add(clientAndGame.Game);
            }
            Games = games.ToList();
            InitializeComponent();
            
            //SearchPicture.Source = new BitmapImage(new Uri("C:/Users/Hamich/Documents/GitHub/IndieGames/IndieGames/IndieGames/resources/search.png"));
        }
        public List<Game> Games { get; set; }


        private void DownloadGame(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string link = ((Game)button.DataContext).MagnetUri;
            
            if (link.Length > 21)
            {
                string check1 = link.Substring(0, 20);
                if (check1 == "magnet:?xt=urn:btih:")
                {
                    Process.Start(link);
                }
                else
                {
                    new CustomMessageBox("Технические проблемы", "Не правильная ссылка на сервере. Попробуйте в другое время").ShowDialog();
                }
            }
            else
            {
                new CustomMessageBox("Технические проблемы", "Не найдена ссылка на сервере. Попробуйте в другое время").ShowDialog();
            } 
        }

        private void sortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock textBlock = (TextBlock)comboBox.SelectedItem;
            List<Game> games;
            try
            {
                if (textBlock.Text == "Другие")
                {
                    games = Games.Where(g => g.Category.Name != "Экшен" && g.Category.Name != "RogueLike"
                        && g.Category.Name != "RPG" && g.Category.Name != "Приключение").ToList();
                    ListGames.ItemsSource = games;
                }
                else if (textBlock.Text == "Все")
                {
                    ListGames.ItemsSource = Games;
                }
                else
                {
                    games = Games.Where(g => g.Category.Name == textBlock.Text).ToList();
                    ListGames.ItemsSource = games;
                }
            }
            catch (Exception)
            {
                new CustomMessageBox("Ошибка", "Не удалось подключиться к серверу! Попробуйте позже!").ShowDialog();
                return;
            }
            
        }

        private void searchGame(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            List<Game> findGames;
            int length = textBox.Text.Length;
            if (textBox.Text == "")
            {
                ListGames.ItemsSource = Games;
            }
            else
            {
                List<Game> games = Games.Where(g => g.Name.Length > length).ToList();
                Game game = Games.Where(g => g.Name == textBox.Text).FirstOrDefault();
                findGames = games.Where(g => g.Name.Remove(length) == textBox.Text).ToList();
                if (game != null)
                {
                    findGames.Add(game);
                }
                ListGames.ItemsSource = findGames;
            }
        }
    }
}
