using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproDemandesFourniture
    {
        public int NumeroDemande { get; set; }
        public int CodeServiceDemandeur { get; set; }
        public DateTime DateBesoin { get; set; }
        public string Status { get; set; }
        public DateTime DateDemande { get; set; }
        public string Obeservations { get; set; }
        public int? Destination { get; set; }
    }
}
