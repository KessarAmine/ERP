using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class DemandeTravail
    {
        public DemandeTravail()
        {
            OrdreTravail = new HashSet<OrdreTravail>();
        }

        public int NumDt { get; set; }
        public DateTime DateDt { get; set; }
        public bool CodeUrgence { get; set; }
        public string TravailDemandee { get; set; }
        public int CodeStructure { get; set; }
        public int CodeStatut { get; set; }
        public bool CodeArret { get; set; }
        public bool? Journee { get; set; }
        public bool? Semaine { get; set; }
        public string RefMachine { get; set; }
        public int? CodeReceveur { get; set; }
        public string Note { get; set; }
        public bool? IsMachine { get; set; }
        public int? DemandeurOpt { get; set; }
        public string MachineOptionel { get; set; }

        public virtual ArreteProduction CodeArretNavigation { get; set; }
        public virtual Statut CodeStatutNavigation { get; set; }
        public virtual Structure CodeStructureNavigation { get; set; }
        public virtual UrgenceTravaille CodeUrgenceNavigation { get; set; }
        public virtual ICollection<OrdreTravail> OrdreTravail { get; set; }
    }
}
