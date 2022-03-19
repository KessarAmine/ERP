using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Deconsignation
    {
        public int Id { get; set; }
        public DateTime DateBonDeconsgination { get; set; }
        public DateTime DateDemandeDeconsignation { get; set; }
        public int IdBonDéconsignation { get; set; }
        public int IdDemandeDeConsignation { get; set; }
        public int NumConsignation { get; set; }
    }
}
