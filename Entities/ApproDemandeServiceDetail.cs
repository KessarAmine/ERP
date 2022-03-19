using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproDemandeServiceDetail
    {
        public int Id { get; set; }
        public int NumeroDemandeService { get; set; }
        public int CodeArticle { get; set; }
        public string ServiceDemande { get; set; }
    }
}
