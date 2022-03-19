using System;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class EtatCompteComptable
    {
        public EtatCompteComptable()
        {
            InitializeComponent();
        }

        private void EtatCompteComptable_DataSourceDemanded(object sender, EventArgs e)
        {
            if (this.TypeReport.Value.ToString().Equals("0"))
            {
                //Entrées
                this.EntreesHead.Visible = true;
                this.EntreesColumns.Visible = true;
                this.EntreesData.Visible = true;
                this.EntreesSum.Visible = false;

                this.SortiesHead.Visible = true;
                this.SortiesColumns.Visible = true;
                this.SortiesData.Visible = true;
                this.SortiesSum.Visible = false;

                this.RecapeHead.Visible = true;
                this.RecapeData.Visible = true;

            }

            if (this.TypeReport.Value.ToString().Equals("1"))
            {
                this.EntreesHead.Visible = false;
                this.EntreesColumns.Visible = false;
                this.EntreesData.Visible = false;
                this.EntreesSum.Visible = false;

                this.SortiesHead.Visible = true;
                this.SortiesColumns.Visible = true;
                this.SortiesData.Visible = true;
                this.SortiesSum.Visible = true;

                this.RecapeHead.Visible = false;
                this.RecapeData.Visible = false;
            }

            if (this.TypeReport.Value.ToString().Equals("2"))
            {
                this.EntreesHead.Visible = true;
                this.EntreesColumns.Visible = true;
                this.EntreesData.Visible = true;
                this.EntreesSum.Visible = true;

                this.SortiesHead.Visible = false;
                this.SortiesColumns.Visible = false;
                this.SortiesData.Visible = false;
                this.SortiesSum.Visible = false;

                this.RecapeHead.Visible = false;
                this.RecapeData.Visible = false;
            }

        }
    }
}
