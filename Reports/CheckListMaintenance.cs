using System;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace DevKbfSteel.Reports
{
    public partial class CheckListMaintenance
    {
        public CheckListMaintenance()
        {
            InitializeComponent();
            SqlDataSource.DisableCustomQueryValidation = true;
        }
    }
}
