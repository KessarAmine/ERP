using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class BonProduction
    {
        public BonProduction()
        {
            OrdreProduction = new HashSet<OrdreProduction>();
        }

        public int NumBon { get; set; }
        public int CodeProduit { get; set; }
        public string UniteMesure { get; set; }
        public string Qte { get; set; }
        public string Nb { get; set; }
        public int CodeReceveur { get; set; }
        public DateTime? Date { get; set; }

        public virtual Produits CodeReceveur1 { get; set; }
        public virtual Intervenant CodeReceveurNavigation { get; set; }
        public virtual ICollection<OrdreProduction> OrdreProduction { get; set; }
    }
}
