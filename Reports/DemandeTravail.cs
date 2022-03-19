using System;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevKbfSteel.Entities;
using DevExpress.XtraPrinting.Drawing;
using System.Linq;

namespace DevKbfSteel.Reports
{
    public partial class DemandeTravail
    {
        private KBFsteelContext _context;
        public DemandeTravail()
        {
            InitializeComponent();
            SqlDataSource.DisableCustomQueryValidation = true;
            _context = new KBFsteelContext();
        }

        private void DemandeTravail_DataSourceDemanded(object sender, EventArgs e)
        {
            var demandeur = "";
            var ordres = _context.DemandeTravail
            .Where(o => o.NumDt == Convert.ToInt32(this.NumDt.Value.ToString()))
            .Select(i => new
            {
                i.CodeReceveur,
                i.DemandeurOpt,
                i.CodeStructure
            }).ToList();
            if (ordres.Last().DemandeurOpt.Equals(null))
            {
                var ResponsableDemandeur = _context.Structure
                .Where(o => o.CodeStructure == ordres.Last().CodeStructure).Select(i => new
                {
                    i.Responsable
                }).ToList();
                demandeur = ResponsableDemandeur.Last().Responsable;
            }
            else
            {
                var ResponsableDemandeur = _context.AssStructureDerigants
                .Where(o => o.Id == ordres.Last().DemandeurOpt).Select(i => new
                {
                    i.CodeDerigant
                }).ToList();
                demandeur = ResponsableDemandeur.Last().CodeDerigant;
            }
            var VisaDemandeur = _context.GrhNumericVisas
            .Where(o => o.Responsable == demandeur).Select(i => new
            {
                i.VisaPath
            }).ToList();
            var ResponsableReceveur = _context.Structure
            .Where(o => o.CodeStructure == ordres.Last().CodeReceveur).Select(i => new
            {
                i.Responsable
            }).ToList();
            var VisaReceveur = _context.GrhNumericVisas
            .Where(o => o.Responsable == ResponsableReceveur.Last().Responsable).Select(i => new
            {
                i.VisaPath
            }).ToList();
            //UpdatePicture
            this.SignatureBoxDemandeur.ImageSource = ImageSource.FromFile(VisaDemandeur.Last().VisaPath);
            this.SignatureBoxReceveur.ImageSource = ImageSource.FromFile(VisaReceveur.Last().VisaPath);
        }
    }
}
