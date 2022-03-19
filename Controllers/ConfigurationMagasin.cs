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

    public class ConfigurationMagasin : Controller
    {
        private KBFsteelContext _context;
        public ConfigurationMagasin(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetFamilles(DataSourceLoadOptions loadOptions) {
            var StkFamillePdr = _context.StkFamillePdr
                .Select(i => new {
                    i.CodeFamillePdr,
                    i.DesignationFamillePdr
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkFamillePdr, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetSousFamille(DataSourceLoadOptions loadOptions)
        {
            var StkSousFamillePdr = _context.StkSousFamillePdr
                .Select(i => new {
                    i.CodeFamille,
                    i.CodeSousFamille,
                    i.DesignationSousFamille
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkSousFamillePdr, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetCentreFrais(DataSourceLoadOptions loadOptions)
        {
            var StkCentreFrais = _context.StkCentreFrais
                .Select(i => new {
                    i.CodeCentreFrais,
                    i.DesignationCentreFrais
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkCentreFrais, loadOptions));
        }
        //===============================
        [HttpPost]
        public async Task<IActionResult> PostFamilles(string values)
        {
            var model = new StkFamillePdr();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFA(model, valuesDict);
            var ordres = _context.StkFamillePdr
                .Select(i => new
                {
                    i.CodeFamillePdr
                }).ToList();
            if(model.CodeFamillePdr==null|| model.CodeFamillePdr.Equals(""))
            {
                if (ordres.Count == 0)
                    model.CodeFamillePdr = "1";
                else
                {
                    var m = ordres.Last();
                    var value = m.CodeFamillePdr;
                    int numericValue;
                    bool isNumber = int.TryParse(value,out numericValue);
                    if(isNumber == true)
                    {
                        model.CodeFamillePdr = Convert.ToString(Convert.ToInt32(m.CodeFamillePdr) + 1);
                    }
                    else
                    {
                        for (int i = ordres.Count-1; i >= 0;i--)
                        {
                            var elem = ordres[i];
                            var valueelem = elem.CodeFamillePdr;
                            int numericValueelem;
                            bool isNumberelem = int.TryParse(valueelem, out numericValueelem);
                            if (isNumberelem == true)
                            {
                                model.CodeFamillePdr = Convert.ToString(Convert.ToInt32(elem.CodeFamillePdr) + 1);
                            }
                        }
                    }
                }
            }
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.StkFamillePdr.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.CodeFamillePdr);
        }
        [HttpPost]
        public async Task<IActionResult> PostSousFamille(string values)
        {
            var model = new StkSousFamillePdr();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelSFA(model, valuesDict);
            var ordres = _context.StkSousFamillePdr
                .Select(i => new
                {
                    i.CodeSousFamille
                }).ToList();

            if (model.CodeSousFamille == null || model.CodeSousFamille.Equals(""))
            {
                if (ordres.Count == 0)
                    model.CodeSousFamille = "1";
                else
                {
                    var m = ordres.Last();
                    var value = m.CodeSousFamille;
                    int numericValue;
                    bool isNumber = int.TryParse(value, out numericValue);
                    if (isNumber == true)
                    {
                        model.CodeSousFamille = Convert.ToString(Convert.ToInt32(m.CodeSousFamille) + 1);
                    }
                    else
                    {
                        for (int i = ordres.Count - 1; i >= 0; i--)
                        {
                            var elem = ordres[i];
                            var valueelem = elem.CodeSousFamille;
                            int numericValueelem;
                            bool isNumberelem = int.TryParse(valueelem, out numericValueelem);
                            if (isNumberelem == true)
                            {
                                model.CodeSousFamille = Convert.ToString(Convert.ToInt32(elem.CodeSousFamille) + 1);
                            }
                        }
                    }
                }
            }
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.StkSousFamillePdr.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.CodeSousFamille);
        }
        [HttpPost]
        public async Task<IActionResult> PostCentreFrais(string values)
        {
            var model = new StkCentreFrais();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelCF(model, valuesDict);
            var ordres = _context.StkCentreFrais
                .Select(i => new
                {
                    i.CodeCentreFrais
                }).ToList();
            if (ordres.Count == 0)
                model.CodeCentreFrais = 1;
            else
            {
                var m = ordres.Last();
                model.CodeCentreFrais = Convert.ToInt32(m.CodeCentreFrais) + 1;
            }
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.StkCentreFrais.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.CodeCentreFrais);
        }
        //===============================
        [HttpPut]
        public async Task<IActionResult> PutFamilles(string key, string values) {
            var model = await _context.StkFamillePdr.FirstOrDefaultAsync(item => item.CodeFamillePdr == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFA(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutSousFamille(string key, string values) {
            var model = await _context.StkSousFamillePdr.FirstOrDefaultAsync(item => item.CodeSousFamille == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelSFA(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutCentreFrais(int key, string values) {
            var model = await _context.StkCentreFrais.FirstOrDefaultAsync(item => item.CodeCentreFrais == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelCF(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        //===============================
        [HttpDelete]
        public async Task DeleteFamilles(string key) {
            var model = await _context.StkFamillePdr.FirstOrDefaultAsync(item => item.CodeFamillePdr == key);
            _context.StkFamillePdr.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteSousFamille(string key) {
            var model = await _context.StkSousFamillePdr.FirstOrDefaultAsync(item => item.CodeSousFamille == key);
            _context.StkSousFamillePdr.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteCentreFrais(int key) {
            var model = await _context.StkCentreFrais.FirstOrDefaultAsync(item => item.CodeCentreFrais == key);
            _context.StkCentreFrais.Remove(model);
            await _context.SaveChangesAsync();
        }
        //===============================
        private void PopulateModelFA(StkFamillePdr model, IDictionary values) {

            string CodeFamillePdr = nameof(StkFamillePdr.CodeFamillePdr);
            string DesignationFamillePdr = nameof(StkFamillePdr.DesignationFamillePdr);
            if (values.Contains(CodeFamillePdr))
            {
                model.CodeFamillePdr = Convert.ToString(values[CodeFamillePdr]);
            }
            if (values.Contains(DesignationFamillePdr))
            {
                model.DesignationFamillePdr = Convert.ToString(values[DesignationFamillePdr]);
            }
        }
        private void PopulateModelSFA(StkSousFamillePdr model, IDictionary values)
        {
            string CodeSousFamille = nameof(StkSousFamillePdr.CodeSousFamille);       
            string CodeFamille = nameof(StkSousFamillePdr.CodeFamille);       
            string DesignationSousFamille = nameof(StkSousFamillePdr.DesignationSousFamille);       
            if (values.Contains(CodeSousFamille))
            {
                model.CodeSousFamille = Convert.ToString(values[CodeSousFamille]);
            }                   
            if (values.Contains(DesignationSousFamille))
            {
                model.DesignationSousFamille = Convert.ToString(values[DesignationSousFamille]);
            }            
            if (values.Contains(CodeFamille))
            {
                model.CodeFamille = Convert.ToString(values[CodeFamille]);
            }
        }
        private void PopulateModelCF(StkCentreFrais model, IDictionary values)
        {
            string DesignationCentreFrais = nameof(StkCentreFrais.DesignationCentreFrais);
            if (values.Contains(DesignationCentreFrais))
            {
                model.DesignationCentreFrais = Convert.ToString(values[DesignationCentreFrais]);
            }
        }
        //===============================
        [HttpGet]
        public async Task<IActionResult> CFLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkCentreFrais
                         orderby i.CodeCentreFrais
                         select new
                         {
                             Value = i.CodeCentreFrais,
                             Text = i.DesignationCentreFrais
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> FamilleLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkFamillePdr
                         orderby i.CodeFamillePdr
                         select new
                         {
                             Value = i.CodeFamillePdr,
                             Text = i.DesignationFamillePdr
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //===============================
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