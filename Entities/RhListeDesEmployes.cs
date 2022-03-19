using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class RhListeDesEmployes
    {
        public int Id { get; set; }
        public int? Civilité { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int? TelPersonnel { get; set; }
        public int? TelProfesionnel { get; set; }
        public DateTime DateNaissance { get; set; }
        public int? Sexe { get; set; }
        public int? PaysNaissance { get; set; }
        public int? Nationalité { get; set; }
        public int? NumeroSecuriteSocial { get; set; }
        public int? Departement { get; set; }
        public int? PaysResidence { get; set; }
        public string VilleResidence { get; set; }
        public string Adresse { get; set; }
        public int? CodePostale { get; set; }
        public DateTime? DateAmbouche { get; set; }
        public DateTime? DateFinAmbouche { get; set; }
        public int? CodeSpecialité { get; set; }
        public int? CodeEquipe { get; set; }
        public int? Disponnible { get; set; }
        public string NomLatin { get; set; }
        public string PrenomLatin { get; set; }
        public double? RénumerationParHeure { get; set; }
        public string LieuNiassance { get; set; }
        public string LieuNiassanceLatin { get; set; }
        public string AdresseLatin { get; set; }
        public int? NumCarteId { get; set; }
        public DateTime? DateCarteId { get; set; }
        public string LieuCarteId { get; set; }
        public double? Salaire { get; set; }
    }
}
