using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class OrdreProduction
    {
        public int NumOrdre { get; set; }
        public int NumBon { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Periode { get; set; }
        public int CodeDemandeur { get; set; }

        public virtual Intervenant CodeDemandeurNavigation { get; set; }
        public virtual BonProduction NumBonNavigation { get; set; }
        public virtual PeriodeProduction PeriodeNavigation { get; set; }
    }
}
