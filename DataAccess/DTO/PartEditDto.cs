using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MosiacData.DBContexts.Entities;
using MosiacData.Models;

namespace MosiacData.Models
{
    public class PartEditDto
    {
        public PartEditDto()
        {
            ManuID = 1;

        }

        [Required]
        [Display(Name="Part#")]
        public int PartID { get; set; }
        [Required(ErrorMessage ="You have to have some description")]
        [StringLength(512)]
        [Display(Name ="Item Description")]
        public string Description { get; set; }
        [Display(Name ="Item Name")]
        public string ItemName { get; set; }
        
        public string PartNumber { get; set; }
        [Display(Name ="Location")]
        public string Location { get; set; }
        public string SKU { get; set; }
        
        [Required]
        public int? ManuID { get; set; }
        [Display(Name ="Manufacturer Part#")]
        public string ManuPartNum { get; set; }
        [Display(Name ="Manufacturer")]
        public string Manufacturer { get; set; }

        //public int PartTypeID { get; set; }
        //public string PartTypeName { get; set; }
        [Display(Name ="Supplier#")]
        public int SupplierID { get; set; }
        [Display(Name ="Supplier Name")]
        public string SupplierName { get; set; }
        [Display(Name ="Suppliers Part Name")]
        public string SupplierDescription { get; set; }
        [Display(Name ="Use Supplier Name")]
        public bool UseSupplierName { get; set; }

        public int UID { get; set; }
        public string UnitOfMeasure { get; set; }

        //--Cutlisting Specific
       //[DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Cost { get; set; }
        public decimal Weight { get; set; }
        public decimal Waste { get; set; }
        public decimal MarkUp { get; set; } 

        //--Auditing
        [DataType(DataType.Date)]
        [Display(Name ="Date Added")]
        public DateTime? DateAdded { get; set; }
        [Display(Name ="Created By")]
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Last Modified")]
        public DateTime? LastModified { get; set; }
        [Display(Name ="Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name ="Stock On Hand")]
        public decimal StockOnHand { get; set; }

        public List<PartDocumentsDto> Documents { get; set; }


    }
}
