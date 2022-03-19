using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MethPlanningEtSuiviMateriel
    {
        public int Id { get; set; }
        public string ElementMachine { get; set; }
        public string Activité { get; set; }
        public int NumOt { get; set; }
        public int Fréquence { get; set; }
        public bool M1 { get; set; }
        public bool M2 { get; set; }
        public bool M3 { get; set; }
        public bool M4 { get; set; }
        public bool M5 { get; set; }
        public bool M6 { get; set; }
        public bool M7 { get; set; }
        public bool M8 { get; set; }
        public bool M9 { get; set; }
        public bool M10 { get; set; }
        public bool M11 { get; set; }
        public bool M12 { get; set; }
        public int Year { get; set; }
        public int CodeMachine { get; set; }
        public int IdOperation { get; set; }
    }
}
