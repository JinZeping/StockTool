using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StockApp.DB;

namespace StockApp
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
                Log.Info("程序启动");

                new MainWindow().Show();
            }
            catch (Exception ex)
            {
                Log.Fatal("程序发生致命错误");
                Log.Exception(ex);
            }
            finally
            {
                Log.Info("程序退出");
            }
        }
    }
}
