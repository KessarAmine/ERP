using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Machines
    {
        public Machines()
        {
            Equipements = new HashSet<Equipements>();
            MachineEquioement = new HashSet<MachineEquioement>();
            MachineSysteme = new HashSet<MachineSysteme>();
            OrdreTravail = new HashSet<OrdreTravail>();
        }

        public int NumMachine { get; set; }
        public string NomMachine { get; set; }
        public string NumGroupe { get; set; }
        public int? NumEquipement { get; set; }
        public int? SeuilAlerteAnoamlie { get; set; }

        public virtual Equipements NumEquipementNavigation { get; set; }
        public virtual GroupeMachines NumGroupeNavigation { get; set; }
        public virtual ICollection<Equipements> Equipements { get; set; }
        public virtual ICollection<MachineEquioement> MachineEquioement { get; set; }
        public virtual ICollection<MachineSysteme> MachineSysteme { get; set; }
        public virtual ICollection<OrdreTravail> OrdreTravail { get; set; }
    }
}
