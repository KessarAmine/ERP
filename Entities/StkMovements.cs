using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkMovements
    {
        public int IdMovement { get; set; }
        public DateTime DateMovment { get; set; }
        public int TypeMovement { get; set; }
        public int? CodePdr { get; set; }
        public double Qte { get; set; }
        public double PrixUnitaire { get; set; }
        public double Montant { get; set; }
        public double StockTotalSythese { get; set; }
        public double ValeurStockTotal { get; set; }
        public int TypeValorisation { get; set; }
        public double ValeurValorisation { get; set; }
        public int IdDetail { get; set; }
        public string ArticleNonGere { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
