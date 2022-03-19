using System;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class RaportOBJECTIFS_QUALITE_MAINTENANCE
    {
        public RaportOBJECTIFS_QUALITE_MAINTENANCE()
        {
            InitializeComponent();
            SqlDataSource.DisableCustomQueryValidation = true;
        }
    }
}
