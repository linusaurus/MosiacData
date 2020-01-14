using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.Entities;
using MosiacData.DBContexts;
using System.ComponentModel.DataAnnotations;

namespace MosiacData.Models
{
    public class JobDetailsDto
    {
        public JobDetailsDto()
        {
            JobID = 0;
            JobName = String.Empty;
            JobCostName = String.Empty;
            JobOrdersTotal = 0.0m;
            JobLaborTotal = 0.0;
        }

        public int JobID { get; set; }
        [Display(Name ="Job Name")]
        public string JobName { get; set; }
        [Display(Name ="Job Costing Name")]
        public string JobCostName { get; set; }
        [Display(Name ="Job Orders")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal JobOrdersTotal { get; set; }
        [Display(Name ="Job Hours")]
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        public double JobLaborTotal { get; set; }
        public ICollection<Product> JobItems { get; set; } = new HashSet<Product>();
        public ICollection<OrderDto> JobOrders { get; set; }
    }
}
