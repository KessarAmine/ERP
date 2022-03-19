using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class DemandeFournitureModel
    {
        public DateTime DateBesoin { get; set; }
        public int CodeNatureDemande { get; set; }
        public DateTime DateDemande { get; set; }
        public string MotifDemande { get; set; }
        public string Obeservations { get; set; }
        public int? Destination { get; set; }
    }
}
