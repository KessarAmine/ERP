using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkEquipements
    {
        public string CodeEquipement { get; set; }
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Type { get; set; }
        public int? Année { get; set; }
        public DateTime? DateAcquisition { get; set; }
        public int? PériodeGarantie { get; set; }
        public int? PériodeGarantieUnite { get; set; }
        public double? PrixAchat { get; set; }
        public DateTime? DateInstallation { get; set; }
        public int NumEquipement { get; set; }
    }
}
