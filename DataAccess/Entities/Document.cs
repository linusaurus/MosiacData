using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;


namespace MosiacData.Entities
{
    public class Document
    {
       

        public int DocID { get; set; }
        public string Description { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentView { get; set; }
        public int PartID { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Creator { get; set; }

        public ICollection<DocumentParts> DocumentsLink { get; set; } = new HashSet<DocumentParts>();
    }
}
