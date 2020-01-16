using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class Inventory
    {
        public int StockTransactionId { get; set; }
        public int? OrderReceiptId { get; set; }
        public int? LineId { get; set; }
        public int? PartId { get; set; }
        public int? StockBillId { get; set; }
        public int? JobId { get; set; }
        public string Location { get; set; }
        public int? ArticleId { get; set; }
        public DateTime? DateStamp { get; set; }
        public decimal? Qnty { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public int? UnitOfMeasure { get; set; }
        public int? TransActionType { get; set; }
        public int? EmpId { get; set; }

        public virtual OrderReciept OrderReceipt { get; set; }
        public virtual StockBill StockBill { get; set; }
    }
}
