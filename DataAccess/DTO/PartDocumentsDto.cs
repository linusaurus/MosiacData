using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MosiacData.DBContexts.Entities;
using MosiacData.Models;

namespace MosiacData.Models
{
    public class PartDocumentsDto
    {
        [Display(Name ="Doc#")]
        public int DocID { get; set; }
        public int PartID { get; set; }
        [Display(Name ="Document Description")]
        public string Description { get; set; }
        [Display(Name ="View")]
        public string DocumentView { get; set; }
        public string Path { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Created On")]
        public DateTime DateCreated { get; set; }
        [Display(Name ="Creator")]
        public string Creator { get; set; }
    }

}
