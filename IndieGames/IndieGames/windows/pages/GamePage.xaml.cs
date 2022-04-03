using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;
using Vlc.DotNet.Wpf;
using Vlc.DotNet.Core;
using IndieGames.windows;
using IndieGames.windows.pages;
using System.Threading;
using System.Runtime.ExceptionServices;

namespace IndieGames
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    /// 
    
    public partial class GamePage : Page
    {
        private bool isPause = false;
        private DirectoryInfo vlcLibDirectory;
        private VlcControl control;
        private string trailer;
        private Uri link;
        MainPage mainPage = (MainPage)App.Current.MainWindow.Content;
        Client client;
        public GamePage(string trailer, bool isEnable, Client client)
        {
            this.client = client;
            this.trailer = trailer;
            
            
            InitializeComponent();
            
            buyButton.IsEnabled = isEnable;
        }
        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            if (isPause)
            {
                control.SourceProvider.MediaPlayer.Pause();
                pause.Text = "Пауза";
                isPause = false;
            }
            else
            {
                control.SourceProvider.MediaPlayer.Pause();
                pause.Text = "Продолжить";
                isPause = true;
            }
            
        }
        
        
        private void Back_MouseEnter(object sender, MouseEventArgs e)
        {
            back.Foreground = Brushes.White;
            back.FontWeight = FontWeights.Bold;
        }

        private void Back_MouseLeave(object sender, MouseEventArgs e)
        {
            back.Foreground = Brushes.Gray;
            back.FontWeight = FontWeights.Normal;
        }

        private void Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
        
        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Game game = (Game)button.DataContext;
            try
            {
                Client client = mainPage.context.Clients.Find(this.client.Id);
                if (client.Balance.HasValue)
                {
                    if (client.Balance >= game.Cost)
                    {
                        client.Balance -= game.Cost;
                        client.ClientsAndGames.Add(new ClientsAndGame
                        {
                            Client = client,
                            Game = game,
                        });

                        ((MainPage)App.Current.MainWindow.Content).DataContext = client;
                        InvoicePage invoicePage = new InvoicePage(client.Login);
                        invoicePage.DataContext = game;
                        mainPage.context.SaveChanges();
                        NavigationService.Navigate(invoicePage);
                    }
                    else
                    {
                        new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Перезапустите программу!").ShowDialog();
                        
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

        private void ResetVideo(object sender, MouseButtonEventArgs e)
        {
            control.SourceProvider.MediaPlayer.ResetMedia();
            if (link == null)
            {
                new CustomMessageBox("Ошибка", "Не удалось подключиться к серверу! Попробуйте позже!").ShowDialog();
            }
            else
            {
                control.SourceProvider.MediaPlayer.Play(link);
            }
            pause.Text = "Пауза";
            isPause = false;
        }

        private void Pause_MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (isPause)
            {
                control.SourceProvider.MediaPlayer.Pause();
                pause.Text = "Пауза";
                isPause = false;
            }
            else
            {
                control.SourceProvider.MediaPlayer.Pause();
                pause.Text = "Продолжить";
                isPause = true;
            }
        }

        private void Play(object sender, MouseButtonEventArgs e)
        {
            if (link != null)
            {
                if (link.ToString() == "https://fail/")
                {
                    new CustomMessageBox("Трейлер отсутствует", "У данной игры нет трейлера").ShowDialog();
                }
                else
                {
                    control.SourceProvider.MediaPlayer.Play(link);
                }
            }
            
            else
            {
                new CustomMessageBox("Ошибка", "подождите несколько секунд и снова нажмите на кнопку").ShowDialog();
            }
            
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            control.SourceProvider.MediaPlayer.Audio.ToggleMute();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            // Default installation path of VideoLAN.LibVLC.Windows
            var currentAssembly = Assembly.GetEntryAssembly(); // получение сборки приложения
            string currentDirectory = "";
            currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName; // получение месторасположения библиотеки vlc
            vlcLibDirectory = new DirectoryInfo(System.IO.Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64")); //выбор версии vlc
            this.control?.Dispose();
            this.control = new VlcControl();
            this.control.SourceProvider.CreatePlayer(this.vlcLibDirectory);
            // This can also be called before EndInit
            this.control.SourceProvider.MediaPlayer.Log += (_, args) =>
            {
                string message = args.Message + " " + args.Module;
                if (args.Message.Remove(4) == "Path")
                {
                    link = new Uri(args.Message.Substring(5));
                }
            };
            if (trailer != "")
            {
                try
                {
                    control.SourceProvider.MediaPlayer.SetMedia(new Uri(trailer));
                }
                catch (Exception)
                {
                    return;
                }

                control.SourceProvider.MediaPlayer.Play();
                this.ControlContainer.Content = this.control;
            }
            else
            {
                link = new Uri("https://fail");
            }
            Thread.Sleep(1500);
            this.IsEnabled = true;
            if (link != null)
            {
                control.SourceProvider.MediaPlayer.Play(link);
            }
        }
    }
}
