using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkReceptionBillette
    {
        public int NumReception { get; set; }
        public DateTime DateReception { get; set; }
        public string BilleteRecue { get; set; }
        public string Navire { get; set; }
    }
}
