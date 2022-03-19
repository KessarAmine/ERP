using System;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace DevKbfSteel.Reports
{
    public partial class EtatFournisseur
    {
        public EtatFournisseur()
        {
            InitializeComponent();
            SqlDataSource.DisableCustomQueryValidation = true;
        }

        private void EtatFournisseur_DataSourceDemanded(object sender, EventArgs e)
        {
            if (this.TypeReport.Value.ToString().Equals("0"))
            {
                this.EntreeHead.Visible = true;
                this.EntreeColumns.Visible = true;
                this.EntreesData.Visible = true;
                this.EntreesTT.Visible = false;

                this.RetoursHead.Visible = true;
                this.RetoursColumns.Visible = true;
                this.RetoursData.Visible = true;
                this.RetoursTT.Visible = false;

                this.RecapeData.Visible = true;
                this.RecapeHead.Visible = true;

            }
            if (this.TypeReport.Value.ToString().Equals("1"))
            {
                this.EntreeHead.Visible = true;
                this.EntreeColumns.Visible = true;
                this.EntreesData.Visible = true;
                this.EntreesTT.Visible = true;

                this.RetoursHead.Visible = false;
                this.RetoursColumns.Visible = false;
                this.RetoursData.Visible = false;
                this.RetoursTT.Visible = false;

                this.RecapeData.Visible = false;
                this.RecapeHead.Visible = false;
            }
            if (this.TypeReport.Value.ToString().Equals("2"))
            {
                this.EntreeHead.Visible = false;
                this.EntreeColumns.Visible = false;
                this.EntreesData.Visible = false;
                this.EntreesTT.Visible = false;

                this.RetoursHead.Visible = true;
                this.RetoursColumns.Visible = true;
                this.RetoursData.Visible = true;
                this.RetoursTT.Visible = true;

                this.RecapeData.Visible = false;
                this.RecapeHead.Visible = false;
            }
        }
    }
}
