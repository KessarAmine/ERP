using System;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace DevKbfSteel.Reports
{
    public partial class BonAffectation
    {
        public BonAffectation()
        {
            InitializeComponent();
            SqlDataSource.DisableCustomQueryValidation = true;

        }
    }
}
