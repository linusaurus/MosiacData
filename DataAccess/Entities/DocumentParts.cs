using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class DocumentParts
    {
        public int PartId { get; set; }
        public int DocId { get; set; }

        public virtual Document Doc { get; set; }
        public virtual Part Part { get; set; }
    }
}
