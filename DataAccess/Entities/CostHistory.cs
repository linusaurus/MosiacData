﻿using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class CostHistory
    {
        public int CostChangeId { get; set; }
        public string User { get; set; }
        public int? PartId { get; set; }
        public decimal? UpdatedUnitCost { get; set; }
        public decimal? UpdatedUoPcost { get; set; }
        public string UoP { get; set; }
        public DateTime? DateStamp { get; set; }
    }
}
