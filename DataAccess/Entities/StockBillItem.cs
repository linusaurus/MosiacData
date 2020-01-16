using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class StockBillItem
    {
        public int StockItemId { get; set; }
        public int? StockBillD { get; set; }
        public int? PartId { get; set; }
        public int? LineItemSourceId { get; set; }
        public decimal? Qnty { get; set; }
        public string Description { get; set; }

        public virtual StockBill StockBillDNavigation { get; set; }
    }
}
