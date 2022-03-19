using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproBonsEntrees
    {
        public ApproBonsEntrees()
        {
            ApproArticlesEntres = new HashSet<ApproArticlesEntres>();
        }

        public int NumBon { get; set; }
        public DateTime DateEntree { get; set; }

        public virtual ICollection<ApproArticlesEntres> ApproArticlesEntres { get; set; }
    }
}
