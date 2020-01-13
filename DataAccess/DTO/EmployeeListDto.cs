using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.DBContexts.Entities;
using MosiacData.Models;

namespace MosiacData.Models
{
    public class EmployeeListDto
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public bool IsPurchaser { get; set; }
        public string Email { get; set; }
       
       
    }
}
