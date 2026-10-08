using System;
using System.Windows;
using NexaRetail.Views;

namespace NexaRetail
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
        }
    }
}