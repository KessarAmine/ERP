using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkStockInitial
    {
        public int Id { get; set; }
        public int CodePdr { get; set; }
        public double PrixUnitare { get; set; }
        public double Qte { get; set; }
        public int Annee { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
