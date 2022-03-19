using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class PrjDependecies
    {
        public int IdDependecy { get; set; }
        public int PredId { get; set; }
        public int SuccId { get; set; }
        public int Type { get; set; }
    }
}
