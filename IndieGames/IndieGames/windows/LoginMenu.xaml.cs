using IndieGames.windows;
using IndieGames.windows.pages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace IndieGames
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class LoginMenu : Window
    {
        gamesStoreEntities context;
        public LoginMenu()
        {
            InitializeComponent();
            context = new gamesStoreEntities();
            try
            {
                context.Clients.Load();
            }
            catch (Exception)
            {
                new CustomMessageBox("Потеряно соединение", "Пожалуйста, перепроверьте соединение с интернетом и запустите программу еще раз").ShowDialog();
                this.Close();
            }
            
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            try
            {
                client = context.Clients.Where(c => c.Login == Login.Text).FirstOrDefault();
            }
            catch (Exception)
            {
                new CustomMessageBox("Потеряно соединение", "Пожалуйста, перепроверьте соединение с интернетом и запустите программу еще раз").ShowDialog();
                this.Close();
            }
            
            if (client != null)
            {
                if (client.IsAdministration.HasValue)
                {
                    if (client.IsAdministration.Value)
                    {
                        if (Password.Password == client.Password)
                        {
                            MainWindow main = new MainWindow();
                            AdminPage adminPage = new AdminPage();
                            adminPage.DataContext = client;
                            main.Navigate(adminPage);
                            main.Show();
                            App.Current.MainWindow = main;
                            this.Close();
                        }
                        else
                        {
                            CustomMessageBox box = new CustomMessageBox("Ошибка", "Не правильный пароль");
                            box.ShowDialog();
                        }
                        
                    }
                    else
                    {
                        clientEnter(client);
                    }
                }
                else
                {
                    clientEnter(client);
                }
                
            }
            else
            {
                CustomMessageBox box = new CustomMessageBox("Ошибка", "Не найден пользователь");
                box.ShowDialog();
            }
            
        }
        private void clientEnter(Client client)
        {
            if (Password.Password == client.Password)
            {
                MainWindow main = new MainWindow();
                MainPage mainPage = new MainPage();
                mainPage.DataContext = client;
                main.Navigate(mainPage);
                main.Show();
                App.Current.MainWindow = main;
                this.Close();
            }
            else
            {
                CustomMessageBox box = new CustomMessageBox("Ошибка", "Не правильный пароль");
                box.ShowDialog();
            }
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            try
            {
                reg.ShowDialog();
            }
            catch (Exception)
            {
                this.Close();
            }
            
        }
    }
}
