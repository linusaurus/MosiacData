using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class StockBill
    {
        public StockBill()
        {
            Inventory = new HashSet<Inventory>();
            StockBillItem = new HashSet<StockBillItem>();
        }

        public int StockBillId { get; set; }
        public int? JobId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? StockBillDate { get; set; }
        public decimal? ItemTotal { get; set; }
        public bool? Submitted { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<StockBillItem> StockBillItem { get; set; }
    }
}
