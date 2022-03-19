using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MethStructureMachine
    {
        public int Id { get; set; }
        public int CodeInstallation { get; set; }
        public int NumEquipement { get; set; }
        public string Equipement { get; set; }
        public string ReferenceModel { get; set; }
    }
}
