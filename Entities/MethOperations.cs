using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MethOperations
    {
        public int Idoperation { get; set; }
        public int NumMachine { get; set; }
        public int NumEquipement { get; set; }
        public string Description { get; set; }
        public int Fréquence { get; set; }
        public int Unité { get; set; }
        public string Guide { get; set; }
        public int? StructreConcernée { get; set; }
    }
}
