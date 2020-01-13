using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PurchaseSQLDB.DataAccess;
using PurchaseSQLDB.DataAccess.Services;
using PurchaseWeasel_7.ViewModels;
using Autofac;
using PurchaseWeasel_7.Startup;

namespace PurchaseWeasel_7
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            PurchaseOrderService service = new PurchaseOrderService();

            var model = new MainViewModel(service);
            var mainWindow = new MainWindow(model);          
            mainWindow.Show();    
         }

        
    }
}

