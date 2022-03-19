using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproFournisseurs
    {
        public string NumeroFournisseur { get; set; }
        public string SocieteFournisseur { get; set; }
        public string Gmail { get; set; }
        public string Fonction { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string Pays { get; set; }
        public int? Telephone { get; set; }
        public string Fax { get; set; }
        public int? Nrc { get; set; }
        public int? Mf { get; set; }
        public int? Art { get; set; }
        public string Contact { get; set; }
    }
}
