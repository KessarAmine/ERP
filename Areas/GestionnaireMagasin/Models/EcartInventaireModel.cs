using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.GestionnaireMagasin.Models
{
    public partial class EcartInventaireModel
    {
        public int CodeArticle { get; set; }
        public int Equipe1 { get; set; }
        public int Equipe2 { get; set; }
        public int Ecart { get; set; }
        public int ECE1 { get; set; }
        public int ECE2 { get; set; }
        public int EquipeControl { get; set; }
    }
}