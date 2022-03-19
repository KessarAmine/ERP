using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproDemandeService
    {
        public int NumeroDemandeService { get; set; }
        public DateTime DateDemande { get; set; }
        public int CodeServiceDemandeur { get; set; }
        public string Observation { get; set; }
        public int? CodeServiceReceveur { get; set; }
    }
}
