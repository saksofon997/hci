using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                var log = new Login.Login();

                if (log.ShowDialog() == true)
                {
                    new MainWindow().ShowDialog();
                }
            }
            finally
            {
                Shutdown();
            }
        }
    }
}
