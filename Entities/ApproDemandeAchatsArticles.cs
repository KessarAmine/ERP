using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproDemandeAchatsArticles
    {
        public int Id { get; set; }
        public int NumDemandeAchat { get; set; }
        public int CodeArticle { get; set; }
        public double QteDemande { get; set; }
        public double? QteValable { get; set; }
    }
}
