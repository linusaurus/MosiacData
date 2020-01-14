using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MosiacData.Entities
{
    public class ClaimDocument
    {
        public int ClaimDocumentID { get; set; }
        public string DocumentDesciption { get; set; }
        public string DocumentExtension { get; set; }
        public int? ClaimItemID { get; set; }

        public ClaimItem ClaimItem { get; set; }
    }
}
