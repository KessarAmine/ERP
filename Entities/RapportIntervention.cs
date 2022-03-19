using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class RapportIntervention
    {
        public int NumIntervention { get; set; }
        public DateTime DateIntervention { get; set; }
        public DateTime DebutIntervention { get; set; }
        public int DureeIntervention { get; set; }
        public string Observation { get; set; }
        public string CompteRendu { get; set; }
        public int NumOt { get; set; }

        public virtual OrdreTravail NumOtNavigation { get; set; }
    }
}
