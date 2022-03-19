using System;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class RapportJournalierProduction
    {
        public RapportJournalierProduction()
        {
            InitializeComponent();
            SqlDataSource.DisableCustomQueryValidation = true;
        }
    }
}
