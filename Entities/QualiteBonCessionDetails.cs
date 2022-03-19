using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteBonCessionDetails
    {
        public int Id { get; set; }
        public int NumBonCession { get; set; }
        public string CodeArticle { get; set; }
        public int Conforme { get; set; }
        public int MoyenneNbrBarreFardeau { get; set; }
        public int Rebuts { get; set; }
        public int Realisee { get; set; }
        public int Defournee { get; set; }
        public double Poids { get; set; }
        public int DimBillette { get; set; }

        public virtual QualiteBonCession NumBonCessionNavigation { get; set; }
    }
}
