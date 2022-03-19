using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteEssaisMecaniqueDetails
    {
        public int Id { get; set; }
        public int NumControl { get; set; }
        public string Profile { get; set; }
        public double MesureProfileLamineExacte { get; set; }
        public double MasseLineique { get; set; }
        public DateTime HorraireEssai { get; set; }
        public double SectionMetal { get; set; }
        public double LimiteElastique { get; set; }
        public double RuptureTraction { get; set; }
        public double TauxRmre { get; set; }
        public double TauxAllongement { get; set; }
        public double EssaiTorsion { get; set; }
        public double PessageProfile { get; set; }
        public int IdControleur { get; set; }
        public string Remarque { get; set; }

        public virtual QualiteEssaisMecanique NumControlNavigation { get; set; }
    }
}
