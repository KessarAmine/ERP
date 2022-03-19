using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TempStkPdrStockContrainte
    {
        public int Id { get; set; }
        public int CodePdr { get; set; }
        public int StockMinimum { get; set; }
        public int StockMaximum { get; set; }
        public int StockSécurité { get; set; }
        public int? CodeGestion { get; set; }
        public int? CodeModelAppro { get; set; }
    }
}
