using System;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class PROD_SuiviProduction
    {
        public PROD_SuiviProduction()
        {
            InitializeComponent();
            SqlDataSource.DisableCustomQueryValidation = true;

        }
    }
}
