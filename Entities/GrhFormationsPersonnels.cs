using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class GrhFormationsPersonnels
    {
        public int Id { get; set; }
        public int IdFormation { get; set; }
        public int IdEmployee { get; set; }
        public double CapitalHumain { get; set; }
    }
}
