using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonRetourTransfertArticles
    {
        public int Id { get; set; }
        public int NumBonRetourTransfert { get; set; }
        public int CodePdr { get; set; }
        public double Qte { get; set; }
    }
}
