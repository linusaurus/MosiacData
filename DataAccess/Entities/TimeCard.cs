using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;



namespace MosiacData.Entities
{
    public class TimeCard
    {

        [Key]
        public int timecard_id { get; set; }
        public int job_id { get; set; }
        public double total_hr { get; set; }
    }
}
