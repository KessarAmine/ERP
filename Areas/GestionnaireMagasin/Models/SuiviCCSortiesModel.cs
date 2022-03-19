using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.GestionnaireMagasin.Models
{
    public partial class SuiviCCSortiesModel
    {
        public DateTime DateSortie { get; set; }
        public int NumSortie { get; set; }
        public int CodeArticle { get; set; }
        public string CodeFamille { get; set; }
        public int CentreFrais { get; set; }
        public double Quantite { get; set; }
        public double Cout { get; set; }
        public double Montant { get; set; }
    }
}
