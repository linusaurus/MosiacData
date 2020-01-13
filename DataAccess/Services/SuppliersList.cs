using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.DBContexts.Entities;
using MosiacData.DBContexts;

namespace Weaselware.Lemur.Services
{
    public class SuppliersList 
    {
        private readonly PurchaseSQLDBContext _db;

        public SuppliersList(PurchaseSQLDBContext context)
        {
            _db = context;
        }

        public IEnumerable<DropDownTuple> GetFilterDropDownValues(string search)
        {
            var result = _db.Supplier                         
                                                    
                         .Where(x => x.SupplierName.Contains(search))                              
                         .Select(x => new DropDownTuple             
                        {                                           
                            value = x.SupplierID.ToString(),                   
                            label = x.SupplierName.ToString()                     
                        }).ToList();

            return result;
        }

    }
}
