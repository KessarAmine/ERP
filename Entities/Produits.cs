using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Produits
    {
        public Produits()
        {
            BonProduction = new HashSet<BonProduction>();
        }

        public int CodeProduit { get; set; }
        public string Designation { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<BonProduction> BonProduction { get; set; }
    }
}
