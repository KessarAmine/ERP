using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkEmplacement
    {
        public int NumEmplacement { get; set; }
        public int? CodePdr { get; set; }
        public int CodeLieu { get; set; }
        public int? CodeGisement { get; set; }
        public double? Qte { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
