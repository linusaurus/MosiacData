using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MosiacData.DBContexts;

namespace MosiacData.Models
{
    public class OrderDetailDto
    {
        [Key]
        public int PurchaseOrderID { get; set; }
        public int JobID { get; set; }
        public string JobName { get; set; }
        public string JobCostName { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{###.###.####}")]
        public string SupplierPhone { get; set; }
        public string Purchaser { get; set; }
       
        public string OrderDate { get; set; }
    
        public string ExpectedDate { get; set; }
    
        public decimal OrderTotal { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierState { get; set; }
        public string SupplierZip { get; set; }
        public string ShippingMethod { get; set; }
        public bool Taxable { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Tax { get; set; }
   
        public decimal SubTotal { get; set; }

        public ICollection<LineItemDto> LineItems { get; set; }



    }
}
