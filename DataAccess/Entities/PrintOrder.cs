using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class PrintOrder
    {
        public int OrderNum { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? UnitCost { get; set; }
        public int? PartId { get; set; }
        public string Description { get; set; }
        public int LineId { get; set; }
        public decimal? Extended { get; set; }
        public decimal? Qnty { get; set; }
        public string SupplierName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public string Firstname { get; set; }
        public int? Jobnumber { get; set; }
        public string Jobname { get; set; }
        public decimal? OrderTotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? ShippingCost { get; set; }
        public decimal? SubTotal { get; set; }
        public string Memo { get; set; }
    }
}
