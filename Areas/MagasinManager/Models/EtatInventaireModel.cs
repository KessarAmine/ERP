using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinManager.Models
{
    public partial class EtatInventaireModel
    {
        public int CodeArticle { get; set; }
        public double Cout { get; set; }
        public int QuantitePhy { get; set; }
        public double ValeurPhy { get; set; }
        public int QuantiteThe { get; set; }
        public double ValeurThe { get; set; }
        public int QuantiteEcart { get; set; }
        public double ValeurEcart { get; set; }
    }
}
