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

    public class ApproDemandeServiceController : Controller
    {
        private KBFsteelContext _context;
        public ApproDemandeServiceController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetService(DateTime dateDebut, DateTime dateFin,int structure, DataSourceLoadOptions loadOptions) {
            var approDemandesService = _context.ApproDemandeService
                .Where(c => c.DateDemande.Date >= dateDebut.Date && c.DateDemande.Date <= dateFin.Date
                        && c.CodeServiceDemandeur == structure)
                .Select(i => new {
                    i.NumeroDemandeService,
                    i.DateDemande,
                    i.CodeServiceReceveur,
                    i.Observation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approDemandesService, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceDetail(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDemandeService = id;
            var approDemandesFourniture = _context.ApproDemandeServiceDetail
                .Where(c => c.NumeroDemandeService == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.ServiceDemande
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approDemandesFourniture, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceDetailTemp(int id, DataSourceLoadOptions loadOptions)
        {
            var approDemandesFourniture = _context.TempApproDemandeServiceDetail
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.ServiceDemande
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approDemandesFourniture, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostDetail(AjouterDetailServiceModel values)
        {
            var model = new ApproDemandeServiceDetail();
            var ordres = _context.ApproDemandeServiceDetail
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
            model.NumeroDemandeService = (int)XpertHelper.NumDemandeService;
            model.CodeArticle = values.CodeArticle;
            model.ServiceDemande = values.ServiceDemande;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.ApproDemandeServiceDetail.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("DemandeService", "MecaniqueManager", new { area = "MecaniqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> PostDetailTemp(string values)
        {
            var model = new TempApproDemandeServiceDetail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelServiceDetailTemp(model, valuesDict);
            var ordres = _context.TempApproDemandeServiceDetail
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
            var result = _context.TempApproDemandeServiceDetail.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.ApproDemandeService.FirstOrDefaultAsync(item => item.NumeroDemandeService == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetail(int key, string values) {
            var model = await _context.ApproDemandeServiceDetail.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelServiceDetail(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetailTemp(int key, string values) {
            var model = await _context.TempApproDemandeServiceDetail.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelServiceDetailTemp(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.ApproDemandeService.FirstOrDefaultAsync(item => item.NumeroDemandeService == key);
            _context.ApproDemandeService.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetail(int key) {
            var model = await _context.ApproDemandeServiceDetail.FirstOrDefaultAsync(item => item.Id == key);
            _context.ApproDemandeServiceDetail.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetailTemp(int key) {
            var model = await _context.TempApproDemandeServiceDetail.FirstOrDefaultAsync(item => item.Id == key);
            _context.TempApproDemandeServiceDetail.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Post_Service_From_With_Form_Usinage(DemandeServiceModel values)
        {
            await PostServiceDetail(values, XpertHelper.CodeUsinage);
            return RedirectToAction("DemandeService", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Service_From_With_Form_Sodure(DemandeServiceModel values)
        {
            await PostServiceDetail(values, XpertHelper.CodeSodure);
            return RedirectToAction("DemandeService", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Service_From_With_Form_Mecanique(DemandeServiceModel values)
        {
            await PostServiceDetail(values, XpertHelper.CodeMecanqiue);
            return RedirectToAction("DemandeService", "MecaniqueManager", new { area = "MecaniqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Service_From_With_Form_Exploitation(DemandeServiceModel values)
        {
            await PostServiceDetail(values, XpertHelper.CodeExploitation);
            return RedirectToAction("DemandeService", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Service_From_With_Form_Electrique(DemandeServiceModel values)
        {
            await PostServiceDetail(values, XpertHelper.CodeElectrique);
            return RedirectToAction("DemandeService", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Service_From_With_Form_Methode(DemandeServiceModel values)
        {
            await PostServiceDetail(values, XpertHelper.CodeMethode);
            return RedirectToAction("DemandeService", "MethodeManager", new { area = "MethodeManager" });
        }
        public async Task<IActionResult> PostServiceDetail(DemandeServiceModel values, int structure)
        {
            var model = new ApproDemandeService();
            model.DateDemande = values.DateDemande;
            model.CodeServiceDemandeur = structure; //Technique
            model.Observation = values.Obeservations;
            model.CodeServiceReceveur = values.CodeServiceReceveur;

            var ordres = _context.ApproDemandeService
                .OrderBy(o => o.NumeroDemandeService)
                .Select(i => new
                {
                    i.NumeroDemandeService
                }).ToList();
            if (ordres.Count == 0)
                model.NumeroDemandeService = 1;
            else
            {
                var m = ordres.Last();
                model.NumeroDemandeService = Convert.ToInt32(m.NumeroDemandeService) + 1;
            }
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.ApproDemandeService.Add(model);
            await _context.SaveChangesAsync();


            var articles = _context.TempApproDemandeServiceDetail.AsNoTracking()
            .OrderBy(o => o.Id)
            .Select(i => new
            {
                i.CodeArticle,
                i.ServiceDemande
            }).ToList();
            foreach (var itemarticles in articles)
            {
                ApproDemandeServiceDetail modele = new ApproDemandeServiceDetail();
                if (!itemarticles.CodeArticle.Equals(null))
                {
                    modele.CodeArticle = (int)itemarticles.CodeArticle;
                }
                modele.ServiceDemande = itemarticles.ServiceDemande;
                var countt = _context.ApproDemandeServiceDetail
                    .OrderBy(o => o.Id)
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();
                if (countt.Count == 0)
                    modele.Id = 1;
                else
                {
                    var m = countt.Last();
                    modele.Id = Convert.ToInt32(m.Id) + 1;
                }
                modele.NumeroDemandeService = model.NumeroDemandeService;

                _context.ApproDemandeServiceDetail.Add(modele);
                await _context.SaveChangesAsync();
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_APPRO_DemandeServiceDetail");
            return Json(result.Entity.NumeroDemandeService);
        }

        private void PopulateModel(ApproDemandeService model, IDictionary values) {

            string Observation = nameof(ApproDemandeService.Observation);
            string DateDemande = nameof(ApproDemandeService.DateDemande);
            string CodeServiceReceveur = nameof(ApproDemandeService.CodeServiceReceveur);

            if (values.Contains(CodeServiceReceveur))
            {
                model.CodeServiceReceveur = Convert.ToInt32(values[CodeServiceReceveur]);
            }
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }
            if (values.Contains(DateDemande))
            {
                model.DateDemande = Convert.ToDateTime(values[DateDemande]);
            }
        }
        private void PopulateModelServiceDetail(ApproDemandeServiceDetail model, IDictionary values)
        {
            string ServiceDemande = nameof(ApproDemandeServiceDetail.ServiceDemande);       
            string CodeArticle = nameof(ApproDemandeServiceDetail.CodeArticle);       
            if (values.Contains(ServiceDemande))
            {
                model.ServiceDemande = Convert.ToString(values[ServiceDemande]);
            }            
            if (values.Contains(CodeArticle))
            {
                model.CodeArticle = Convert.ToInt32(values[CodeArticle]);
            }
        }
        private void PopulateModelServiceDetailTemp(TempApproDemandeServiceDetail model, IDictionary values)
        {
            string CodeArticle = nameof(TempApproDemandeServiceDetail.CodeArticle);
            string ServiceDemande = nameof(TempApproDemandeServiceDetail.ServiceDemande);

            if (values.Contains(CodeArticle))
            {
                model.CodeArticle = Convert.ToInt32(values[CodeArticle]);
            }            
            if (values.Contains(ServiceDemande))
            {
                model.ServiceDemande = Convert.ToString(values[ServiceDemande]);
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
    }
}