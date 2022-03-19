using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class BonEntree
    {
        public int Id { get; set; }
        public int NumeroBonEntree { get; set; }
        public int NumeroDemandeAchat { get; set; }
        public DateTime DateEntree { get; set; }
        public double Qte { get; set; }
        public string Fournisseur { get; set; }
        public double PrixUnitaire { get; set; }
    }
}
