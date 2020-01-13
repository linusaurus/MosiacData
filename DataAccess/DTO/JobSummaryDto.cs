using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.DBContexts.Entities;
using MosiacData.DBContexts;



namespace MosiacData.Models
{
    public class JobSummaryDto
    {
        public int JobID { get; set; }
        public string Jobname { get; set; }
        public string JobDescription { get; set; }
        public DateTime JobStartDate { get; set; }
        public bool Active { get; set; }
        public decimal JobOrdersTotal { get; set; }
        public decimal JobHoursTotal { get; set; }
        public ICollection<OrderDto> JobOrders{ get; set; }
    }
}
