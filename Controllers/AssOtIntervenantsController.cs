using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
using Microsoft.AspNetCore.Authorization;
using DevKbfSteel.Helpers;
using DevKbfSteel.Models;
namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class AssOtIntervenantsController : Controller
    {
        private KBFsteelContext _context;
        public AssOtIntervenantsController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumIntervention = id;
            var bonproduction = _context.AssOtIntervenants
                .Where(c => c.NumIntervention == id)
                .Select(i => new {
                    i.Id,
                    i.CodeIntervenant,
                    i.CodeSpecialite,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.DureeInervention
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new AssOtIntervenants();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var ordres = _context.AssOtIntervenants
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();
                if (ordres.Count == 0)
                    model.Id = 1;
                else
                {
                    var m = ordres.Last();
                    model.Id = Convert.ToInt32(m.Id) + 1;
                }
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            model.NumIntervention = (int)XpertHelper.NumIntervention;
            var spc = _context.RhListeDesEmployes
                .AsNoTracking()
                .Where(c => c.Id == model.CodeIntervenant)
                .Select(i => new
                {
                    i.CodeSpecialité
                }).FirstOrDefault();
            if (!spc.CodeSpecialité.Equals(null))
                model.CodeSpecialite = (int)spc.CodeSpecialité;
            var dateInter = _context.RapportIntervention
                .AsNoTracking()
                .Where(c => c.NumIntervention == model.NumIntervention)
                .Select(i => new
                {
                    i.DateIntervention,
                    i.DureeIntervention
                }).FirstOrDefault();
            model.DateIntervention = dateInter.DateIntervention;
            model.DureeInervention = dateInter.DureeIntervention;

            var result = _context.AssOtIntervenants.Add(model);
            await _context.SaveChangesAsync();
            //Check this Rapoort its Ots if it an operation = Get its Id = go to suivi et planning 
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.AssOtIntervenants.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var dateInter = _context.RapportIntervention
            .AsNoTracking()
            .Where(c => c.NumIntervention == model.NumIntervention)
            .Select(i => new
            {
                i.DateIntervention,
                i.DureeIntervention
            }).FirstOrDefault();
            model.DateIntervention = dateInter.DateIntervention;
            model.DureeInervention = dateInter.DureeIntervention;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.AssOtIntervenants.FirstOrDefaultAsync(item => item.Id == key);
            _context.AssOtIntervenants.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult>NomLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new {
                             Value = i.Id,
                             Text = i.Nom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> PrenomLookup(DataSourceLoadOptions loadOptions) 
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.Prenom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TelLookup(DataSourceLoadOptions loadOptions) 
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.TelProfesionnel
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> EquipementsLookup(DataSourceLoadOptions loadOptions) 
        {
            var lookup = from i in _context.Equipements
                         orderby i.NumEquipement
                         select new
                         {
                             Value = i.NumEquipement,
                             Text = i.Nom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> MachinesLookup(DataSourceLoadOptions loadOptions) 
        {
            var lookup = from i in _context.Machines
                         orderby i.NumMachine
                         select new
                         {
                             Value = i.NumMachine,
                             Text = i.NomMachine
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> SpecialiteLookup(DataSourceLoadOptions loadOptions) 
        {
            var lookup = from i in _context.Specialite
                         orderby i.CodeSpecialite
                         select new
                         {
                             Value = i.CodeSpecialite,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(AssOtIntervenants model, IDictionary values) {
            string CodeIntervenant = nameof(AssOtIntervenants.CodeIntervenant);
            string NumIntervention = nameof(AssOtIntervenants.NumIntervention);
            string Id = nameof(AssOtIntervenants.Id);
            string CodeSpecialite = nameof(AssOtIntervenants.CodeSpecialite);
            string CodeMachine = nameof(AssOtIntervenants.CodeMachine);
            string CodeEquipement = nameof(AssOtIntervenants.CodeEquipement);
            string DateIntervention = nameof(AssOtIntervenants.DateIntervention);
            if (values.Contains(DateIntervention))
            {
                model.DateIntervention = Convert.ToDateTime(values[DateIntervention]);
            }
            if (values.Contains(CodeMachine))
            {
                model.CodeMachine = Convert.ToInt32(values[CodeMachine]);
            }
            if (values.Contains(CodeEquipement))
            {
                var CodePdrvar = values[CodeEquipement];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeEquipement = Convert.ToString(CodePdrSplited.Trim());
            }
            if (values.Contains(CodeSpecialite))
            {
                model.CodeSpecialite = Convert.ToInt32(values[CodeSpecialite]);
            }
            if (values.Contains(CodeIntervenant)) {
                var Idemployevar = values[CodeIntervenant];
                var Idemployestrings = Idemployevar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var value = SplitThesecond[0];
                model.CodeIntervenant = Convert.ToInt32(value);
            }
            if(values.Contains(NumIntervention)) {
                model.NumIntervention = Convert.ToInt32(values[NumIntervention]);
            }
            if(values.Contains(Id)) {
                model.Id = Convert.ToInt32(values[Id]);
            }
        }
        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
        public async Task PostRapportWithForm(AjouterRapportInterventionModel values) 
        {
            var model = new RapportIntervention();
            model.CompteRendu = values.CompteRendu;
            model.DateIntervention = values.DateIntervention.Date;
            model.DebutIntervention = values.DateIntervention;
            model.DureeIntervention = values.DureeIntervention;
            model.Observation = values.Observation;
            model.NumOt = (int)XpertHelper.NumOt;
            var ordres = _context.RapportIntervention.AsNoTracking()
            .OrderBy(o => o.NumIntervention)
            .Select(i => new
            {
                i.NumIntervention
            }).ToList();
            if (ordres.Count == 0)
                model.NumIntervention = 1;
            else
            {
                var m = ordres.Last();
                model.NumIntervention = Convert.ToInt32(m.NumIntervention) + 1;
            }

            var result = _context.RapportIntervention.Add(model);
            var ordre = _context.OrdreTravail.Where(c => c.NumOt == model.NumOt)
            .Select(i => new
            {
                i.NumDt,
                i.CodeMachine,
                i.NumEquipement
            }).ToList();
            var dto = ordre.Last();
            //==============================

            if (!dto.NumDt.Equals(null))
            {
                var det = _context.DemandeTravail.Where(o => o.NumDt == dto.NumDt).FirstOrDefault();
                det.CodeStatut = 2;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            _context.SaveChanges();
            var travaux = _context.TempAssOtIntervenants.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.CodeIntervenant,
                    i.DureeInervention
                }).ToList();
            foreach (var itemtravaux in travaux)
            {
                AssOtIntervenants modele = new AssOtIntervenants();
                modele.NumIntervention = model.NumIntervention;
                modele.CodeEquipement = itemtravaux.CodeEquipement.ToString();
                modele.CodeIntervenant = itemtravaux.CodeIntervenant;
                modele.DateIntervention = model.DateIntervention.Date;
                modele.DureeInervention = itemtravaux.DureeInervention;
                modele.CodeMachine = itemtravaux.CodeMachine;
                var emmp = _context.RhListeDesEmployes.AsNoTracking()
                    .OrderBy(o => o.Id == modele.CodeIntervenant)
                    .Select(i => new
                    {
                        i.CodeSpecialité
                    }).ToList();
                modele.CodeSpecialite = emmp.Last().CodeSpecialité;
                //Do Post to AssOtTravaux
                await TempAssOtIntervenantsController.PostToAssOtIntervenants(_context, modele);
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_ASS_OT_Intervenants");
            var AssOtPdr = _context.TempAssOtPdr.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodePdr,
                    i.Qte
                }).ToList();
            foreach (var itemAssOtPdr in AssOtPdr)
            {
                AssOtPdr modele = new AssOtPdr();
                modele.NumIntervention = model.NumIntervention;
                modele.CodePdr = itemAssOtPdr.CodePdr;
                modele.Qte = itemAssOtPdr.Qte;

                var Movements = _context.StkMovements.AsNoTracking()
                .Where(o => o.CodePdr == modele.CodePdr)
                .Select(i => new
                {
                    i.ValeurValorisation
                }).ToList();
                var LastMovements = Movements.Last();
                if (!LastMovements.ValeurValorisation.Equals(null))
                {
                    modele.PrixUnitaire = (double)LastMovements.ValeurValorisation;
                    modele.Montant = modele.PrixUnitaire * modele.Qte;
                }
                else
                {
                    var PrixUnitaire = _context.StkStockInitial.AsNoTracking()
                    .Where(o => o.CodePdr == modele.CodePdr)
                    .Select(i => new
                    {
                        i.PrixUnitare
                    }).ToList();
                    var LastPrixUnitaire = PrixUnitaire.Last();
                    if (!LastPrixUnitaire.PrixUnitare.Equals(null))
                    {
                        modele.PrixUnitaire = LastPrixUnitaire.PrixUnitare;
                        modele.Montant = LastPrixUnitaire.PrixUnitare * modele.Qte;
                    }
                    else
                    {
                        modele.PrixUnitaire = 0;
                        modele.Montant = 0;
                    }
                }             
                //Do Post to AssOtTravaux
                await TempAssOtIntervenantsController.PostToAssOtPdr(_context, modele);
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE Ass_Ot_Pdr");
            var AssOtConsommable = _context.AssOtConsommable.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeConsommable,
                    i.Qte
                }).ToList();
            foreach (var itemAssOtConsommable in AssOtConsommable)
            {
                AssOtConsommable modele = new AssOtConsommable();
                modele.NumIntervention = model.NumIntervention;
                modele.CodeConsommable = itemAssOtConsommable.CodeConsommable;
                modele.Qte = itemAssOtConsommable.Qte;

                var Movements = _context.StkMovements.AsNoTracking()
                .Where(o => o.CodePdr == modele.CodeConsommable)
                .Select(i => new
                {
                    i.ValeurValorisation
                }).ToList();
                var LastMovements = Movements.Last();
                if (!LastMovements.ValeurValorisation.Equals(null))
                {
                    modele.PrixUnitaire = (double)LastMovements.ValeurValorisation;
                    modele.Montant = modele.PrixUnitaire * modele.Qte;
                }
                else
                {
                    var PrixUnitaire = _context.StkStockInitial.AsNoTracking()
                    .Where(o => o.CodePdr == modele.CodeConsommable)
                    .Select(i => new
                    {
                        i.PrixUnitare
                    }).ToList();
                    var LastPrixUnitaire = PrixUnitaire.Last();
                    if (!LastPrixUnitaire.PrixUnitare.Equals(null))
                    {
                        modele.PrixUnitaire = LastPrixUnitaire.PrixUnitare;
                        modele.Montant = LastPrixUnitaire.PrixUnitare * modele.Qte;
                    }
                    else
                    {
                        modele.PrixUnitaire = 0;
                        modele.Montant = 0;
                    }
                }
                //Do Post to AssOtTravaux
                await TempAssOtIntervenantsController.PostToAssOtConsommable(_context, modele);
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE ASS_Ot_Consommable");
        }

        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Dt_Recieved_With_Form_Exploitation(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("DemandeTravailsExploitationRecieved", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Dt_Recieved_With_Form_Electrique(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("DemandeTravailsElectriqueRecieved", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Dt_Recieved_With_Form_Mecanique(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("DemandeTravailsMecaniqueRecieved", "MecaniqueManager", new { area = "MecaniqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Dt_Recieved_With_Form_Usinage(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("DemandeTravailsUsinageRecieved", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Dt_Recieved_With_Form_Sodure(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("DemandeTravailsSodureRecieved", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Dt_Recieved_With_Form_Methode(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("DemandeTravailsMethodeRecieved", "MethodeManager", new { area = "MethodeManager" });
        }
        //============

        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Recieved_With_Form_Exploitation(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailExploitationRecieved", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Recieved_With_Form_Usinage(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailUsinageRecieved", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Recieved_With_Form_Sodure(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailSodureRecieved", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Recieved_With_Form_Electrique(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailElectriqueRecieved", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Recieved_With_Form_Mecanique(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailMecaniqueRecieved", "MecaniqueManager", new { area = "MecaniqueManager" });
        }
        //============

        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Sent_With_Form_Exploitation(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailExploitationSent", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Sent_With_Form_Usinage(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailUsinageSent", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Sent_With_Form_Sodure(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailSodureSent", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Sent_With_Form_Electrique(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailElectriqueSent", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Sent_With_Form_Mecanique(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailMecaniqueSent", "MecaniqueManager", new { area = "MecaniqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Rapport_From_Ot_Sent_With_Form_Methodes(AjouterRapportInterventionModel values)
        {
            await PostRapportWithForm(values);
            return RedirectToAction("OrdresTravailMethodeSent", "MethodeManager", new { area = "MethodeManager" });
        }
    }
}