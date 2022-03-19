using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class DemandesAchats
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public int NumeroDemandeAchat { get; set; }
        public DateTime DateAchat { get; set; }
        public double Qte { get; set; }
        public string Unite { get; set; }
        public string Etat { get; set; }
    }
}
