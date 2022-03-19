using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.GestionnaireMagasin.Models
{
    public partial class InventaireFinalModel
    {
        public int CodeArticle { get; set; }
        public int Quantite { get; set; }
        public double Cout { get; set; }
        public float Valeur { get; set; }
    }
}
