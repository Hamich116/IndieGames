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

namespace IndieGames.windows.pages
{
    /// <summary>
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        public PaymentPage()
        {
            InitializeComponent();
        }

        private void ToMainPage(object sender, RoutedEventArgs e)
        {
            ((MainPage)App.Current.MainWindow.Content).frameContent.Content = null;
        }

        private void Cvc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            else
            {
                if (textBox.Text.Length > 2)
                {
                    e.Handled = true;
                }
            }
        }

        private void digits4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            else
            {
                if (textBox.Text.Length > 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!Char.IsUpper(e.Text, 0))
            {
                e.Handled = true;
            }
            else
            {
                if (textBox.Text.Length > 30)
                {
                    e.Handled = true;
                }
            }
        }

        private void dayMonth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            else
            {
                if (textBox.Text.Length > 3)
                {
                    e.Handled = true;
                }
            }
        }

        private void sum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            else
            {
                if (textBox.Text.Length > 4)
                {
                    e.Handled = true;
                }
            }
        }

        private void Replenish(object sender, RoutedEventArgs e)
        {
            if (cvc.Text.Length == 3 && first4.Text.Length == 4 && second4.Text.Length == 4 && third4.Text.Length == 4 &&
                fourth4.Text.Length == 4 && nameClient.Text.Length > 5 && dayMonth.Text.Length == 4)
            {
                Client client;
                gamesStoreEntities context = new gamesStoreEntities();
                try
                {
                    client = context.Clients.Find(((Client)DataContext).Id);
                }
                catch (Exception)
                {
                    new CustomMessageBox("Ошибка", "Не удалось подключиться к серверу! Попробуйте позже!").ShowDialog();
                    return;
                }
                
                if (sum.Text != "")
                {
                    bool isDigit = false;
                    foreach (var character in sum.Text)
                    {
                        if (!char.IsDigit(character))
                        {
                            isDigit = false;
                            break;
                        }
                        else
                        {
                            isDigit = true;
                        }
                    }
                    if (isDigit)
                    {
                        if (client.Balance.HasValue)
                        {
                            try
                            {
                                client.Balance = client.Balance.Value + Convert.ToInt32(sum.Text);
                            }
                            catch (Exception)
                            {

                                new CustomMessageBox("Ошибка", "Вы ввели слишком огромное число!");
                                return;
                            }
                            
                        }
                        else
                        {
                            client.Balance = 0;
                            try
                            {
                                client.Balance = client.Balance.Value + Convert.ToInt32(sum.Text);
                            }
                            catch (Exception)
                            {
                                new CustomMessageBox("Ошибка", "Вы ввели слишком огромное число!");
                                return;
                            }
                            
                        }
                        try
                        {
                            context.SaveChanges();
                        }
                        catch (Exception)
                        {
                            new CustomMessageBox("Ошибка", "Не удалось подключиться к серверу! Попробуйте позже!").ShowDialog();
                            return;
                        }
                        
                        ((MainPage)App.Current.MainWindow.Content).DataContext = client;
                        ((MainPage)App.Current.MainWindow.Content).frameContent.Content = null;
                    }
                    else
                    {
                        new CustomMessageBox("Ошибка", "Вы ввели не число!").ShowDialog();
                    }
                    
                }
                else
                {
                    new CustomMessageBox("Не введена сумма", "Введите сумму на которую хотите пополнить").ShowDialog();
                }
                
            }
            else
            {
                new CustomMessageBox("Проблемы с картой", "перепровертьте свои данные").ShowDialog();
            }
        }
    }
}
