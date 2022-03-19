using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Achats
    {
        public int Id { get; set; }
        public int NumDemande { get; set; }
        public DateTime Date { get; set; }
        public string Designation { get; set; }
        public double Qte { get; set; }
        public string Unite { get; set; }
        public string Etat { get; set; }
        public int? NumBon { get; set; }
        public double? Qtelivree { get; set; }
        public DateTime? DateLivraison { get; set; }
        public string Fournisseur { get; set; }
        public double? PrixUnitaire { get; set; }
    }
}
