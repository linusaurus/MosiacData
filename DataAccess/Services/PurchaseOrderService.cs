using MosiacData.DBContexts.Entities;
using MosiacData.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PurchaseSQLDB.DataAccess.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
       

        public PurchaseOrderService()
        {
            
        }

       
        public List<PurchaseOrder> GetAll()
        {
            List<PurchaseOrder> result = new List<PurchaseOrder>();

            using (var context = new PurchaseSQLDBContext())
            {

                result = context.PurchaseOrder.AsNoTracking().ToList();
            }
            return result;
            
        }
    }
}
