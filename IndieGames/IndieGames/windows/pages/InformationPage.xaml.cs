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
    /// Логика взаимодействия для InformationPage.xaml
    /// </summary>
    public partial class InformationPage : Page
    {
        AdminPage adminPage = (AdminPage)App.Current.MainWindow.Content;
        bool check;
        public InformationPage(bool check)
        {
            InitializeComponent();
            this.check = check;
            if (check)
            {
                addOrChange.Text = "Изменить";
            }
            else
            {
                addOrChange.Text = "Добавить";
            }
            try
            {
                studioBox.ItemsSource = adminPage.context.Studios.ToList();
                categoryBox.ItemsSource = adminPage.context.Categories.ToList();
            }
            catch (Exception)
            {
                new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Проверьте интернет соединение!").ShowDialog();
                return;
            }
        }

        private void AddChange(object sender, RoutedEventArgs e)
        {
            if (check)
            {
                Game game = (Game)this.DataContext;
                Game g;
                try
                {
                    g = adminPage.context.Games.Where(gam => gam.Name == nameBox.Text).FirstOrDefault();
                }
                catch (Exception)
                {
                    new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Проверьте интернет соединение!").ShowDialog();
                    return;
                }
                
                Studio s = studioBox.SelectedItem as Studio;
                Category c = categoryBox.SelectedItem as Category;
                if (g.Name == game.Name)
                {
                    Verification(s, c);
                }
                else
                {
                    if (g != null)
                    {
                        new CustomMessageBox("Ошибка", "такое название игры уже существуют").ShowDialog();
                    }
                    else
                    {
                        Verification(s, c);
                    }
                }
            }
            else
            {
                Game g;
                try
                {
                    g = adminPage.context.Games.Where(game => game.Name == nameBox.Text).FirstOrDefault();
                }
                catch (Exception)
                {
                    new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Проверьте интернет соединение!").ShowDialog();
                    return;
                }
                
                Studio s = studioBox.SelectedItem as Studio;
                Category c = categoryBox.SelectedItem as Category;

                if (g != null)
                {
                    new CustomMessageBox("Ошибка", "такое название игры уже существуют").ShowDialog();
                }
                else
                {
                    if (nameBox.Text != "")
                    {
                        if (s == null && c == null)
                        {
                            new CustomMessageBox("Ошибка", "студия или категория не выбраны").ShowDialog();
                        }
                        else
                        {
                            bool isDigit = false;
                            foreach (var character in costBox.Text)
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
                                Game newGame = new Game
                                {
                                    Name = nameBox.Text,
                                    Studio = (Studio)studioBox.SelectedItem,
                                    Category = (Category)categoryBox.SelectedItem,
                                    Image = imageBox.Text,
                                    Description = descriptionBox.Text,
                                    Cost = Convert.ToInt32(costBox.Text),
                                    Trailer = trailerBox.Text,
                                    MagnetUri = magnetBox.Text,
                                };
                                try
                                {
                                    adminPage.context.Games.Add(newGame);
                                    adminPage.context.SaveChanges();
                                }
                                catch (Exception)
                                {
                                    new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Проверьте интернет соединение!").ShowDialog();
                                    return;
                                }
                                nameBox.Text = "";
                                studioBox.SelectedItem = null;
                                categoryBox.SelectedItem = null;
                                imageBox.Text = "";
                                descriptionBox.Text = "";
                                costBox.Text = "";
                                trailerBox.Text = "";
                                magnetBox.Text = "";
                                new CustomMessageBox("Поздравляем", "Игра успешно добавлена").ShowDialog();
                            }
                            else
                            {
                                new CustomMessageBox("Ошибка", "Вы ввели не число").ShowDialog();
                            }

                        }
                    }
                    else
                    {
                        new CustomMessageBox("Ошибка", "Вы не ввели название игры").ShowDialog();
                    }
                }

            }
        }

        private void Verification(Studio s, Category c)
        {
            Game game = (Game)this.DataContext;
            if (nameBox.Text != "")
            {
                if (s == null && c == null)
                {
                    new CustomMessageBox("Ошибка", "студия или категория не выбраны").ShowDialog();
                }
                else
                {
                    bool isDigit = false;
                    foreach (var character in costBox.Text)
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
                        game.Name = nameBox.Text;
                        game.Studio = (Studio)studioBox.SelectedItem;
                        game.Category = (Category)categoryBox.SelectedItem;
                        game.Image = imageBox.Text;
                        game.Description = descriptionBox.Text;
                        game.Cost = Convert.ToInt32(costBox.Text);
                        game.Trailer = trailerBox.Text;
                        game.MagnetUri = magnetBox.Text;
                        try
                        {
                            adminPage.context.SaveChanges();
                        }
                        catch (Exception)
                        {
                            new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Проверьте интернет соединение!").ShowDialog();
                            return;
                        }
                        
                        new CustomMessageBox("Поздравляем", "Изменение приняты").ShowDialog();
                    }
                    else
                    {
                        new CustomMessageBox("Ошибка", "Вы ввели не число").ShowDialog();
                    }

                }
            }
            else
            {
                new CustomMessageBox("Ошибка", "Вы не ввели название игры").ShowDialog();
            }
        }

        private void ToBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void costBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void AddStudioAndCategory(object sender, RoutedEventArgs e)
        {
            Studio s = (Studio) studioBox.SelectedItem;
            Category c = (Category) categoryBox.SelectedItem;
            if (s == null)
            {
                if (studioBox.Text != "")
                {
                    Studio studio = new Studio
                    {
                        Name = studioBox.Text,
                    };
                    try
                    {
                        adminPage.context.Studios.Add(studio);
                        adminPage.context.SaveChanges();
                        studioBox.ItemsSource = adminPage.context.Studios.ToList();
                    }
                    catch (Exception)
                    {
                        new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Проверьте интернет соединение!").ShowDialog();
                        return;
                    }
                    
                    studioBox.SelectedItem = studio;
                }
            }
            if (c == null)
            {
                if (categoryBox.Text != "")
                {
                    Category category = new Category
                    {
                        Name = categoryBox.Text,
                    };
                    try
                    {
                        adminPage.context.Categories.Add(category);
                        categoryBox.ItemsSource = adminPage.context.Categories.ToList();
                        adminPage.context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        new CustomMessageBox("Ошибка", "Произошла непредвиденная ошибка! Проверьте интернет соединение!").ShowDialog();
                        return;
                    }
                    categoryBox.SelectedItem = category;
                }
            }
        }
    }
}
