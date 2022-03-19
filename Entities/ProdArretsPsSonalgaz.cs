using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdArretsPsSonalgaz
    {
        public int Id { get; set; }
        public DateTime? DateArret { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public double Duree { get; set; }
        public string Cause { get; set; }
        public int NbrCisaillees { get; set; }
    }
}
