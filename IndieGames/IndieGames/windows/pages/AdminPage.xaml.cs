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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IndieGames.windows.pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public List<Game> Games { get; set; }
        public gamesStoreEntities context = new gamesStoreEntities();
        public bool IsToggleCost { get; private set; }
        public bool IsToggleCategories { get; private set; }
        private string checkCategory = "";
        private string checkCost = "";
        public AdminPage()
        {
            
            List<ClientsAndGame> clientsAndGame = new List<ClientsAndGame>();
            try
            {
                Games = context.Games.ToList();
            }
            catch (Exception)
            {
                new CustomMessageBox("Потеряно соединение", "Пожалуйста, перепроверьте соединение с интернетом и запустите программу еще раз").ShowDialog();
                this.IsEnabled = false;
            }
            InitializeComponent();
        }
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

        private void EnterToChangePage(object sender, SelectionChangedEventArgs e)
        {
            InformationPage informationPage = new InformationPage(true);
            Game g = (Game)ListGames.SelectedItem;
            informationPage.DataContext = g;
            NavigationService.Navigate(informationPage);
        }

        private void DeleteGame(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Game game = (Game) button.DataContext;
            context.Games.Remove(game); 
            context.SaveChanges();
            ListGames.ItemsSource = context.Games.ToList();
        }


        private void chooseCost(object sender, RoutedEventArgs e)
        {
            Button button = (Button)(sender);
            TextBlock textBlock = (TextBlock)button.Content;
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

        private void AddGame(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InformationPage(false));
        }

        private void Admin_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ListGames.ItemsSource = context.Games.ToList();
            }
            catch (Exception)
            {
                new CustomMessageBox("Потеряно соединение", "Пожалуйста, перепроверьте соединение с интернетом и запустите программу еще раз").ShowDialog();
                this.IsEnabled = false;
            }
        }
    }
}
