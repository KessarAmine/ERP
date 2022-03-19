using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class OrdreTravail
    {
        public OrdreTravail()
        {
            RapportIntervention = new HashSet<RapportIntervention>();
        }

        public int NumOt { get; set; }
        public int? NumDt { get; set; }
        public bool CodeMaintenance { get; set; }
        public DateTime DateOt { get; set; }
        public DateTime? HeureInstallation { get; set; }
        public int CodeDemandeur { get; set; }
        public int CodeReceveur { get; set; }
        public int? CodeMachine { get; set; }
        public int? NumEquipement { get; set; }

        public virtual Structure CodeDemandeurNavigation { get; set; }
        public virtual Machines CodeMachineNavigation { get; set; }
        public virtual TypeMaintenance CodeMaintenanceNavigation { get; set; }
        public virtual DemandeTravail NumDtNavigation { get; set; }
        public virtual ICollection<RapportIntervention> RapportIntervention { get; set; }
    }
}
