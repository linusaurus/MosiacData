using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MosiacData.Services
{
    public class DropDownTuple
    {
        public string value { get; set; }
        public string label { get; set; }

        public override string ToString()
        {
            return $"{nameof(value)}: {value}, {nameof(label)}: {label}";
        }
    }
}
