using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TempMaintPointControleDetail
    {
        public int Id { get; set; }
        public int CodeMachine { get; set; }
        public bool Dimanche { get; set; }
        public bool Lundi { get; set; }
        public bool Mardi { get; set; }
        public bool Mercredi { get; set; }
        public bool Jeudi { get; set; }
        public bool Vendredi { get; set; }
        public bool Samedi { get; set; }
    }
}
