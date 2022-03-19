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

    public class CylindresPreprocessController : Controller
    {
        private KBFsteelContext _context;
        public CylindresPreprocessController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetPreProcessing(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var prodPreProccessingCylindresUsinage = _context.ProdPreProccessingCylindresUsinage
                .Where(c => c.DateChangement.Date <= dateFin.Date && c.DateChangement.Date >= dateDebut.Date)
                .Select(i => new {
                    i.Id,
                    i.DateChangement,
                    i.RefCylindre,
                    i.DiametreAtteint,
                    i.DateEntreeUsinage,
                    i.DateSortieUsinage,
                    i.DiametreSortieCylindre,
                    i.EtatPreProcessing
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(prodPreProccessingCylindresUsinage, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetCylindres(DataSourceLoadOptions loadOptions)
        {
            var pdrs = _context.StkEquipements.AsNoTracking()
                .Where(c => c.Type == "Cylindre")
                .Select(i => new {
                    i.Nom,
                    i.CodeEquipement
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> CylindresLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkEquipements
                         select new
                         {
                             Value = i.CodeEquipement,
                             Text = i.CodeEquipement
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpPut]
        public async Task<IActionResult> PutPreProcessing(int key, string values)
        {
            var model = await _context.ProdPreProccessingCylindresUsinage.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelProdPreProccessingCylindresUsinage(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private void PopulateModelProdPreProccessingCylindresUsinage(ProdPreProccessingCylindresUsinage model, IDictionary values)
        {
            string DateEntreeUsinage = nameof(ProdPreProccessingCylindresUsinage.DateEntreeUsinage);
            string DateSortieUsinage = nameof(ProdPreProccessingCylindresUsinage.DateSortieUsinage);
            string DiametreSortieCylindre = nameof(ProdPreProccessingCylindresUsinage.DiametreSortieCylindre);
            string EtatPreProcessing = nameof(ProdPreProccessingCylindresUsinage.EtatPreProcessing);

            if (values.Contains(DateEntreeUsinage))
            {
                model.DateEntreeUsinage = Convert.ToDateTime(values[DateEntreeUsinage]);
            }     
            if (values.Contains(DateSortieUsinage))
            {
                model.DateSortieUsinage = Convert.ToDateTime(values[DateSortieUsinage]);
            }     
            if (values.Contains(EtatPreProcessing))
            {
                model.EtatPreProcessing = Convert.ToInt32(values[EtatPreProcessing]);
            }            
            if (values.Contains(DiametreSortieCylindre))
            {
                model.DiametreSortieCylindre = Convert.ToInt32(values[DiametreSortieCylindre]);
            }
        }

    }
}
