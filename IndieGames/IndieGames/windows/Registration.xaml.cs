using IndieGames.windows;
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
    public partial class Registration : Window
    {
        gamesStoreEntities context;
        bool uniqLogin;
        bool havePassword;
        public Registration()
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

        private void Registrate(object sender, RoutedEventArgs e)
        {
            if (uniqLogin)
            {
                if (havePassword)
                {
                    Client client = new Client
                    {
                        Login = Login.Text,
                        Password = Password.Password,
                        IsAdministration = false,
                        Balance = 0,
                    };
                    context.Clients.Add(client);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        new CustomMessageBox("Потеряно соединение", "Пожалуйста, перепроверьте соединение с интернетом и запустите программу еще раз").ShowDialog();
                        this.Close();
                    }
                    
                    this.Close();
                }
                else
                {
                    new CustomMessageBox("Ошибка", "Ваш пароль не совпадает").ShowDialog();
                }
            }
            else
            {
                new CustomMessageBox("Ошибка","Ваш логин не уникален").ShowDialog();
            }
            
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Checking(object sender, TextChangedEventArgs e)
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
                if (client.Login != null)
                {
                    Resources["check"] = new BitmapImage(new Uri("/resources/cross.png", UriKind.Relative));
                    uniqLogin = false;
                }
                
            }
            else
            {
                if (Login.Text != "")
                {
                    Resources["check"] = new BitmapImage(new Uri("/resources/done.png", UriKind.Relative));
                    uniqLogin = true;
                }
                else
                {
                    Resources["check"] = new BitmapImage(new Uri("/resources/cross.png", UriKind.Relative));
                }
            }
            checkingPic.Visibility = Visibility.Visible;
        }
        private void CheckPassword()
        {
            if (Password.Password != "")
            {
                if (Password.Password == PasswordAgain.Password)
                {
                    Resources["checkPassword"] = new BitmapImage(new Uri("/resources/done.png", UriKind.Relative));
                    havePassword = true;
                }
                else
                {
                    Resources["checkPassword"] = new BitmapImage(new Uri("/resources/cross.png", UriKind.Relative));
                    havePassword = false;
                }
            }
            else
            {
                checkingPassword.Visibility = Visibility.Hidden;
            }
        }
        private void CheckingPassword(object sender, RoutedEventArgs e)
        {
            CheckPassword();
            checkingPassword.Visibility = Visibility.Visible;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckPassword();
        }

        private void TextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!Char.IsLetterOrDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void PasswordBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            PasswordBox textBox = (PasswordBox)sender;
            if (!Char.IsLetterOrDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
