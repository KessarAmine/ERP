using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class AjouterDetailServiceModel
    {
        public int Id { get; set; }
        public int NumeroDemandeService { get; set; }
        public int CodeArticle { get; set; }
        public string ServiceDemande { get; set; }
    }
}
