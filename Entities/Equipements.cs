using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Equipements
    {
        public Equipements()
        {
            MachineEquioement = new HashSet<MachineEquioement>();
            MachineSysteme = new HashSet<MachineSysteme>();
            Machines = new HashSet<Machines>();
        }

        public int NumEquipement { get; set; }
        public string Nom { get; set; }
        public string Designation { get; set; }
        public float? ValeurUnitaire { get; set; }
        public int? NumMachine { get; set; }

        public virtual Machines NumMachineNavigation { get; set; }
        public virtual ICollection<MachineEquioement> MachineEquioement { get; set; }
        public virtual ICollection<MachineSysteme> MachineSysteme { get; set; }
        public virtual ICollection<Machines> Machines { get; set; }
    }
}
