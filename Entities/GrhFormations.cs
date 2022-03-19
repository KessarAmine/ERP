using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class GrhFormations
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        public string Description { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public double? Cout { get; set; }
        public double? CapitalHumain { get; set; }
    }
}
