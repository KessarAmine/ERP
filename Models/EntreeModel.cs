using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
namespace DevKbfSteel.Models
{
    public class EntreeModel
    {
        public int NumBon { get; set; }
        public DateTime DateEntree { get; set; }
        public string CodeFournisseur { get; set; }
        public string NomFournisseur { get; set; }
        public int TypeAchat { get; set; }
        public int? Nda { get; set; }
        public DateTime? DateDa { get; set; }
        public int? TypeDevise { get; set; }
        public double? TauxChange { get; set; }
        public int? CodeCloture { get; set; }
        public int? TypeSource { get; set; }
        public int? NumSource { get; set; }
        public int? CodeIntervenant { get; set; }
        public double? SommeFraisApproches { get; set; }
        public double? Somme { get; set; }
    }
}
