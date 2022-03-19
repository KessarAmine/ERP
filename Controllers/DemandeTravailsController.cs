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
using DevKbfSteel.Models;
using DevKbfSteel.Helpers;
using Microsoft.AspNetCore.Http;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DemandeTravailsController : Controller
    {
        private KBFsteelContext _context;
        private IHttpContextAccessor _accessor;

        public DemandeTravailsController(KBFsteelContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _accessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetSent(DateTime dateDebut, DateTime dateFin,int CodeDemandeur, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ServiceDemandeur = CodeDemandeur;
            var demandetravail = _context.DemandeTravail.Where(c => c.CodeStructure == CodeDemandeur)
                .Where(c => c.DateDt.Date >= dateDebut.Date && c.DateDt.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumDt,
                    i.DateDt,
                    i.CodeUrgence,
                    i.TravailDemandee,
                    i.CodeStructure,
                    i.Note,
                    i.CodeStatut,
                    i.CodeArret,
                    i.Journee,
                    i.Semaine,
                    i.RefMachine,
                    i.CodeReceveur,
                    i.DemandeurOpt,
                    i.MachineOptionel
                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumDt" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(demandetravail, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetRecieved(DateTime dateDebut, DateTime dateFin, int CodeReceveur, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ServiceReceveur = CodeReceveur;
            var demandetravail = _context.DemandeTravail.Where(c => c.CodeReceveur == CodeReceveur)
                .Where(c => c.DateDt.Date >= dateDebut.Date && c.DateDt.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumDt,
                    i.DateDt,
                    i.CodeUrgence,
                    i.TravailDemandee,
                    i.CodeStructure,
                    i.Note,
                    i.CodeStatut,
                    i.CodeArret,
                    i.Journee,
                    i.Semaine,
                    i.RefMachine,
                    i.CodeReceveur
                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumDt" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(demandetravail, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostExploitation(string values)
        {
            var model = new DemandeTravail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.CodeStructure = XpertHelper.CodeExploitation;
            model.CodeStatut = 1;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var demandes = _context.DemandeTravail
                .OrderBy(o => o.NumDt)
                .Select(i => new
                {
                    i.NumDt
                }).ToList();

            if (demandes.Count == 0)
                model.NumDt = 1;
            else
            {
                var m = demandes.Last();
                model.NumDt = Convert.ToInt32(m.NumDt) + 1;
            }
            var result = _context.DemandeTravail.Add(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.Operation = "Post/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();

            return Json(result.Entity.NumDt);
        }
        [HttpPost]
        public async Task<IActionResult> PostMethodes(string values)
        {
            var model = new DemandeTravail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.CodeStructure = XpertHelper.CodeMethode;
            model.CodeStatut = 1;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var demandes = _context.DemandeTravail
                .OrderBy(o => o.NumDt)
                .Select(i => new
                {
                    i.NumDt
                }).ToList();

            if (demandes.Count == 0)
                model.NumDt = 1;
            else
            {
                var m = demandes.Last();
                model.NumDt = Convert.ToInt32(m.NumDt) + 1;
            }
            var result = _context.DemandeTravail.Add(model);

            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.Operation = "Post/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();
            return Json(result.Entity.NumDt);
        }
        [HttpPost]
        public async Task<IActionResult> PostUsinage(string values)
        {
            var model = new DemandeTravail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.CodeStructure = XpertHelper.CodeUsinage;
            model.CodeStatut = 1;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var demandes = _context.DemandeTravail
                .OrderBy(o => o.NumDt)
                .Select(i => new
                {
                    i.NumDt
                }).ToList();

            if (demandes.Count == 0)
                model.NumDt = 1;
            else
            {
                var m = demandes.Last();
                model.NumDt = Convert.ToInt32(m.NumDt) + 1;
            }
            var result = _context.DemandeTravail.Add(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Post/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();
            return Json(result.Entity.NumDt);
        }
        [HttpPost]
        public async Task<IActionResult> PostSodure(string values)
        {
            var model = new DemandeTravail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.CodeStructure = XpertHelper.CodeSodure;
            model.CodeStatut = 1;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var demandes = _context.DemandeTravail
                .OrderBy(o => o.NumDt)
                .Select(i => new
                {
                    i.NumDt
                }).ToList();

            if (demandes.Count == 0)
                model.NumDt = 1;
            else
            {
                var m = demandes.Last();
                model.NumDt = Convert.ToInt32(m.NumDt) + 1;
            }
            var result = _context.DemandeTravail.Add(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Post/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();

            return Json(result.Entity.NumDt);
        }
        [HttpPost]
        public async Task<IActionResult> PostMecanique(string values)
        {
            var model = new DemandeTravail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.CodeStructure = XpertHelper.CodeMecanqiue;
            model.CodeStatut = 1;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var demandes = _context.DemandeTravail
                .OrderBy(o => o.NumDt)
                .Select(i => new
                {
                    i.NumDt
                }).ToList();

            if (demandes.Count == 0)
                model.NumDt = 1;
            else
            {
                var m = demandes.Last();
                model.NumDt = Convert.ToInt32(m.NumDt) + 1;
            }
            var result = _context.DemandeTravail.Add(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Post/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();

            return Json(result.Entity.NumDt);
        }
        [HttpPost]
        public async Task<IActionResult> PostElectrique(string values)
        {
            var model = new DemandeTravail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.CodeStructure = XpertHelper.CodeElectrique;
            model.CodeStatut = 1;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var demandes = _context.DemandeTravail
                .OrderBy(o => o.NumDt)
                .Select(i => new
                {
                    i.NumDt
                }).ToList();

            if (demandes.Count == 0)
                model.NumDt = 1;
            else
            {
                var m = demandes.Last();
                model.NumDt = Convert.ToInt32(m.NumDt) + 1;
            }
            var result = _context.DemandeTravail.Add(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Post/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumDt);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.DemandeTravail.FirstOrDefaultAsync(item => item.NumDt == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Put/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var model = await _context.DemandeTravail.FirstOrDefaultAsync(item => item.NumDt == key);
            var ots = await _context.OrdreTravail.FirstOrDefaultAsync(item => item.NumDt == key);
            if(ots != null)
            {
                return StatusCode(409, "Veullez régler l'Ot correspandate à cette DT");
            }
            _context.DemandeTravail.Remove(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.Operation = "Delete/Dt:Id=" + model.NumDt;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ArreteProductionLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.ArreteProduction
                         orderby i.DesignationArret
                         select new
                         {
                             Value = i.CodeArret,
                             Text = i.DesignationArret
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
        public async Task<IActionResult> EquipementsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.MethStructureMachine
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.Equipement
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DerigantsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.AssStructureDerigants
                         orderby i.CodeDerigant
                         select new
                         {
                             Value = i.Id,
                             Text = i.CodeDerigant
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> IntervenantLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Intervenant
                         orderby i.NmPr
                         select new
                         {
                             Value = i.CodeIntervenant,
                             Text = i.NmPr
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> StatutLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Statut
                         orderby i.Designation
                         select new
                         {
                             Value = i.CodeStatut,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> StructureLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Structure
                         orderby i.Designation
                         select new
                         {
                             Value = i.CodeStructure,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> UrgenceTravailleLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.UrgenceTravaille
                         orderby i.DesignationUrgence
                         select new
                         {
                             Value = i.CodeUrgence,
                             Text = i.DesignationUrgence
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(DemandeTravail model, IDictionary values)
        {
            string NUM_DT = nameof(DemandeTravail.NumDt);
            string DATE_DT = nameof(DemandeTravail.DateDt);
            string CODE_URGENCE = nameof(DemandeTravail.CodeUrgence);
            string TRAVAIL_DEMANDEE = nameof(DemandeTravail.TravailDemandee);
            string CODE_STRUCTURE = nameof(DemandeTravail.CodeStructure);
            string NOTE = nameof(DemandeTravail.Note);
            string CODE_STATUT = nameof(DemandeTravail.CodeStatut);
            string CODE_ARRET = nameof(DemandeTravail.CodeArret);
            string Journee = nameof(DemandeTravail.Journee);
            string Semaine = nameof(DemandeTravail.Semaine);
            string CodeReceveur = nameof(DemandeTravail.CodeReceveur);
            string RefMachine = nameof(DemandeTravail.RefMachine);
            string DemandeurOpt = nameof(DemandeTravail.DemandeurOpt);
            string MachineOptionel = nameof(DemandeTravail.MachineOptionel);

            if (values.Contains(MachineOptionel))
            {
                model.MachineOptionel = Convert.ToString(values[MachineOptionel]);
            }
            if (values.Contains(NUM_DT))
            {
                model.NumDt = Convert.ToInt32(values[NUM_DT]);
            }
            if (values.Contains(DATE_DT))
            {
                model.DateDt = Convert.ToDateTime(values[DATE_DT]);
            }
            if (values.Contains(CODE_URGENCE))
            {
                model.CodeUrgence = Convert.ToBoolean(values[CODE_URGENCE]);
            }
            if (values.Contains(TRAVAIL_DEMANDEE))
            {
                model.TravailDemandee = Convert.ToString(values[TRAVAIL_DEMANDEE]);
            }
            if (values.Contains(CODE_STRUCTURE))
            {
                model.CodeStructure = Convert.ToInt32(values[CODE_STRUCTURE]);
            }
            if (values.Contains(NOTE))
            {
                model.Note = Convert.ToString(values[NOTE]);
            }
            if (values.Contains(CODE_STATUT))
            {
                model.CodeStatut = Convert.ToInt32(values[CODE_STATUT]);
            }
            if (values.Contains(CODE_ARRET))
            {
                model.CodeArret = Convert.ToBoolean(values[CODE_ARRET]);
            }
            if (values.Contains(CodeReceveur))
            {
                model.CodeReceveur = Convert.ToInt32(values[CodeReceveur]);
            }
            if (values.Contains(DemandeurOpt))
            {
                model.DemandeurOpt = Convert.ToInt32(values[DemandeurOpt]);
            }
            if (values.Contains(RefMachine))
            {
                model.RefMachine = Convert.ToString(values[RefMachine]);
            }
            if (values.Contains(Journee))
            {
                model.Journee = Convert.ToBoolean(values[Journee]);
            }
            if (values.Contains(Semaine))
            {
                model.Semaine = Convert.ToBoolean(values[Semaine]);
            }
        }
        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }

}