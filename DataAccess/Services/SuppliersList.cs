using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.Entities;
using MosiacData.DBContexts;

namespace MosiacData.Services
{
    public class SuppliersList 
    {
        private readonly BadgerContext _db;

        public SuppliersList(BadgerContext context)
        {
            _db = context;
        }

        public IEnumerable<DropDownTuple> GetFilterDropDownValues(string search)
        {
            var result = _db.Supplier                         
                                                    
                         .Where(x => x.SupplierName.Contains(search))                              
                         .Select(x => new DropDownTuple             
                        {                                           
                            value = x.SupplierId.ToString(),                   
                            label = x.SupplierName.ToString()                     
                        }).ToList();

            return result;
        }

    }
}
