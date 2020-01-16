using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class Document
    {
        public Document()
        {
            DocumentParts = new HashSet<DocumentParts>();
        }

        public int DocId { get; set; }
        public string Description { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentView { get; set; }
        public int? PartId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Creator { get; set; }

        public virtual ICollection<DocumentParts> DocumentParts { get; set; }
    }
}
