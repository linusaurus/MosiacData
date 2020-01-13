using Autofac;
using PurchaseSQLDB.DataAccess.Services;
using PurchaseWeasel_7.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseWeasel_7.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<PurchaseOrderService>().As<IPurchaseOrderService>();

            return builder.Build();

        }

    
    }
}
