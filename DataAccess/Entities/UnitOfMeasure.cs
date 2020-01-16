using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure()
        {
            Part = new HashSet<Part>();
        }

        public int Uid { get; set; }
        public string Uom { get; set; }

        public virtual ICollection<Part> Part { get; set; }
    }
}
