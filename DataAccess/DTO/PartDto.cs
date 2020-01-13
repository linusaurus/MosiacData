using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.DBContexts.Entities;
using System.ComponentModel.DataAnnotations;

namespace MosiacData.Models
{
    public class PartDto
    {
        public int PartID { get; set; }
        public string Description { get; set; }   
        public string PartNumber { get; set; }
        public string Location { get; set; }
        public string SKU { get; set; }
        public decimal UnitInStock { get; set; }
    }
}
