using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class DemandeServiceModel
    {
        public DateTime DateDemande { get; set; }
        public int NumeroDemandeService { get; set; }
        public int CodeServiceReceveur { get; set; }
        public string Obeservations { get; set; }
    }
}
