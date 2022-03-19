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
using DevKbfSteel.Areas.MethodeManager.Models;
using DevKbfSteel.Models;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class AssOtTraveauxController : Controller
    {
        private KBFsteelContext _context;
        public AssOtTraveauxController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsinage(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumOtTaches = id;
            var bonproduction = _context.AssOtTraveaux
                .Where(c => c.NumOt == id)
                .Select(i => new {
                    i.Id,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.Qte,
                    i.TypeTraveaux,
                    i.Autres
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetExploitation(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumOtTaches = id;
            var bonproduction = _context.AssOtTraveaux
                .Where(c => c.NumOt == id)
                .Select(i => new {
                    i.Id,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.Qte,
                    i.TypeTraveaux,
                    i.Autres
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetElectrique(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumOtTaches = id;
            var bonproduction = _context.AssOtTraveaux
                .Where(c => c.NumOt == id)
                .Select(i => new {
                    i.Id,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.Qte,
                    i.TypeTraveaux,
                    i.Autres
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetMecanique(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumOtTaches = id;
            var bonproduction = _context.AssOtTraveaux
                .Where(c => c.NumOt == id)
                .Select(i => new {
                    i.Id,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.Qte,
                    i.TypeTraveaux,
                    i.Autres
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumOtTaches = id;
            var bonproduction = _context.AssOtTraveaux
                .Where(c => c.NumOt == id)
                .Select(i => new {
                    i.Id,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.Qte,
                    i.TypeTraveaux,
                    i.Autres
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetSuiviMethode(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var ordres = _context.OrdreTravail.AsNoTracking().Where(c => c.DateOt.Date <= dateFin.Date && c.DateOt.Date >= dateDebut.Date)
                                .Select(i => new {
                                    i.NumOt
                                }).ToList();
            List<AssOtTraveaux> TraveauxList = new List<AssOtTraveaux>();
            foreach (var itemordres in ordres)
            {
                AssOtTraveaux travail = _context.AssOtTraveaux.AsNoTracking().Where(c => c.NumOt == itemordres.NumOt).FirstOrDefault();
                TraveauxList.Add(travail);
            }
            return Json(DataSourceLoader.Load(TraveauxList.AsEnumerable(), loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetSuivi(DateTime dateDebut, DateTime dateFin, int Structure, DataSourceLoadOptions loadOptions)
        {
            var ordres = _context.OrdreTravail.AsNoTracking().Where(c => c.DateOt.Date <= dateFin.Date && c.DateOt.Date >= dateDebut.Date
                                                                    && c.CodeReceveur == Structure)
                                .Select(i => new {
                                    i.NumOt
                                }).ToList();
            List<AssOtTraveaux> TraveauxList = new List<AssOtTraveaux>();
            foreach (var itemordres in ordres)
            {
                AssOtTraveaux travail = _context.AssOtTraveaux.AsNoTracking().Where(c => c.NumOt == itemordres.NumOt).FirstOrDefault();
                TraveauxList.Add(travail);
            }
            return Json(DataSourceLoader.Load(TraveauxList.AsEnumerable(), loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostExploitation(string values) {
            var model = new AssOtTraveaux();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.NumOt = (int)XpertHelper.NumOtTaches;
            var ordres = _context.AssOtTraveaux
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
            if (model.TypeTraveaux == null)
                model.TypeTraveaux = 0;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            if(model.CodeEquipement != null && model.CodeEquipement != "")
            {
                var info = model.CodeEquipement.ToString();
                var valueelem = info;
                int numericValueelem;
                bool isNumberelem = int.TryParse(valueelem, out numericValueelem);
                if (isNumberelem == true)
                {
                    model.CodeEquipement = Convert.ToString(numericValueelem);
                }
            }
            var result = _context.AssOtTraveaux.Add(model);
            await _context.SaveChangesAsync();
            if(model.CodeEquipement !=null && model.CodeEquipement != "")
            {
                var ordre = _context.OrdreTravail.Where(o => o.NumOt == model.NumOt).FirstOrDefault();
                //checking this with Plannification des operations
                XpertHelper.NumEquipement = Convert.ToInt32(model.CodeEquipement);
                XpertHelper.CodeMachine = Convert.ToInt32(model.CodeMachine);
                //
                RapportIntervention rapport = new RapportIntervention();
                rapport.NumOt = model.NumOt;
                rapport.DateIntervention = ordre.DateOt;
                XpertHelper.DateIntervention = ordre.DateOt;
                await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            }
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostUsinage(string values) {
            var model = new AssOtTraveaux();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.NumOt = (int)XpertHelper.NumOtTaches;
            var ordres = _context.AssOtTraveaux
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
            if (model.TypeTraveaux == null)
                model.TypeTraveaux = 0;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            if(model.CodeEquipement != null && model.CodeEquipement != "")
            {
                var info = model.CodeEquipement.ToString();
                var valueelem = info;
                int numericValueelem;
                bool isNumberelem = int.TryParse(valueelem, out numericValueelem);
                if (isNumberelem == true)
                {
                    model.CodeEquipement = Convert.ToString(numericValueelem);
                }
            }
            var result = _context.AssOtTraveaux.Add(model);
            await _context.SaveChangesAsync();
            if(model.CodeEquipement !=null && model.CodeEquipement != "")
            {
                var ordre = _context.OrdreTravail.Where(o => o.NumOt == model.NumOt).FirstOrDefault();
                //checking this with Plannification des operations
                XpertHelper.NumEquipement = Convert.ToInt32(model.CodeEquipement);
                XpertHelper.CodeMachine = Convert.ToInt32(model.CodeMachine);
                //
                RapportIntervention rapport = new RapportIntervention();
                rapport.NumOt = model.NumOt;
                rapport.DateIntervention = ordre.DateOt;
                XpertHelper.DateIntervention = ordre.DateOt;
                await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            }
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostElectrique(string values) {
            var model = new AssOtTraveaux();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.NumOt = (int)XpertHelper.NumOtTaches;
            var ordres = _context.AssOtTraveaux
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
            if (model.TypeTraveaux == null)
                model.TypeTraveaux = 0;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            if(model.CodeEquipement != null && model.CodeEquipement != "")
            {
                var info = model.CodeEquipement.ToString();
                var valueelem = info;
                int numericValueelem;
                bool isNumberelem = int.TryParse(valueelem, out numericValueelem);
                if (isNumberelem == true)
                {
                    model.CodeEquipement = Convert.ToString(numericValueelem);
                }
            }
            var result = _context.AssOtTraveaux.Add(model);
            await _context.SaveChangesAsync();
            if(model.CodeEquipement !=null && model.CodeEquipement != "")
            {
                var ordre = _context.OrdreTravail.Where(o => o.NumOt == model.NumOt).FirstOrDefault();
                //checking this with Plannification des operations
                XpertHelper.NumEquipement = Convert.ToInt32(model.CodeEquipement);
                XpertHelper.CodeMachine = Convert.ToInt32(model.CodeMachine);
                //
                RapportIntervention rapport = new RapportIntervention();
                rapport.NumOt = model.NumOt;
                rapport.DateIntervention = ordre.DateOt;
                XpertHelper.DateIntervention = ordre.DateOt;
                await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            }
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostMecanique(string values) {
            var model = new AssOtTraveaux();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.NumOt = (int)XpertHelper.NumOtTaches;
            var ordres = _context.AssOtTraveaux
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
            if (model.TypeTraveaux == null)
                model.TypeTraveaux = 0;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            if(model.CodeEquipement != null && model.CodeEquipement != "")
            {
                var info = model.CodeEquipement.ToString();
                var valueelem = info;
                int numericValueelem;
                bool isNumberelem = int.TryParse(valueelem, out numericValueelem);
                if (isNumberelem == true)
                {
                    model.CodeEquipement = Convert.ToString(numericValueelem);
                }
            }
            var result = _context.AssOtTraveaux.Add(model);
            await _context.SaveChangesAsync();
            if(model.CodeEquipement !=null && model.CodeEquipement != "")
            {
                var ordre = _context.OrdreTravail.Where(o => o.NumOt == model.NumOt).FirstOrDefault();
                //checking this with Plannification des operations
                XpertHelper.NumEquipement = Convert.ToInt32(model.CodeEquipement);
                XpertHelper.CodeMachine = Convert.ToInt32(model.CodeMachine);
                //
                RapportIntervention rapport = new RapportIntervention();
                rapport.NumOt = model.NumOt;
                rapport.DateIntervention = ordre.DateOt;
                XpertHelper.DateIntervention = ordre.DateOt;
                await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            }
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new AssOtTraveaux();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.NumOt = (int)XpertHelper.NumOtTaches;
            var ordres = _context.AssOtTraveaux
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
            if (model.TypeTraveaux == null)
                model.TypeTraveaux = 0;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            if(model.CodeEquipement != null && model.CodeEquipement != "")
            {
                var info = model.CodeEquipement.ToString();
                var valueelem = info;
                int numericValueelem;
                bool isNumberelem = int.TryParse(valueelem, out numericValueelem);
                if (isNumberelem == true)
                {
                    model.CodeEquipement = Convert.ToString(numericValueelem);
                }
            }
            var result = _context.AssOtTraveaux.Add(model);
            await _context.SaveChangesAsync();
            if(model.CodeEquipement !=null && model.CodeEquipement != "")
            {
                var ordre = _context.OrdreTravail.Where(o => o.NumOt == model.NumOt).FirstOrDefault();
                //checking this with Plannification des operations
                XpertHelper.NumEquipement = Convert.ToInt32(model.CodeEquipement);
                XpertHelper.CodeMachine = Convert.ToInt32(model.CodeMachine);
                //
                RapportIntervention rapport = new RapportIntervention();
                rapport.NumOt = model.NumOt;
                rapport.DateIntervention = ordre.DateOt;
                XpertHelper.DateIntervention = ordre.DateOt;
                await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            }
            return Json(result.Entity.Id);
        }
        public async Task PostOtWithFormUsinage(EditerOrdreTravailModel values)
        {
            var model = new OrdreTravail();
            model.CodeDemandeur = XpertHelper.CodeUsinage;
            model.CodeReceveur = XpertHelper.CodeUsinage;
            model.DateOt = values.DateOt;
            model.HeureInstallation = values.HeureInstallation;
            model.CodeMaintenance = Convert.ToBoolean(values.CodeMaintenance);
            model.DateOt.AddHours(1.0);
            var ordres = _context.OrdreTravail.AsNoTracking()
            .OrderBy(o => o.NumOt)
            .Select(i => new
            {
                i.NumOt
            }).ToList();
            if (ordres.Count == 0)
                model.NumOt = 1;
            else
            {
                var m = ordres.Last();
                model.NumOt = Convert.ToInt32(m.NumOt) + 1;
            }
            if (!(XpertHelper.CodeMachine.Equals(null) || XpertHelper.CodeMachine == 0))
                model.CodeMachine = XpertHelper.CodeMachine;
            if (!values.NumEquipement.Equals(null))
            {
                model.NumEquipement = values.NumEquipement;
            }

            if (!(XpertHelper.NumDt.Equals(null) || XpertHelper.NumDt == 0))
            {
                model.NumDt = XpertHelper.NumDt;
                var det = _context.DemandeTravail.Where(o => o.NumDt == model.NumDt).FirstOrDefault();
                det.CodeStatut = 0;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            var result = _context.OrdreTravail.Add(model);
            _context.SaveChanges();
            var travaux = _context.TempAssOtTravaux.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.Autres,
                    i.TypeTraveaux,
                    i.Qte
                }).ToList();
            foreach (var itemtravaux in travaux)
            {
                AssOtTraveaux modele = new AssOtTraveaux();
                modele.NumOt = model.NumOt;
                modele.Autres = itemtravaux.Autres;
                modele.Qte = itemtravaux.Qte;
                modele.TypeTraveaux = itemtravaux.TypeTraveaux;
                modele.CodeEquipement = itemtravaux.CodeEquipement.ToString();
                modele.CodeMachine = itemtravaux.CodeMachine;
                //Do Post to AssOtTravaux
                await TempAssOtTravauxController.PostToAssOtTravaux(_context, modele);
            }
             _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_AssOtTravaux");
        }
        public async Task PostOtWithFormSodure(EditerOrdreTravailModel values)
        {
            var model = new OrdreTravail();
            model.CodeDemandeur = XpertHelper.CodeSodure;
            model.CodeReceveur = XpertHelper.CodeSodure;
            model.DateOt = values.DateOt;
            model.HeureInstallation = values.HeureInstallation;
            model.CodeMaintenance = Convert.ToBoolean(values.CodeMaintenance);
            model.DateOt.AddHours(1.0);
            var ordres = _context.OrdreTravail.AsNoTracking()
            .OrderBy(o => o.NumOt)
            .Select(i => new
            {
                i.NumOt
            }).ToList();
            if (ordres.Count == 0)
                model.NumOt = 1;
            else
            {
                var m = ordres.Last();
                model.NumOt = Convert.ToInt32(m.NumOt) + 1;
            }
            if (!(XpertHelper.CodeMachine.Equals(null) || XpertHelper.CodeMachine == 0))
                model.CodeMachine = XpertHelper.CodeMachine;
            if (!values.NumEquipement.Equals(null))
            {
                model.NumEquipement = values.NumEquipement;
            }

            if (!(XpertHelper.NumDt.Equals(null) || XpertHelper.NumDt == 0))
            {
                model.NumDt = XpertHelper.NumDt;
                var det = _context.DemandeTravail.Where(o => o.NumDt == model.NumDt).FirstOrDefault();
                det.CodeStatut = 0;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            var result = _context.OrdreTravail.Add(model);
            _context.SaveChanges();
            var travaux = _context.TempAssOtTravaux.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.Autres,
                    i.TypeTraveaux,
                    i.Qte
                }).ToList();
            foreach (var itemtravaux in travaux)
            {
                AssOtTraveaux modele = new AssOtTraveaux();
                modele.NumOt = model.NumOt;
                modele.Autres = itemtravaux.Autres;
                modele.Qte = itemtravaux.Qte;
                modele.TypeTraveaux = itemtravaux.TypeTraveaux;
                modele.CodeEquipement = itemtravaux.CodeEquipement.ToString();
                modele.CodeMachine = itemtravaux.CodeMachine;
                //Do Post to AssOtTravaux
                await TempAssOtTravauxController.PostToAssOtTravaux(_context, modele);
            }
             _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_AssOtTravaux");
        }
        public async Task PostOtWithFormMecanique(EditerOrdreTravailModel values)
        {
            var model = new OrdreTravail();
            model.CodeDemandeur = XpertHelper.CodeMecanqiue;
            model.CodeReceveur = XpertHelper.CodeMecanqiue;
            model.DateOt = values.DateOt;
            model.HeureInstallation = values.HeureInstallation;
            model.CodeMaintenance = Convert.ToBoolean(values.CodeMaintenance);
            var ordres = _context.OrdreTravail.AsNoTracking()
            .OrderBy(o => o.NumOt)
            .Select(i => new
            {
                i.NumOt
            }).ToList();
            if (ordres.Count == 0)
                model.NumOt = 1;
            else
            {
                var m = ordres.Last();
                model.NumOt = Convert.ToInt32(m.NumOt) + 1;
            }
            if (!values.NumEquipement.Equals(null))
            {
                model.NumEquipement = values.NumEquipement;
            }

            if (!(XpertHelper.NumDt.Equals(null) || XpertHelper.NumDt == 0))
            {
                model.NumDt = XpertHelper.NumDt;
                var det = _context.DemandeTravail.Where(o => o.NumDt == model.NumDt).FirstOrDefault();
                det.CodeStatut = 0;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            var result = _context.OrdreTravail.Add(model);
            _context.SaveChanges();
            var travaux = _context.TempAssOtTravaux.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.Autres,
                    i.TypeTraveaux,
                    i.Qte
                }).ToList();
            foreach (var itemtravaux in travaux)
            {
                AssOtTraveaux modele = new AssOtTraveaux();
                modele.NumOt = model.NumOt;
                modele.Autres = itemtravaux.Autres;
                modele.Qte = itemtravaux.Qte;
                modele.TypeTraveaux = itemtravaux.TypeTraveaux;
                modele.CodeEquipement = itemtravaux.CodeEquipement.ToString();
                modele.CodeMachine = itemtravaux.CodeMachine;
                if(model.CodeMachine==null)
                    model.CodeMachine = modele.CodeMachine;
                if (model.NumEquipement == null)
                    model.NumEquipement = Convert.ToInt32(modele.CodeEquipement);
                //Do Post to AssOtTravaux
                await TempAssOtTravauxController.PostToAssOtTravaux(_context, modele);
            }
             _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_AssOtTravaux");
        }
        public async Task PostOtWithFormElectrique(EditerOrdreTravailModel values)
        {
            var model = new OrdreTravail();
            model.CodeDemandeur = XpertHelper.CodeElectrique;
            if(values.CodeReceveur == null)
            {
                model.CodeReceveur = XpertHelper.CodeElectrique;

            }
            else
            {
                model.CodeReceveur = (int)values.CodeReceveur;
            }
            model.DateOt = values.DateOt;
            model.HeureInstallation = values.HeureInstallation;
            model.CodeMaintenance = Convert.ToBoolean(values.CodeMaintenance);
            var ordres = _context.OrdreTravail.AsNoTracking()
            .OrderBy(o => o.NumOt)
            .Select(i => new
            {
                i.NumOt
            }).ToList();
            if (ordres.Count == 0)
                model.NumOt = 1;
            else
            {
                var m = ordres.Last();
                model.NumOt = Convert.ToInt32(m.NumOt) + 1;
            }
            if (!(XpertHelper.CodeMachine.Equals(null) || XpertHelper.CodeMachine == 0))
                model.CodeMachine = XpertHelper.CodeMachine;
            if (!values.NumEquipement.Equals(null))
            {
                model.NumEquipement = values.NumEquipement;
            }

            if (!(XpertHelper.NumDt.Equals(null) || XpertHelper.NumDt == 0))
            {
                model.NumDt = XpertHelper.NumDt;
                var det = _context.DemandeTravail.Where(o => o.NumDt == model.NumDt).FirstOrDefault();
                det.CodeStatut = 0;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            var result = _context.OrdreTravail.Add(model);
            _context.SaveChanges();
            var travaux = _context.TempAssOtTravaux.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.Autres,
                    i.TypeTraveaux,
                    i.Qte
                }).ToList();
            foreach (var itemtravaux in travaux)
            {
                AssOtTraveaux modele = new AssOtTraveaux();
                modele.NumOt = model.NumOt;
                modele.Autres = itemtravaux.Autres;
                modele.Qte = itemtravaux.Qte;
                modele.TypeTraveaux = itemtravaux.TypeTraveaux;
                modele.CodeEquipement = itemtravaux.CodeEquipement.ToString();
                modele.CodeMachine = itemtravaux.CodeMachine;
                //Do Post to AssOtTravaux
                await TempAssOtTravauxController.PostToAssOtTravaux(_context, modele);
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_AssOtTravaux");
        }
        public async Task PostOtWithFormExploitation(EditerOrdreTravailModel values)
        {
            var model = new OrdreTravail();
            model.CodeDemandeur = XpertHelper.CodeExploitation;
            if(values.CodeReceveur == null)
            {
                model.CodeReceveur = XpertHelper.CodeExploitation;

            }
            else
            {
                model.CodeReceveur = (int)values.CodeReceveur;
            }
            model.DateOt = values.DateOt;
            model.HeureInstallation = values.HeureInstallation;
            model.CodeMaintenance = Convert.ToBoolean(values.CodeMaintenance);
            var ordres = _context.OrdreTravail.AsNoTracking()
            .OrderBy(o => o.NumOt)
            .Select(i => new
            {
                i.NumOt
            }).ToList();
            if (ordres.Count == 0)
                model.NumOt = 1;
            else
            {
                var m = ordres.Last();
                model.NumOt = Convert.ToInt32(m.NumOt) + 1;
            }
            if (!(XpertHelper.CodeMachine.Equals(null) || XpertHelper.CodeMachine == 0))
                model.CodeMachine = XpertHelper.CodeMachine;
            if (!values.NumEquipement.Equals(null))
            {
                model.NumEquipement = values.NumEquipement;
            }

            if (!(XpertHelper.NumDt.Equals(null) || XpertHelper.NumDt == 0))
            {
                model.NumDt = XpertHelper.NumDt;
                var det = _context.DemandeTravail.Where(o => o.NumDt == model.NumDt).FirstOrDefault();
                det.CodeStatut = 0;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            var result = _context.OrdreTravail.Add(model);
            _context.SaveChanges();
            var travaux = _context.TempAssOtTravaux.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.Autres,
                    i.TypeTraveaux,
                    i.Qte
                }).ToList();
            foreach (var itemtravaux in travaux)
            {
                AssOtTraveaux modele = new AssOtTraveaux();
                modele.NumOt = model.NumOt;
                modele.Autres = itemtravaux.Autres;
                modele.Qte = itemtravaux.Qte;
                modele.TypeTraveaux = itemtravaux.TypeTraveaux;
                modele.CodeEquipement = itemtravaux.CodeEquipement.ToString();
                modele.CodeMachine = itemtravaux.CodeMachine;

                //Do Post to AssOtTravaux
                await TempAssOtTravauxController.PostToAssOtTravaux(_context, modele);
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_AssOtTravaux");
        }
        public async Task PostOtWithFormMethodes(EditerOrdreTravailModel values)
        {
            var model = new OrdreTravail();
            model.CodeDemandeur = XpertHelper.CodeMethode;
            if(values.CodeReceveur == null)
            {
                model.CodeReceveur = XpertHelper.CodeMethode;

            }
            else
            {
                model.CodeReceveur = (int)values.CodeReceveur;
            }
            model.DateOt = values.DateOt;
            model.HeureInstallation = values.HeureInstallation;
            model.CodeMaintenance = Convert.ToBoolean(values.CodeMaintenance);
            model.DateOt.AddHours(1.0);
            var ordres = _context.OrdreTravail.AsNoTracking()
            .OrderBy(o => o.NumOt)
            .Select(i => new
            {
                i.NumOt
            }).ToList();
            if (ordres.Count == 0)
                model.NumOt = 1;
            else
            {
                var m = ordres.Last();
                model.NumOt = Convert.ToInt32(m.NumOt) + 1;
            }
            if (!(XpertHelper.CodeMachine.Equals(null) || XpertHelper.CodeMachine == 0))
                model.CodeMachine = XpertHelper.CodeMachine;
            if (!values.NumEquipement.Equals(null))
            {
                model.NumEquipement = values.NumEquipement;
            }

            if (!(XpertHelper.NumDt.Equals(null) || XpertHelper.NumDt == 0))
            {
                model.NumDt = XpertHelper.NumDt;
                var det = _context.DemandeTravail.Where(o => o.NumDt == model.NumDt).FirstOrDefault();
                det.CodeStatut = 0;
                var updateDt = _context.DemandeTravail.Update(det);
            }
            var result = _context.OrdreTravail.Add(model);
            _context.SaveChanges();
            var travaux = _context.TempAssOtTravaux.AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.Autres,
                    i.TypeTraveaux,
                    i.Qte
                }).ToList();
            foreach (var itemtravaux in travaux)
            {
                AssOtTraveaux modele = new AssOtTraveaux();
                modele.NumOt = model.NumOt;
                modele.Autres = itemtravaux.Autres;
                modele.Qte = itemtravaux.Qte;
                modele.TypeTraveaux = itemtravaux.TypeTraveaux;
                modele.CodeEquipement = itemtravaux.CodeEquipement.ToString();
                modele.CodeMachine = itemtravaux.CodeMachine;
                //Do Post to AssOtTravaux
                await TempAssOtTravauxController.PostToAssOtTravaux(_context, modele);
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_AssOtTravaux");
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Dt_Recieved_With_Form_Exploitation(EditerOrdreTravailModel values)
        {
            await PostOtWithFormExploitation(values);
            return RedirectToAction("DemandeTravailsExploitationRecieved", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Dt_Recieved_With_Form_Electrique(EditerOrdreTravailModel values)
        {
            await PostOtWithFormElectrique(values);
            return RedirectToAction("DemandeTravailsElectriqueRecieved", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Dt_Recieved_With_Form_Mecanique(EditerOrdreTravailModel values)
        {
            await PostOtWithFormMecanique(values);
            return RedirectToAction("DemandeTravailsMecaniqueRecieved", "MecaniqueManager", new { area = "MecaniqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Dt_Recieved_With_Form_Usinage(EditerOrdreTravailModel values)
        {
            await PostOtWithFormUsinage(values);
            return RedirectToAction("DemandeTravailsUsinageRecieved", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Dt_Recieved_With_Form_Sodure(EditerOrdreTravailModel values)
        {
            await PostOtWithFormSodure(values);
            return RedirectToAction("DemandeTravailsSodureRecieved", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Dt_Recieved_With_Form_Methode(EditerOrdreTravailModel values)
        {
            await PostOtWithFormMethodes(values);
            return RedirectToAction("DemandeTravailsMethodeRecieved", "MethodeManager", new { area = "MethodeManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Ot_Sent_With_Form_Exploitation(EditerOrdreTravailModel values)
        {
            await PostOtWithFormExploitation(values);
            return RedirectToAction("OrdresTravailExploitationSent", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Ot_Sent_With_Form_Usinage(EditerOrdreTravailModel values)
        {
            await PostOtWithFormUsinage(values);
            return RedirectToAction("OrdresTravailUsinageSent", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Ot_Sent_With_Form_Sodure(EditerOrdreTravailModel values)
        {
            await PostOtWithFormSodure(values);
            return RedirectToAction("OrdresTravailSodureSent", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Ot_Sent_With_Form_Electrique(EditerOrdreTravailModel values)
        {
            await PostOtWithFormElectrique(values);
            return RedirectToAction("OrdresTravailElectriqueSent", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Ot_Sent_With_Form_Mecanique(EditerOrdreTravailModel values)
        {
            await PostOtWithFormMecanique(values);
            return RedirectToAction("OrdresTravailMecaniqueSent", "MecaniqueManager", new { area = "MecaniqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Ot_From_Ot_Sent_With_Form_Methodes(EditerOrdreTravailModel values)
        {
            await PostOtWithFormMethodes(values);
            return RedirectToAction("OrdresTravailMethodeSent", "MethodeManager", new { area = "MethodeManager" });
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.AssOtTraveaux.FirstOrDefaultAsync(item => item.Id == key);
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);

            //First we clear the preventif from the old
            var ordre = _context.OrdreTravail.Where(o => o.NumOt == model.NumOt).FirstOrDefault();
            //checking this with Plannification des operations

            //
            RapportIntervention rapport = new RapportIntervention();
            rapport.NumOt = model.NumOt;
            rapport.DateIntervention = ordre.DateOt;
            XpertHelper.DateIntervention = ordre.DateOt;
            await XpertHelper.CheckOtOperationFromRapportInterventions(_context, rapport);
            
            if (model == null)
                return StatusCode(409, "Object not found");

            PopulateModel(model, valuesDict);
            if (model.TypeTraveaux == null)
                model.TypeTraveaux = 0;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.AssOtTraveaux.FirstOrDefaultAsync(item => item.Id == key);
            //TODO : Get Last Plannification of that Op
            var DesignationTraveau = _context.LookupTypeTraveauxOt.AsNoTracking().Where(c => c.Id == model.TypeTraveaux).FirstOrDefault();
            if(model.CodeEquipement !=null && model.CodeEquipement != "")
            {
                var methOperation = _context.MethOperations.AsNoTracking()
                    .Where(c => c.NumMachine == Convert.ToInt32(model.CodeMachine) && c.NumEquipement == Convert.ToInt32(model.CodeEquipement) && c.Description == DesignationTraveau.Designation).FirstOrDefault();
                if (methOperation != null)
                {
                    var oT = _context.OrdreTravail.AsNoTracking().Where(c => c.NumOt == model.NumOt).FirstOrDefault();
                    var Todelete = _context.MethAppointementsPreventifs.Where(c => c.IdOperation == methOperation.Idoperation && c.StartDate == oT.DateOt).FirstOrDefault();
                    if (Todelete != null)
                    {
                        _context.MethAppointementsPreventifs.Remove(Todelete);
                        await _context.SaveChangesAsync();
                    }
                    var planning = _context.MethAppointementsPreventifs
                        .AsNoTracking()
                    .Where(c => c.IdOperation == methOperation.Idoperation && c.StartDate < oT.DateOt)
                    .Select(i => new
                    {
                        i.IdOperation,
                        i.StartDate
                    }).ToList();
                    if (planning.Count != 0)
                    {
                        var idp = planning.Last();
                        XpertHelper.DateIntervention = idp.StartDate;
                        XpertHelper.IdOperation = idp.IdOperation;
                        var operation = _context.MethOperations
                        .AsNoTracking()
                        .Where(c => c.Idoperation == XpertHelper.IdOperation)
                        .Select(i => new
                        {
                            i.Idoperation,
                            i.Description,
                            i.Fréquence,
                            i.NumEquipement,
                            i.NumMachine,
                            i.Unité
                        }).ToList();
                        var idOp = operation.Last();
                        List<PlanningOperationsModel> planningOperationsModels = new List<PlanningOperationsModel>();
                        foreach (var itemoperations in operation)
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
                        var wt = await XpertHelper.CheckOtOperation(_context, planningOperationsModels, 1);
                    }
                }
            }
            _context.AssOtTraveaux.Remove(model);
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
        [HttpGet]
        public async Task<IActionResult> TypeMaintenanceLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.TypeMaintenance
                         orderby i.CodeMaintenance
                         select new
                         {
                             Value = i.CodeMaintenance,
                             Text = i.DesignationMaintenance
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeMaintenanceErrorLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.DebugMaitenanceType
                         orderby i.IdMaint
                         select new
                         {
                             Value = i.IdMaint,
                             Text = i.DesignationMaint
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeTraveauxLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupTypeTraveauxOt
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DateInterventionLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RapportIntervention
                         orderby i.NumIntervention
                         select new
                         {
                             Value = i.NumOt,
                             Text = i.DateIntervention.Date.ToString()
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> ServiceLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.OrdreTravail
                         orderby i.NumOt
                         select new
                         {
                             Value = i.NumOt,
                             Text = i.CodeReceveur
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DureeInterventionLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RapportIntervention
                         orderby i.NumIntervention
                         select new
                         {
                             Value = i.NumOt,
                             Text = i.DureeIntervention
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(AssOtTraveaux model, IDictionary values) {

            string Id = nameof(AssOtTraveaux.Id);
            string NumOt = nameof(AssOtTraveaux.NumOt);
            string CodeEquipement = nameof(AssOtTraveaux.CodeEquipement);
            string CodeMachine = nameof(AssOtTraveaux.CodeMachine);
            string TypeTraveaux = nameof(AssOtTraveaux.TypeTraveaux);
            string Qte = nameof(AssOtTraveaux.Qte);
            string Autres = nameof(AssOtTraveaux.Autres);

            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(NumOt))
            {
                model.NumOt = Convert.ToInt32(values[NumOt]);
            }
            if (values.Contains(CodeEquipement))
            {
                var CodePdrvar = values[CodeEquipement];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeEquipement = Convert.ToString(CodePdrSplited);
            }
            if (values.Contains(CodeMachine))
            {
                model.CodeMachine = Convert.ToInt32(values[CodeMachine]);
            }
            if (values.Contains(TypeTraveaux))
            {
                model.TypeTraveaux = Convert.ToInt32(values[TypeTraveaux]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(Autres))
            {
                model.Autres = Convert.ToString(values[Autres]);
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