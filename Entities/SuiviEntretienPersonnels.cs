using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class SuiviEntretienPersonnels
    {
        public int IdEntretien { get; set; }
        public int IdEmployee { get; set; }
        public string Sujet { get; set; }
        public string Lieu { get; set; }
        public string Explication { get; set; }
        public string Observation { get; set; }
        public DateTime Date { get; set; }
        public int Poste { get; set; }
        public DateTime DateIncidant { get; set; }
    }
}
