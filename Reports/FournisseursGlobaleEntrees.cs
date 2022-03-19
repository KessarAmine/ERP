using System;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace DevKbfSteel.Reports
{
    public partial class FournisseursGlobaleEntrees
    {
        public FournisseursGlobaleEntrees()
        {
            InitializeComponent();
        }
        private void FournisseursGlobaleEntrees_DataSourceDemanded(object sender, EventArgs e)
        {
            if (this.TypeReport.Value.ToString().Equals("0"))
            {
                //Entrées
                this.EntreeHead.Visible = true;
                this.EntreeColumns.Visible = true;
                this.EntreeData.Visible = true;
                this.EntreeSum.Visible = true;
                this.RetoursHead.Visible = true;
                this.RetoursColumns.Visible = true;
                this.RetoursData.Visible = true;
            }

            if (this.TypeReport.Value.ToString().Equals("1"))
            {
                //Retours
                this.RetoursHead.Visible = false;
                this.RetoursColumns.Visible = false;
                this.RetoursData.Visible = false;
                this.EntreeHead.Visible = true;
                this.EntreeColumns.Visible = true;
                this.EntreeData.Visible = true;
                this.EntreeSum.Visible = true;

            }
            if (this.TypeReport.Value.ToString().Equals("2"))
            {
                //Entrées
                this.EntreeHead.Visible = false;
                this.EntreeColumns.Visible = false;
                this.EntreeData.Visible = false;
                this.EntreeSum.Visible = false;
                this.RetoursHead.Visible = true;
                this.RetoursColumns.Visible = true;
                this.RetoursData.Visible = true;
            }
        }
    }
}
