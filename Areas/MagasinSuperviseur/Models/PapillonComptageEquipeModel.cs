using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Models
{
    public partial class PapillonComptageEquipeModel
    {
        public int CodePdr { get; set; }
        public int CodeUniteMesure { get; set; }
        public int CodeGisement { get; set; }
        public float Quantite { get; set; }
    }
}
