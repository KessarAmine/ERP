using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdArretsProgramme
    {
        public DateTime DateArret { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public double? Duree { get; set; }
    }
}
