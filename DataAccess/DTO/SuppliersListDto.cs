using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.DBContexts.Entities;
using MosiacData.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MosiacData.Models
{
    public class SuppliersListDto
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal OrderTotals { get; set; }
    }
}
