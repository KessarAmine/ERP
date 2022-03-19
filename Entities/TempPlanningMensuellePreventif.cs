using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TempPlanningMensuellePreventif
    {
        public int Id { get; set; }
        public string Equipement { get; set; }
        public string OperationMaintenance { get; set; }
        public DateTime? DateAnterieure { get; set; }
        public DateTime DateProchaine { get; set; }
        public string Pdr { get; set; }
        public string Pdrqte { get; set; }
    }
}
