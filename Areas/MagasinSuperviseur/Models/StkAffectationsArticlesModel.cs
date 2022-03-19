using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Models
{
    public partial class StkAffectationsArticlesModel
    {
        public int CodePdr { get; set; }
        public string DesignationPdr { get; set; }
        public int? CodeUniteMesure { get; set; }
        public double? PrixUnitaire { get; set; }
    }
}
