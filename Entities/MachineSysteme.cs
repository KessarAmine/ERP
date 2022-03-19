using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MachineSysteme
    {
        public string Id { get; set; }
        public int NumMachine { get; set; }
        public int NumEquipement { get; set; }
        public string NomEquipement { get; set; }
        public string DesignationEquipement { get; set; }
        public float? ValeurUnitaire { get; set; }
        public int? Qte { get; set; }

        public virtual Equipements NumEquipementNavigation { get; set; }
        public virtual Machines NumMachineNavigation { get; set; }
    }
}
