using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinAgent.Models
{
    public partial class SuiviPdrModel
    {
        public int CodePdr { get; set; }
        public string DesignationPdr { get; set; }
        public DateTime DateMovement { get; set; }
        public int NumeroTypeMovement { get; set; }
        public String TypeMovement { get; set; }
        public float Quantite { get; set; }
        public float Cout { get; set; }
        public float Valeur { get; set; }
        public float Reste { get; set; }
        public String Acteur { get; set; }

    }
}
