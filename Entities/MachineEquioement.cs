using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MachineEquioement
    {
        public int Id { get; set; }
        public int NumMachine { get; set; }
        public int NumEquipement { get; set; }
        public int? Qte { get; set; }
        public string NumComposition { get; set; }

        public virtual Compositions NumCompositionNavigation { get; set; }
        public virtual Equipements NumEquipementNavigation { get; set; }
        public virtual Machines NumMachineNavigation { get; set; }
    }
}
