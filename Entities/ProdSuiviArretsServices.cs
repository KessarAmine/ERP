using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdSuiviArretsServices
    {
        public int Id { get; set; }
        public DateTime DateArret { get; set; }
        public double? Hi { get; set; }
        public double? Hh { get; set; }
        public double? Ps { get; set; }
        public double? Tf { get; set; }
        public double? Eb { get; set; }
        public double? Mb { get; set; }
        public double? Kk { get; set; }
        public double? Sonalgaz { get; set; }
        public double? Dg { get; set; }
    }
}
