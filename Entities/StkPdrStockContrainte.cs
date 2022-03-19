using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkPdrStockContrainte
    {
        public int Id { get; set; }
        public int? CodeFicheArticle { get; set; }
        public int CodePdr { get; set; }
        public double StockMinimum { get; set; }
        public double StockMaximum { get; set; }
        public double StockSécurité { get; set; }
        public int? CodeGestion { get; set; }
        public int? CodeModelAppro { get; set; }
        public int? StockAlerte { get; set; }
        public int? DelaiApprovisionnement { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
