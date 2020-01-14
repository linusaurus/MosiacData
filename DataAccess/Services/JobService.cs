using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.Entities;
using MosiacData.DBContexts;

namespace MosiacData.Services
{
    public class JobService
    {
        private readonly PurchaseSQLDBContext _db;

        public JobService(PurchaseSQLDBContext context)
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
