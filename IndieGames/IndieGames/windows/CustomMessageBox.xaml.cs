﻿using System;
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
using System.Windows.Shapes;

namespace IndieGames.windows
{
    /// <summary>
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();
            this.Title = "ошибка";
        }
        
        public CustomMessageBox(string heading, string message) : this(message)
        {
            this.Title = heading;
            this.message.Text = message;
        }


        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
