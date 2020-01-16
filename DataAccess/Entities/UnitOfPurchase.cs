using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class UnitOfPurchase
    {
        public int UoPid { get; set; }
        public int PartId { get; set; }
        public int? Uid { get; set; }
        public string Uopname { get; set; }
        public decimal? UopcostUnit { get; set; }
        public decimal? Uopratio { get; set; }

        public virtual Part Part { get; set; }
    }
}
