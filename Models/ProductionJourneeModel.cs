using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class ProductionJourneeModel
    {
        public int NumRapport { get; set; }
        public DateTime Date { get; set; }
        public int Poste { get; set; }
        public int NumBon { get; set; }
        public int OperateurPcp { get; set; }
        public int ChefPoste { get; set; }
        public int IngProcess { get; set; }
        public string DimProduitFini { get; set; }
        public string DimProduitConforme { get; set; }
        public string DimBillete { get; set; }
        public string LongBillete { get; set; }
        public int? NbrCisaille { get; set; }
        public int? NbrExpulsee { get; set; }
        public int? NbrRealisee { get; set; }
        public int? NbrDefourne { get; set; }
        public int? NumRapportPreparation { get; set; }
        public int? NbrFardeaux { get; set; }
    }
}
