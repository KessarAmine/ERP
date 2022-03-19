using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonTransfertArticles
    {
        public int Id { get; set; }
        public int NumBonTransfert { get; set; }
        public int CodePdr { get; set; }
        public double Qte { get; set; }
        public DateTime? DateTransfert { get; set; }
    }
}
