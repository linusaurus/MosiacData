using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseSQLDB.DataAccess.Services;
using PurchaseSQLDB.DataAccess.EFClasses;
using System.ComponentModel;

namespace PurchaseWeasel_7.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        
        

        private IPurchaseOrderService _purchaseOrderService;
        private PurchaseOrder _selectedPurchaseOrder;

        public MainViewModel(IPurchaseOrderService purchaseOrderService)
        {
            PurchaseOrders = new List<PurchaseOrder>();
            _purchaseOrderService = purchaseOrderService;

        }

        public void Load()
        {

            //PurchaseOrders.Clear();
            PurchaseOrders.Add(new PurchaseOrder() { OrderDate = DateTime.Today, OrderNum = 1102, SupplierID = 123, EmployeeID = 8, OrderTotal = 12.35m });

           PurchaseOrders = _purchaseOrderService.GetAll();
           
        }

        public List<PurchaseOrder> PurchaseOrders { get; set; }

        public PurchaseOrder SelectedOrder
        {
            get { return _selectedPurchaseOrder; }
            set {
                _selectedPurchaseOrder = value;
                OnPropertyChanged();
            }
        }


       
    }
}
