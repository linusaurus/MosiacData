using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;


namespace MosiacData.Entities
{
    public class DocumentParts
    {
        public int PartID { get; set; }
        public int DocID { get; set; }

        public Part Parts { get; set; }
        public Document Documents { get; set; }
    }
}
