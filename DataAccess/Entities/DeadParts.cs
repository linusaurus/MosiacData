using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class DeadParts
    {
        public int PartId { get; set; }
        public string ItemDescription { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
