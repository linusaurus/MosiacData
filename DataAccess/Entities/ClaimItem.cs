﻿using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class ClaimItem
    {
        public ClaimItem()
        {
            ClaimDocument = new HashSet<ClaimDocument>();
        }

        public int ClaimItemId { get; set; }
        public int? ClaimId { get; set; }
        public int? LineId { get; set; }
        public int? PartId { get; set; }
        public string Bcode { get; set; }
        public string Description { get; set; }
        public int? TransActionType { get; set; }
        public int? ProductId { get; set; }
        public string DefectDescription { get; set; }

        public virtual ICollection<ClaimDocument> ClaimDocument { get; set; }
    }
}
