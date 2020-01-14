using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.Entities;

namespace MosiacData.Models
{
    public class OrderDto
    {
        public int PurchaseOrderID { get; set; }
        public string OrderDate { get; set; }   
        public string Supplier { get; set; }
        public string Purchaser { get; set; }
        public string JobName { get; set; }
        public string OrderTotal { get; set; }
        public bool Received { get; set; }

    }
}
