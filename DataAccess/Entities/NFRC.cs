using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.DBContexts.Entities;

namespace MosiacData.DBContexts.Entities
{
    public class NFRC
    {
        public int CPD_ID { get; set; }
        public string CPD { get; set; }
        public double? GroupID { get; set; }
        public string ManufacturerProductCode { get; set; }
        public string FrameSashType { get; set; }
        public double? Ufactor { get; set; }
        public double? SHGC { get; set; }
        public double? VT { get; set; }
        public double? CondensationResistance { get; set; }
        public double? GlazingLayers { get; set; }
        public string LowE { get; set; }
        public double? GapWidths { get; set; }
        public string Spacer { get; set; }
        public string GapFill { get; set; }
        public string Grid { get; set; }
        public double? Divider { get; set; }
        public string Tint { get; set; }
        public int? SystemID { get; set; }
        public string GlassName { get; set; }
        public string UnitType { get; set; }
        public string SystemName { get; set; }
        public string ProductDescription { get; set; }
    }
}
