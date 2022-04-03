using IndieGames.windows;
using IndieGames.windows.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IndieGames
{
    /// <summary>
    /// Логика взаимодействия для StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        public bool IsToggleCost { get; private set; }
        public bool IsToggleCategories { get; private set; }
        private bool isEnable = true;
        private string checkCategory = "";
        private string checkCost = "";
        MainPage mainPage = (MainPage)App.Current.MainWindow.Content;
        MainWindow mainWindow = (MainWindow) App.Current.MainWindow;
        List<Game> clientGames;
        Client client;
        public StorePage(Client client)
        {
            this.client = client;
            List<ClientsAndGame> clientsAndGame = new List<ClientsAndGame>();
            try
            {
                Games = mainPage.context.Games.ToList();
                clientsAndGame = mainPage.context.ClientsAndGames.Where(c => c.ClientId == client.Id).ToList();
            }
            catch (Exception)
            {
                new CustomMessageBox("Потеряно соединение", "Пожалуйста, перепроверьте соединение с интернетом и запустите программу еще раз").ShowDialog();
                this.IsEnabled = false;
                
            }
            
            clientGames = new List<Game>();
            foreach (var clientAndGame in clientsAndGame)
            {
                clientGames.Add(clientAndGame.Game);
            }
            InitializeComponent();
        }
        public List<Game> Games { get; set; }


        private void CostButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            if (!IsToggleCost)
            {
                animation.To = 130;
                animation.Duration = TimeSpan.FromSeconds(1);
                costContent.BeginAnimation(Border.HeightProperty, animation);
                IsToggleCost = true;
            }
            else
            {
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(1);
                costContent.BeginAnimation(Border.HeightProperty, animation);
                IsToggleCost = false;
            }
        }

        private void categoriesButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            if (!IsToggleCategories)
            {
                animation.To = 160;
                animation.Duration = TimeSpan.FromSeconds(1);
                categoriesContent.BeginAnimation(Border.HeightProperty, animation);
                IsToggleCategories = true;
            }
            else
            {
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(1);
                categoriesContent.BeginAnimation(Border.HeightProperty, animation);
                IsToggleCategories = false;
            }
        }
        
        private void EnterToGamePage(object sender, SelectionChangedEventArgs e)
        {

            Game g = (Game)ListGames.SelectedItem;
            if (g != null)
            {
                GamePage gamePage = new GamePage(g.Trailer, isEnable, client);
                gamePage.DataContext = g;
                NavigationService.Navigate(gamePage);
            }
            
        }

        private void BuyGame(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Game game = (Game) button.DataContext;
            Client client;
            try
            {
                client = mainPage.context.Clients.Find(this.client.Id);
                if (client.Balance.HasValue)
                {
                    if (client.Balance >= game.Cost)
                    {
                        client.ClientsAndGames.Add(new ClientsAndGame
                        {
                            Client = client,
                            Game = game,
                        });
                        ((MainPage)App.Current.MainWindow.Content).DataContext = client;
                        InvoicePage invoicePage = new InvoicePage(client.Login);
                        invoicePage.DataContext = game;
                        mainPage.context.SaveChanges();
                        client.Balance -= game.Cost;
                        NavigationService.Navigate(invoicePage);
                    }
                    else
                    {
                        new CustomMessageBox("Недостаточно средств", "Сперва пополните баланс").ShowDialog();
                    }
                }
                else
                {
                    new CustomMessageBox("Недостаточно средств", "Сперва пополните баланс").ShowDialog();
                }
            }
            catch (Exception)
            {
                new CustomMessageBox("Ошибка", "Не удалось подключиться к серверу! Попробуйте позже!").ShowDialog();
                return;
            }
            

        }

        private void buyButton_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            
            Button button = (Button)sender;
            Game game;
            game = clientGames.Find(g => g.Id == ((Game)button.DataContext).Id);
            if (game != null)
            {
                button.IsEnabled = false;
            }
        }

        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            StackPanel stackPanel = (StackPanel) grid.Children[1];
            Button button = (Button)stackPanel.Children[1];
            Game game;
            game = clientGames.Find(g => g.Id == ((Game)button.DataContext).Id);
            if (game != null)
            {
                button.IsEnabled = false;
                isEnable = false;
            }
            else
            {
                button.IsEnabled = true;
                isEnable = true;
            }
        }

        private void chooseCost(object sender, RoutedEventArgs e)
        {
            Button button = (Button)(sender);
            TextBlock textBlock = (TextBlock) button.Content;
            int cost;
            List<Game> games;
            if (checkCost == textBlock.Text)
            {
                ListGames.ItemsSource = Games;
                checkCost = "";
            }
            else
            {
                checkCost = textBlock.Text;
                if (textBlock.Text.Remove(4) == "Ниже")
                {
                    cost = Convert.ToInt32(textBlock.Text.Substring(4));
                    games = Games.Where(g => g.Cost < cost).ToList();
                }
                else
                {
                    cost = Convert.ToInt32(textBlock.Text.Remove(3));
                    games = Games.Where(g => g.Cost > cost).ToList();
                }
                ListGames.ItemsSource = games;
            }
        }

        private void chooseCategories(object sender, RoutedEventArgs e)
        {
            Button button = (Button)(sender);
            TextBlock textBlock = (TextBlock)button.Content;
            string category = textBlock.Text;
            List<Game> games;
            if (checkCategory == textBlock.Text)
            {
                ListGames.ItemsSource = Games;
                checkCategory = "";
            }
            else
            {
                try
                {
                    checkCategory = textBlock.Text;
                    if (category != "Другие")
                    {
                        games = Games.Where(g => g.Category.Name == category).ToList();
                    }
                    else
                    {
                        games = Games.Where(g => g.Category.Name != "Экшен" && g.Category.Name != "RogueLike"
                        && g.Category.Name != "RPG" && g.Category.Name != "Приключение").ToList();
                    }
                    ListGames.ItemsSource = games;
                }
                catch (Exception)
                {
                    new CustomMessageBox("Ошибка", "Не удалось подключиться к серверу! Попробуйте позже!").ShowDialog();
                    return;
                }
                
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

        private void Store_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
