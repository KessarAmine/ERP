using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class SmartAssistItem
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Action { get; set; }
        public string Path { get; set; }
        public int CodeStructure { get; set; }
    }
}
