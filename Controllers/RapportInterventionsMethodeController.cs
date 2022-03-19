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
using DevKbfSteel.Areas.MethodeManager.Models;
using DevKbfSteel.Helpers;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class RapportInterventionsMethodeController : Controller
    {
        private KBFsteelContext _context;
        public RapportInterventionsMethodeController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumOt = id;
            var rapportintervention = _context.RapportIntervention.Where(c => c.NumOt == id)
                .Select(i => new {
                i.NumIntervention,
                i.DateIntervention,
                i.DebutIntervention,
                i.DureeIntervention,
                i.Observation,
                i.CompteRendu,
                i.NumOt
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumIntervention" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rapportintervention, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDt(int id, DataSourceLoadOptions loadOptions)
        {
            if (XpertHelper.NumOt == null)
            {
                XpertHelper.NumOt = 0;
                return BadRequest("Précisez à quelle Ot ce rapport appartient");
            }
            var rapportintervention = _context.RapportIntervention.Where(c => c.NumOt == XpertHelper.NumOt)
                .Select(i => new {
                    i.NumIntervention,
                    i.DateIntervention,
                    i.DebutIntervention,
                    i.DureeIntervention,
                    i.Observation,
                    i.CompteRendu,
                    i.NumOt
                });
            var rapports = _context.RapportIntervention.Where(c => c.NumOt == XpertHelper.NumOt)
            .Select(i => new {
                i.DateIntervention
            }).ToList();
            if(rapports.Count != 0)
            {
                var lastRa = rapports.Last();
                XpertHelper.DateIntervention = lastRa.DateIntervention;
            }
            return Json(await DataSourceLoader.LoadAsync(rapportintervention, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDtRapport(int id, DataSourceLoadOptions loadOptions)
        {
            var ordre = _context.OrdreTravail.AsNoTracking().Where(c => c.NumDt == id).FirstOrDefault();
            var Ot = 0;
            if (ordre != null)
            {
                Ot = ordre.NumOt;
            }
            var rapportintervention = _context.RapportIntervention.Where(c => c.NumOt == Ot)
                .Select(i => new {
                    i.NumIntervention,
                    i.DateIntervention,
                    i.DebutIntervention,
                    i.DureeIntervention,
                    i.Observation,
                    i.CompteRendu,
                    i.NumOt
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumIntervention" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rapportintervention, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new RapportIntervention();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            //=======================
            var interventions = _context.RapportIntervention
             .OrderBy(o => o.NumIntervention)
             .Select(i => new
             {
                 i.NumIntervention
             }).ToList();
            var m = interventions.Last();
            model.NumIntervention = Convert.ToInt32(m.NumIntervention) + 1;
            model.NumOt = (int)XpertHelper.NumOt;
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
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumIntervention);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.RapportIntervention.FirstOrDefaultAsync(item => item.NumIntervention == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            XpertHelper.DateIntervention = model.DateIntervention;
            await XpertHelper.ClearPlanningPreventif(_context);

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            XpertHelper.DateIntervention = model.DateIntervention;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            RapportIntervention rapport = new RapportIntervention();
            rapport.NumOt = model.NumOt;
            rapport.DateIntervention = model.DateIntervention;
            await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.RapportIntervention.FirstOrDefaultAsync(item => item.NumIntervention == key);
            var ordre = _context.OrdreTravail.Where(c => c.NumOt == model.NumOt)
            .Select(i => new
            {
                i.NumDt,
                i.CodeMachine,
                i.NumEquipement
            }).ToList();
            var dto = ordre[0];
            XpertHelper.DateIntervention = model.DateIntervention;
            //TODO : Get Last Plannification of that Op

            var operations = _context.MethOperations.Where(c => c.NumMachine == XpertHelper.CodeMachine && c.NumEquipement == dto.NumEquipement)
            .Select(i => new
            {
                i.Idoperation,
                i.Description,
                i.Fréquence,
                i.NumEquipement,
                i.NumMachine,
                i.Unité
            }).ToList();
            if (operations.Count> 0)
            {
                var idOp = operations.Last();
                XpertHelper.IdOperation = idOp.Idoperation;
                await XpertHelper.ClearPlanningPreventif(_context);

                List<PlanningOperationsModel> planningOperationsModels = new List<PlanningOperationsModel>();
                foreach (var itemoperations in operations)
                {
                    PlanningOperationsModel planningOperationsModel = new PlanningOperationsModel();
                    planningOperationsModel.Idoperation = itemoperations.Idoperation;
                    planningOperationsModel.Fréquence = itemoperations.Fréquence;
                    planningOperationsModel.Unité = itemoperations.Unité;
                    planningOperationsModel.Description = itemoperations.Description;
                    planningOperationsModel.NumEquipement = itemoperations.NumEquipement;
                    planningOperationsModel.NumMachine = itemoperations.NumMachine;
                    planningOperationsModels.Add(planningOperationsModel);
                }

                //TODO: To check this
                var toRetrun = await _context.MethPlanningPreventif
                       .FirstOrDefaultAsync(item => item.DateRealisation <= XpertHelper.DateIntervention && item.IdOperation == XpertHelper.IdOperation);
                RapportIntervention rapport = new RapportIntervention();
                rapport.NumOt = model.NumOt;
                XpertHelper.DateIntervention = model.DateIntervention;
                await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            }
            _context.RapportIntervention.Remove(model);
            var det = _context.DemandeTravail.Where(o => o.NumDt == dto.NumDt).FirstOrDefault();
            if(det != null)
            {
                det.CodeStatut = 0;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            await _context.SaveChangesAsync();

        }
        [HttpGet]
        public async Task<IActionResult> OrdreTravailLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.OrdreTravail
                         orderby i.NumDt
                         select new {
                             Value = i.NumOt,
                             Text = i.NumDt
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(RapportIntervention model, IDictionary values) {
            string NUM_INTERVENTION = nameof(RapportIntervention.NumIntervention);
            string DATE_INTERVENTION = nameof(RapportIntervention.DateIntervention);
            string DEBUT_INTERVENTION = nameof(RapportIntervention.DebutIntervention);
            string DUREE_INTERVENTION = nameof(RapportIntervention.DureeIntervention);
            string OBSERVATION = nameof(RapportIntervention.Observation);
            string COMPTE_RENDU = nameof(RapportIntervention.CompteRendu);
            string NUM_OT = nameof(RapportIntervention.NumOt);

            if(values.Contains(NUM_INTERVENTION)) {
                model.NumIntervention = Convert.ToInt32(values[NUM_INTERVENTION]);
            }

            if(values.Contains(DATE_INTERVENTION)) {
                model.DateIntervention = Convert.ToDateTime(values[DATE_INTERVENTION]);
            }

            if(values.Contains(DEBUT_INTERVENTION)) {
                model.DebutIntervention = Convert.ToDateTime(values[DEBUT_INTERVENTION]);
            }

            if(values.Contains(DUREE_INTERVENTION)) {
                model.DureeIntervention = Convert.ToInt32(values[DUREE_INTERVENTION]);
            }

            if(values.Contains(OBSERVATION)) {
                model.Observation = Convert.ToString(values[OBSERVATION]);
            }

            if(values.Contains(COMPTE_RENDU)) {
                model.CompteRendu = Convert.ToString(values[COMPTE_RENDU]);
            }

            if(values.Contains(NUM_OT)) {
                model.NumOt = Convert.ToInt32(values[NUM_OT]);
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
    }
}