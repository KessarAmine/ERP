using System;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class BonEntreeMagasin
    {
        public BonEntreeMagasin()
        {
            DevExpress.DataAccess.Sql.SqlDataSource.AllowCustomSqlQueries = true;
            DevExpress.DataAccess.Sql.SqlDataSource.DisableCustomQueryValidation = true;
            InitializeComponent();
        }
    }
}
