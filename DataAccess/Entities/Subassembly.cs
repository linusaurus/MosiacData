using System;
using System.Collections.Generic;

namespace MosiacData.Entities
{
    public partial class SubAssembly
    {
        public int SubAssemblyId { get; set; }
        public string SubAssemblyName { get; set; }
        public int? AssemblyId { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Depth { get; set; }
        public string MakeFile { get; set; }
        public decimal? Perimeter { get; set; }
        public decimal? Area { get; set; }
        public decimal? Weight { get; set; }
        public decimal? CompositeCost { get; set; }
        public decimal? LaborHr { get; set; }
        public string UnitType { get; set; }
        public int? GlassId { get; set; }
        public string FrameSashType { get; set; }
        public int? CpdId { get; set; }
        public string SystemName { get; set; }
    }
}
