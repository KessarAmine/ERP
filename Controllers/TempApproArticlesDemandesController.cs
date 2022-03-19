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

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TempApproArticlesDemandesController : Controller
    {
        private KBFsteelContext _context;
        public TempApproArticlesDemandesController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var bonproduction = _context.TempApproArticlesDemandes
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.ArticleNonGere,
                    i.Qte
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new TempApproArticlesDemandes();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var ordres = _context.TempApproArticlesDemandes
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

            var result = _context.TempApproArticlesDemandes.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.TempApproArticlesDemandes.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.TempApproArticlesDemandes.FirstOrDefaultAsync(item => item.Id == key);
            //TODO : Get Last Plannification of that Op
            _context.TempApproArticlesDemandes.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult> PdrLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkPdr
                         orderby i.CodePdr
                         select new
                         {
                             Value = i.CodePdr,
                             Text = i.DesignationPdr
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        public async static Task PostToApproFournituresArticles(KBFsteelContext context, ApproFournituresArticles model)
        {
            var approFournituresArticles = context.ApproFournituresArticles
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();
            if (approFournituresArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = approFournituresArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }

            var result = context.ApproFournituresArticles.Add(model);
            await context.SaveChangesAsync();
        }
        private void PopulateModel(TempApproArticlesDemandes model, IDictionary values)
        {

            string Id = nameof(TempApproArticlesDemandes.Id);
            string CodeArticle = nameof(TempApproArticlesDemandes.CodeArticle);
            string Qte = nameof(TempApproArticlesDemandes.Qte);
            string ArticleNonGere = nameof(TempApproArticlesDemandes.ArticleNonGere);


            if (values.Contains(ArticleNonGere))
            {
                model.ArticleNonGere = Convert.ToString(values[ArticleNonGere]);
            }
            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(CodeArticle))
            {
                model.CodeArticle = Convert.ToInt32(values[CodeArticle]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }

        }

    }
}
