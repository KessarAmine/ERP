using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Models
{
    public partial class SuiviCCEntreesModel
    {
        public DateTime DateEntree { get; set; }
        public int NumEntrree { get; set; }
        public int CodeArticle { get; set; }
        public string CodeFamille { get; set; }
        public string CodeFournisseur { get; set; }
        public double Quantite { get; set; }
        public double Cout { get; set; }
        public double Montant { get; set; }
    }
}
