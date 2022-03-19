using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteControlGeometriqueDetails
    {
        public int Id { get; set; }
        public int NumControl { get; set; }
        public string Profile { get; set; }
        public double MesureProfileLamineExacte { get; set; }
        public double OvaliteSurDiametre { get; set; }
        public double MasseLineique { get; set; }
        public double? NervurePas { get; set; }
        public double NervureHauteur { get; set; }
        public double NervureLargeur { get; set; }
        public double AboutsHauteur { get; set; }
        public double AboutLargeur { get; set; }
        public DateTime HeureMiseCotes { get; set; }
        public string Remarque { get; set; }

        public virtual QualiteControlGeometrique NumControlNavigation { get; set; }
    }
}
