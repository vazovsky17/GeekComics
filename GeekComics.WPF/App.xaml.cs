﻿using System.Windows;
using GeekComics.WPF.ViewModels;

namespace GeekComics.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            window.Show();
            base.OnStartup(e);
        }
    }
}
