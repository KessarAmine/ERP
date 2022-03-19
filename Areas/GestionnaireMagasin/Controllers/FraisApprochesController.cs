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
using DevKbfSteel.Areas.GestionnaireMagasin.Models;

namespace DevKbfSteel.Areas.GestionnaireMagasin.Controllers
{
    [Area(nameof(Areas.GestionnaireMagasin))]

    public class FraisApprochesController : Controller
    {
        private KBFsteelContext _context;
        public FraisApprochesController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> GetFrais(DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkFraisApproches
                .Select(i => new {
                    i.Id,
                    i.DesignationFraisApproche
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetFraisEntree(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperGestionnaireMagasin.NumBonEntreeMagasin = id;
            var StkAffectations = _context.StkEntreeFraisApproches
                .Where(c => c.NumBonEntree == id)
                .Select(i => new {
                    i.Id,
                    i.CodeFrais,
                    i.NumFacture,
                    i.MontantDevise,
                    i.ValeurFrais
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostFrais(string values)
        {
            var model = new StkFraisApproches();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFrais(model, valuesDict);
            var StkDecharge = _context.StkFraisApproches
                .Select(i => new
                {
                    i.Id
                }).ToList();
            if (StkDecharge.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkDecharge.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkFraisApproches.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostFraisEntree(string values)
        {
            var model = new StkEntreeFraisApproches();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFraisEntree(model, valuesDict);
            var StkDechargeArticles = _context.StkEntreeFraisApproches
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkDechargeArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkDechargeArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.NumBonEntree = XpertHelperGestionnaireMagasin.NumBonEntreeMagasin;
            if (model.MontantDevise != null)
            {
                model.ValeurFrais = (double)(model.ValeurFrais * model.MontantDevise);
            }
            var result = _context.StkEntreeFraisApproches.Add(model);
            await _context.SaveChangesAsync();
            await UpdateBeFraisSommeAsync(model.NumBonEntree);
            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutFrais(int key, string values)
        {
            var model = await _context.StkFraisApproches.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFrais(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutFraisEentree(int key, string values)
        {
            var model = await _context.StkEntreeFraisApproches.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFraisEntree(model, valuesDict);
            await _context.SaveChangesAsync();
            await UpdateBeFraisSommeAsync(model.NumBonEntree);

            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteFrais(int key)
        {
            var model = await _context.StkFraisApproches.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkFraisApproches.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteFraisEntree(int key)
        {
            var model = await _context.StkEntreeFraisApproches.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkEntreeFraisApproches.Remove(model);
            await _context.SaveChangesAsync();
            await UpdateBeFraisSommeAsync(model.NumBonEntree);
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> FraisLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkFraisApproches
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.DesignationFraisApproche
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
        public double ComputeFrais(int NumBonEntree)
        {
            var SommeFrais = 0.0;
            var ArticlesList = _context.StkBonEntreeArticles.AsNoTracking().Where(item => item.NumBonEntree == NumBonEntree).Select(i => new {
                i.ValeurFrais,
                i.MontantDevise
            }).ToList();
            var Frais = _context.StkEntreeFraisApproches.AsNoTracking().Where(item => item.NumBonEntree == NumBonEntree).Select(i => new {
                i.ValeurFrais,
                i.MontantDevise
            }).ToList();
            foreach (var itemFrais in Frais)
            {
                if (itemFrais.MontantDevise != null)
                {
                    var dev = itemFrais.ValeurFrais * itemFrais.MontantDevise;
                    SommeFrais += (double)dev;
                }
                else
                {
                    SommeFrais += itemFrais.ValeurFrais;
                }
            }
            foreach (var itemArticlesList in ArticlesList)
            {
                if (itemArticlesList.ValeurFrais != null)
                {
                    if (itemArticlesList.MontantDevise != null)
                    {
                        var dev = itemArticlesList.ValeurFrais * itemArticlesList.MontantDevise;
                        SommeFrais += (double)dev;
                    }
                    else
                    {
                        SommeFrais += (double)itemArticlesList.ValeurFrais;
                    }
                }
            }
            return SommeFrais;
        }
        public double ComputeSomme(int NumBonEntree, double SommeFrais)
        {
            var Somme = 0.0;
            var ArticlesList = _context.StkBonEntreeArticles.AsNoTracking().Where(item => item.NumBonEntree == NumBonEntree).Select(i => new {
                i.Montant
            }).ToList();
            foreach (var itemArticlesList in ArticlesList)
            {
                Somme += (double)itemArticlesList.Montant;
            }
            Somme += SommeFrais;
            return Somme;
        }
        public async Task UpdateBeFraisSommeAsync(int NumBonEntree)
        {
            var sommeFrais = ComputeFrais(NumBonEntree);
            var somme = ComputeSomme(NumBonEntree, sommeFrais);
            var BE = await _context.StkBonEntree.FirstOrDefaultAsync(item => item.NumBon == NumBonEntree);
            BE.Somme = somme;
            BE.SommeFraisApproches = sommeFrais;
            _context.StkBonEntree.Update(BE);
            await _context.SaveChangesAsync();
        }
        private void PopulateModelFrais(StkFraisApproches model, IDictionary values)
        {
            string DesignationFraisApproche = nameof(StkFraisApproches.DesignationFraisApproche);
            if (values.Contains(DesignationFraisApproche))
            {
                model.DesignationFraisApproche = Convert.ToString(values[DesignationFraisApproche]);
            }
        }
        private void PopulateModelFraisEntree(StkEntreeFraisApproches model, IDictionary values)
        {
            string CodeFrais = nameof(StkEntreeFraisApproches.CodeFrais);
            string MontantDevise = nameof(StkEntreeFraisApproches.MontantDevise); 
            string NumFacture = nameof(StkEntreeFraisApproches.NumFacture); 
            string ValeurFrais = nameof(StkEntreeFraisApproches.ValeurFrais); 
            if (values.Contains(CodeFrais))
            {
                var CodePdrvar = values[CodeFrais];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeFrais = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(NumFacture))
            {
                model.NumFacture = Convert.ToInt32(values[NumFacture]);
            }
            if (values.Contains(MontantDevise))
            {
                model.MontantDevise = Convert.ToDouble(values[MontantDevise]);
            }
            if (values.Contains(ValeurFrais))
            {
                model.ValeurFrais = Convert.ToDouble(values[ValeurFrais]);
            }
        }
    }
}
