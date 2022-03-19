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

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StkPdrsController : Controller
    {
        private KBFsteelContext _context;
        public StkPdrsController(KBFsteelContext context)
        {
            _context = context;
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
        public object GetPdrPrixUnitaire(DataSourceLoadOptions loadOptions)
        {
            var pdrs = _context.StkPdr
                .Select(i => new {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.CodeUniteMesurePdr,
                    i.CodeFabricant,
                    i.CodeFamillePdr,
                    i.Conditionnement
                });
            List<StkAffectationsArticlesModel> StkAffectationsArticlesModelList = new List<StkAffectationsArticlesModel>();
            foreach (var itempdrs in pdrs)
            {
                var PrixUnitaire = 1.0;
                StkAffectationsArticlesModel stkAffectationsArticlesModel = new StkAffectationsArticlesModel();
                stkAffectationsArticlesModel.CodePdr = (int)itempdrs.CodePdr;
                stkAffectationsArticlesModel.DesignationPdr = itempdrs.DesignationPdr;
                stkAffectationsArticlesModel.CodeUniteMesure = itempdrs.CodeUniteMesurePdr;
                var PdrMovemnts = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == itempdrs.CodePdr).ToList();
                if (PdrMovemnts != null && PdrMovemnts.Count() > 0)
                {
                    var LastMovement = PdrMovemnts.Last();
                    PrixUnitaire = (double)LastMovement.ValeurValorisation;
                }
                stkAffectationsArticlesModel.PrixUnitaire = (double)PrixUnitaire;
                StkAffectationsArticlesModelList.Add(stkAffectationsArticlesModel);
            }
            return DataSourceLoader.Load(StkAffectationsArticlesModelList.AsEnumerable(), loadOptions);
        }
        //==========================================Articles==================================================
        [HttpGet]
        public object GetArticleSortieLookupModel(DataSourceLoadOptions loadOptions)
        {
            List<Areas.MagasinSuperviseur.Models.ArticleSortieLookupModel> ArticleSortieLookupModelList = new List<Areas.MagasinSuperviseur.Models.ArticleSortieLookupModel>();
            var Articles = _context.StkPdr
                .Select(i => new {
                    i.CodePdr,
                    i.DesignationPdr
                }).ToList();
            foreach (var itemArticles in Articles)
            {
                Areas.MagasinSuperviseur.Models.ArticleSortieLookupModel articleSortieLookupModel = new Areas.MagasinSuperviseur.Models.ArticleSortieLookupModel();
                articleSortieLookupModel.CodePdr = itemArticles.CodePdr;
                articleSortieLookupModel.DesignationPdr = itemArticles.DesignationPdr;
                var Emplacement = _context.StkEmplacement
                    .Where(c => c.CodePdr == itemArticles.CodePdr)
                    .Select(i => new {
                        i.CodeGisement,
                        i.CodeLieu
                    }).ToList();
                if (Emplacement.Count() > 0)
                {
                    var empl = Emplacement.Last();
                    var Lieu = _context.StkLieu
                    .Where(c => c.CodeLieu == empl.CodeLieu)
                    .Select(i => new {
                        i.DesignationLieu
                    }).ToList();
                    var Gisement = _context.StkGismentPdr
                    .Where(c => c.CodeGisment == empl.CodeGisement)
                    .Select(i => new {
                        i.DesignationGisment
                    }).ToList();
                    if (Lieu.Count() > 0)
                    {
                        articleSortieLookupModel.Lieu = Lieu.Last().DesignationLieu;
                    }
                    if (Gisement.Count() > 0)
                    {
                        articleSortieLookupModel.Gisement = Gisement.Last().DesignationGisment;
                    }
                }
                ArticleSortieLookupModelList.Add(articleSortieLookupModel);
            }
            return DataSourceLoader.Load(ArticleSortieLookupModelList, loadOptions);
        }
        [HttpGet]
        public object GetArticleEntreesLookupModel(DataSourceLoadOptions loadOptions)
        {
            List<Areas.MagasinSuperviseur.Models.ArticlesEntreesLookupModel> ArticlesEntreesLookupModelList = new List<Areas.MagasinSuperviseur.Models.ArticlesEntreesLookupModel>();
            var Articles = _context.StkPdr
                .Select(i => new {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.CodeUniteMesurePdr
                }).ToList();
            foreach (var itemArticles in Articles)
            {
                Areas.MagasinSuperviseur.Models.ArticlesEntreesLookupModel articlesEntreesLookupModel = new Areas.MagasinSuperviseur.Models.ArticlesEntreesLookupModel();
                articlesEntreesLookupModel.CodePdr = itemArticles.CodePdr;
                articlesEntreesLookupModel.DesignationPdr = itemArticles.DesignationPdr;
                articlesEntreesLookupModel.UniteMesure = itemArticles.CodeUniteMesurePdr;
                var Emplacement = _context.StkEmplacement
                    .Where(c => c.CodePdr == itemArticles.CodePdr)
                    .Select(i => new {
                        i.CodeGisement,
                        i.CodeLieu
                    }).ToList();
                if (Emplacement.Count() > 0)
                {
                    var empl = Emplacement.Last();
                    var Lieu = _context.StkLieu
                    .Where(c => c.CodeLieu == empl.CodeLieu)
                    .Select(i => new {
                        i.DesignationLieu
                    }).ToList();
                    if (Lieu.Count() > 0)
                    {
                        articlesEntreesLookupModel.Lieu = Lieu.Last().DesignationLieu;
                    }

                    var Gisement = _context.StkGismentPdr
                    .Where(c => c.CodeGisment == empl.CodeGisement)
                    .Select(i => new {
                        i.CodeGisment
                    }).ToList();
                    if(Gisement.Count>0)
                        articlesEntreesLookupModel.CodeGisement = Gisement.Last().CodeGisment;
                }
                ArticlesEntreesLookupModelList.Add(articlesEntreesLookupModel);
            }
            return DataSourceLoader.Load(ArticlesEntreesLookupModelList, loadOptions);
        }
        [HttpGet]
        public async Task<IActionResult> GetArticles(DataSourceLoadOptions loadOptions)
        {
            var pdrs = _context.StkPdr
                .Select(i => new {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.CodeUniteMesurePdr,
                    i.CodeFabricant,
                    i.CodeFamillePdr,
                    i.Conditionnement,
                    i.TypeValorisation,
                    i.ReferenceModele,
                    i.TypeArticle,
                    i.NatureArticle,
                    i.CompteComptable
                });
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostArticles(string values)
        {
            var model = new StkPdr();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdr(model, valuesDict);
            var demandes = _context.StkPdr
                .OrderBy(o => o.CodePdr)
                .Select(i => new
                {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.ReferenceModele
                }).ToList();
            if (String.IsNullOrEmpty(Convert.ToString(model.CodeUniteMesurePdr)))
            {
                return StatusCode(409, "Veuillez entrer l'unité de mesure");
            }
            if (String.IsNullOrEmpty(Convert.ToString(model.DesignationPdr)))
            {
                return StatusCode(409, "Veuillez entrer la désignation");
            }
            if (String.IsNullOrEmpty(Convert.ToString(model.TypeValorisation)))
            {
                return StatusCode(409, "Veuillez entrer le type de valorisation");
            }
            if (model.CodePdr.Equals(null) || model.CodePdr==0)
            {
                if (demandes.Count == 0)
                    model.CodePdr = 1;
                else
                {
                    var m = demandes.Last();
                    model.CodePdr = Convert.ToInt32(m.CodePdr) + 1;
                }
            }
            foreach (var itemdemandes in demandes)
            {
                if (itemdemandes.DesignationPdr.Equals(model.DesignationPdr) && model.ReferenceModele == null)
                {
                    return StatusCode(409, "L'article : " + model.DesignationPdr + " existe déja ("+ itemdemandes.CodePdr+ "), Si il s'agit d'une nouvelle marque vueillez la préciser");
                }
                else
                {
                    if (itemdemandes.DesignationPdr.Equals(model.DesignationPdr) && itemdemandes.ReferenceModele.Equals(model.ReferenceModele))
                    {
                        return StatusCode(409, "L'article : " + model.DesignationPdr+ " de marque : "+ model.ReferenceModele+ " existe déja(" + itemdemandes.CodePdr + ")");
                    }
                }
            }
            //Check if there is gisement in values 
            var Emplacement = new StkEmplacement();
            string CodeGisement = nameof(Emplacement.CodeGisement);
            if (valuesDict.Contains(CodeGisement))
            {
                var StkEmplacement = _context.StkEmplacement
                .OrderBy(o => o.CodePdr)
                .Select(i => new
                {
                    i.NumEmplacement
                }).ToList();
                if (StkEmplacement.Count() == 0)
                    Emplacement.NumEmplacement = 1;
                else
                {
                    var LastStkEmplacement = StkEmplacement.Last();
                    Emplacement.NumEmplacement = LastStkEmplacement.NumEmplacement + 1;
                    Emplacement.CodePdr = model.CodePdr;
                    Emplacement.CodeGisement = Convert.ToInt32(valuesDict[CodeGisement]);
                }
                var resultStkEmplacement = _context.StkEmplacement.Add(Emplacement);
            }
            var result = _context.StkPdr.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.CodePdr);
        }
        //==========================================Outillage==================================================
        [HttpGet]
        public async Task<IActionResult> GetOutillage(DataSourceLoadOptions loadOptions)
        {
            var pdrs = _context.StkPdr
                .Where(c => c.CodeFamillePdr ==  "510" || c.CodeFamillePdr == "520" || c.CodeFamillePdr == "560" || c.CodeFamillePdr == "570")
                .Select(i => new {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.CodeUniteMesurePdr,
                    i.CodeFabricant,
                    i.CodeFamillePdr,
                    i.Conditionnement,
                    i.TypeValorisation,
                    i.ReferenceModele,
                    i.TypeArticle,
                    i.NatureArticle
                });
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostOutillage(string values)
        {
            var model = new StkPdr();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdr(model, valuesDict);
            var demandes = _context.StkPdr
                .OrderBy(o => o.CodePdr)
                .Select(i => new
                {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.ReferenceModele
                }).ToList();

            if (demandes.Count == 0)
                model.CodePdr = 1;
            else
            {
                var m = demandes.Last();
                model.CodePdr = Convert.ToInt32(m.CodePdr) + 1;
            }
            foreach (var itemdemandes in demandes)
            {
                if (itemdemandes.DesignationPdr.Equals(model.DesignationPdr) && model.ReferenceModele == null)
                {
                    return StatusCode(409, "L'article : " + model.DesignationPdr + " existe déja, Si il s'agit d'une nouvelle marque vueillez la préciser");
                }
                else
                {
                    if (itemdemandes.DesignationPdr.Equals(model.DesignationPdr) && itemdemandes.ReferenceModele.Equals(model.ReferenceModele))
                    {
                        return StatusCode(409, "L'article : " + model.DesignationPdr+ " de marque : "+ model.ReferenceModele+" existe déja");
                    }
                }
            }
            model.TypeArticle = 4;//Outillage
            var result = _context.StkPdr.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.CodePdr);
        }
        //==========================================PDR==================================================
        [HttpGet]
        public async Task<IActionResult> GetPDR(DataSourceLoadOptions loadOptions)
        {
            var pdrs = _context.StkPdr
                .Where(c => c.CodeFamillePdr == "200" || c.CodeFamillePdr == "850" || c.CodeFamillePdr == "860")
                .Select(i => new {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.CodeUniteMesurePdr,
                    i.CodeFabricant,
                    i.CodeFamillePdr,
                    i.Conditionnement,
                    i.TypeValorisation,
                    i.ReferenceModele,
                    i.TypeArticle,
                    i.NatureArticle
                });
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostPDR(string values)
        {
            var model = new StkPdr();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdr(model, valuesDict);
            var demandes = _context.StkPdr
                .OrderBy(o => o.CodePdr)
                .Select(i => new
                {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.ReferenceModele
                }).ToList();

            if (demandes.Count == 0)
                model.CodePdr = 1;
            else
            {
                var m = demandes.Last();
                model.CodePdr = Convert.ToInt32(m.CodePdr) + 1;
            }
            foreach (var itemdemandes in demandes)
            {
                if (itemdemandes.DesignationPdr.Equals(model.DesignationPdr) && model.ReferenceModele == null)
                {
                    return StatusCode(409, "L'article : " + model.DesignationPdr + " existe déja, Si il s'agit d'une nouvelle marque vueillez la préciser");
                }
                else
                {
                    if (itemdemandes.DesignationPdr.Equals(model.DesignationPdr) && itemdemandes.ReferenceModele.Equals(model.ReferenceModele))
                    {
                        return StatusCode(409, "L'article : " + model.DesignationPdr+ " de marque : "+ model.ReferenceModele+" existe déja");
                    }
                }
            }
            model.TypeArticle = 3;//PDR
            var result = _context.StkPdr.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.CodePdr);
        }
        [HttpPut]
        public async Task<IActionResult> PutPDR(int key, string values)
        {
            var model = await _context.StkPdr.FirstOrDefaultAsync(item => item.CodePdr == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdr(model, valuesDict);
            if (String.IsNullOrEmpty(Convert.ToString(model.CodeUniteMesurePdr)))
            {
                return StatusCode(409, "Veuillez entrer l'unité de mesure");
            }
            if (String.IsNullOrEmpty(Convert.ToString(model.DesignationPdr)))
            {
                return StatusCode(409, "Veuillez entrer la désignation");
            }
            if (String.IsNullOrEmpty(Convert.ToString(model.TypeValorisation)))
            {
                return StatusCode(409, "Veuillez entrer le type de valorisation");
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeletePDR(int key)
        {
            var model = await _context.StkPdr.FirstOrDefaultAsync(item => item.CodePdr == key);
            _context.StkPdr.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================PDR SURVEILLE===================================
        [HttpGet]
        public async Task<IActionResult> GetPDRSurveille(int CodeStructure, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.CodeServicePdrSureveilleCurrent = CodeStructure;
            var pdrs = _context.StkPdrStockSurveillenceService
                .Where(c => c.CodeStructure == CodeStructure)
                .Select(i => new {
                    i.Id,
                    i.CodePdr,
                    i.QteAlerte
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostPDRSurveille(string values)
        {
            var model = new StkPdrStockSurveillenceService();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelPdrStockSurveillence(model, valuesDict);
            model.CodeStructure = XpertHelper.CodeServicePdrSureveilleCurrent;
            var demandes = _context.StkPdrStockSurveillenceService
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (demandes.Count == 0)
                model.Id = 1;
            else
            {
                var m = demandes.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkPdrStockSurveillenceService.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> PutPDRSurveille(int key, string values)
        {
            var model = await _context.StkPdrStockSurveillenceService.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelPdrStockSurveillence(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeletePDRSurveille(int key)
        {
            var model = await _context.StkPdrStockSurveillenceService.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkPdrStockSurveillenceService.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Fiches Articles==================================
        [HttpGet]
        public async Task<IActionResult> GetFicheArticle(int CodePdr, int codeService, DataSourceLoadOptions loadOptions)
        {
            var pdrs = _context.StkFicheArticle
                .Where(c => c.CodePdr == CodePdr)
                .Select(i => new {
                    i.NumFicheArticle,
                    i.CodePdr,
                    i.Date,
                    i.Emeteur
                });
            if (codeService == XpertHelper.CodeMecanqiue)
                XpertHelper.GestionFicheArticleCodePdrMecanique = CodePdr;
            if (codeService == XpertHelper.CodeElectrique)
                XpertHelper.GestionFicheArticleCodePdrElectrique = CodePdr;
            if (codeService == XpertHelper.CodeMethode)
                XpertHelper.GestionFicheArticleCodePdrMetodes = CodePdr;
            if (codeService == XpertHelper.CodeSodure)
                XpertHelper.GestionFicheArticleCodePdrSoudure = CodePdr;
            if (codeService == XpertHelper.CodeUsinage)
                XpertHelper.GestionFicheArticleCodePdrUsinage = CodePdr;
            if (codeService == XpertHelper.CodeMagasin)
                XpertHelper.GestionFicheArticleCodePdrMagasin = CodePdr;
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostFicheArticleMethodes(string values)
        {
            var model = new StkFicheArticle();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFicheArticle(model, valuesDict);
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrMetodes;
            model.Emeteur = XpertHelper.CodeMethode;
            var demandes = _context.StkFicheArticle
                .OrderBy(o => o.NumFicheArticle)
                .Select(i => new
                {
                    i.NumFicheArticle
                }).ToList();

            if (demandes.Count == 0)
                model.NumFicheArticle = 1;
            else
            {
                var m = demandes.Last();
                model.NumFicheArticle = Convert.ToInt32(m.NumFicheArticle) + 1;
            }
            var result = _context.StkFicheArticle.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumFicheArticle);
        }
        [HttpPost]
        public async Task<IActionResult> PostFicheArticleUsinage(string values)
        {
            var model = new StkFicheArticle();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFicheArticle(model, valuesDict);
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrUsinage;
            model.Emeteur = XpertHelper.CodeUsinage;
            var demandes = _context.StkFicheArticle
                .OrderBy(o => o.NumFicheArticle)
                .Select(i => new
                {
                    i.NumFicheArticle
                }).ToList();

            if (demandes.Count == 0)
                model.NumFicheArticle = 1;
            else
            {
                var m = demandes.Last();
                model.NumFicheArticle = Convert.ToInt32(m.NumFicheArticle) + 1;
            }
            var result = _context.StkFicheArticle.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumFicheArticle);
        }
        [HttpPost]
        public async Task<IActionResult> PostFicheArticleSodure(string values)
        {
            var model = new StkFicheArticle();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFicheArticle(model, valuesDict);
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrSoudure;
            model.Emeteur = XpertHelper.CodeSodure;
            var demandes = _context.StkFicheArticle
                .OrderBy(o => o.NumFicheArticle)
                .Select(i => new
                {
                    i.NumFicheArticle
                }).ToList();

            if (demandes.Count == 0)
                model.NumFicheArticle = 1;
            else
            {
                var m = demandes.Last();
                model.NumFicheArticle = Convert.ToInt32(m.NumFicheArticle) + 1;
            }
            var result = _context.StkFicheArticle.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumFicheArticle);
        }
        [HttpPost]
        public async Task<IActionResult> PostFicheArticleElectrique(string values)
        {
            var model = new StkFicheArticle();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFicheArticle(model, valuesDict);
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrElectrique;
            model.Emeteur = XpertHelper.CodeElectrique;
            var demandes = _context.StkFicheArticle
                .OrderBy(o => o.NumFicheArticle)
                .Select(i => new
                {
                    i.NumFicheArticle
                }).ToList();

            if (demandes.Count == 0)
                model.NumFicheArticle = 1;
            else
            {
                var m = demandes.Last();
                model.NumFicheArticle = Convert.ToInt32(m.NumFicheArticle) + 1;
            }
            var result = _context.StkFicheArticle.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumFicheArticle);
        }
        [HttpPost]
        public async Task<IActionResult> PostFicheArticleMagasin(string values)
        {
            var model = new StkFicheArticle();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFicheArticle(model, valuesDict);
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrMagasin;
            model.Emeteur = XpertHelper.CodeMagasin;
            var demandes = _context.StkFicheArticle
                .OrderBy(o => o.NumFicheArticle)
                .Select(i => new
                {
                    i.NumFicheArticle
                }).ToList();

            if (demandes.Count == 0)
                model.NumFicheArticle = 1;
            else
            {
                var m = demandes.Last();
                model.NumFicheArticle = Convert.ToInt32(m.NumFicheArticle) + 1;
            }
            var result = _context.StkFicheArticle.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumFicheArticle);
        }
        [HttpPost]
        public async Task<IActionResult> PostFicheArticleMecanique(string values)
        {
            var model = new StkFicheArticle();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFicheArticle(model, valuesDict);
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrMecanique;
            model.Emeteur = XpertHelper.CodeMecanqiue;
            var demandes = _context.StkFicheArticle
                .OrderBy(o => o.NumFicheArticle)
                .Select(i => new
                {
                    i.NumFicheArticle
                }).ToList();

            if (demandes.Count == 0)
                model.NumFicheArticle = 1;
            else
            {
                var m = demandes.Last();
                model.NumFicheArticle = Convert.ToInt32(m.NumFicheArticle) + 1;
            }
            var result = _context.StkFicheArticle.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumFicheArticle);
        }
        [HttpPut]
        public async Task<IActionResult> PutFicheArticle(int key, string values)
        {
            var model = await _context.StkFicheArticle.FirstOrDefaultAsync(item => item.NumFicheArticle == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFicheArticle(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteFicheArticle(int key)
        {
            var model = await _context.StkFicheArticle.FirstOrDefaultAsync(item => item.NumFicheArticle == key);
            _context.StkFicheArticle.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Fiches Articles==================================
        [HttpGet]
        public async Task<IActionResult> GetContrainteStockage(int CodeFicheArticle, int codeService, DataSourceLoadOptions loadOptions)
        {
            var pdrs = _context.StkPdrStockContrainte
                .Where(c => c.CodeFicheArticle == CodeFicheArticle)
                .Select(i => new {
                    i.Id,
                    i.CodePdr,
                    i.StockMaximum,
                    i.StockMinimum,
                    i.StockSécurité
                });
            if (codeService == XpertHelper.CodeMecanqiue)
                XpertHelper.CodeServiceFicheArticleMecanique = CodeFicheArticle;
            if (codeService == XpertHelper.CodeElectrique)
                XpertHelper.CodeServiceFicheArticleElectrique = CodeFicheArticle;
            if (codeService == XpertHelper.CodeMethode)
                XpertHelper.CodeServiceFicheArticleMethodes= CodeFicheArticle;
            if (codeService == XpertHelper.CodeSodure)
                XpertHelper.CodeServiceFicheArticleSoudure= CodeFicheArticle;
            if (codeService == XpertHelper.CodeUsinage)
                XpertHelper.CodeServiceFicheArticleUsinage= CodeFicheArticle;
            if (codeService == XpertHelper.CodeMagasin)
                XpertHelper.CodeServiceFicheArticleMagasin= CodeFicheArticle;
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostContrainteStockageUsinage(string values)
        {
            var model = new StkPdrStockContrainte();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdrStockContrainte(model, valuesDict);
            if ((model.StockMaximum <= model.StockMinimum) || (model.StockSécurité <= model.StockMinimum) || (model.StockMaximum <= model.StockSécurité))
            {
                return StatusCode(409, "Vérifiez votre saisie");
            }
            model.CodeFicheArticle = XpertHelper.CodeServiceFicheArticleUsinage;
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrUsinage;
            var demandes = _context.StkPdrStockContrainte
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (demandes.Count == 0)
                model.Id = 1;
            else
            {
                var m = demandes.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkPdrStockContrainte.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostContrainteStockageSodure(string values)
        {
            var model = new StkPdrStockContrainte();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdrStockContrainte(model, valuesDict);
            if ((model.StockMaximum <= model.StockMinimum) || (model.StockSécurité <= model.StockMinimum) || (model.StockMaximum <= model.StockSécurité))
            {
                return StatusCode(409, "Vérifiez votre saisie");
            }
            model.CodeFicheArticle = XpertHelper.CodeServiceFicheArticleSoudure;
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrSoudure;
            var demandes = _context.StkPdrStockContrainte
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (demandes.Count == 0)
                model.Id = 1;
            else
            {
                var m = demandes.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkPdrStockContrainte.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostContrainteStockageMethodes(string values)
        {
            var model = new StkPdrStockContrainte();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdrStockContrainte(model, valuesDict);
            if ((model.StockMaximum <= model.StockMinimum) || (model.StockSécurité <= model.StockMinimum) || (model.StockMaximum <= model.StockSécurité))
            {
                return StatusCode(409, "Vérifiez votre saisie");
            }
            model.CodeFicheArticle = XpertHelper.CodeServiceFicheArticleMethodes;
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrMetodes;
            var demandes = _context.StkPdrStockContrainte
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (demandes.Count == 0)
                model.Id = 1;
            else
            {
                var m = demandes.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkPdrStockContrainte.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostContrainteStockageElectrique(string values)
        {
            var model = new StkPdrStockContrainte();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdrStockContrainte(model, valuesDict);
            if ((model.StockMaximum <= model.StockMinimum) || (model.StockSécurité <= model.StockMinimum) || (model.StockMaximum <= model.StockSécurité))
            {
                return StatusCode(409, "Vérifiez votre saisie");
            }
            model.CodeFicheArticle = XpertHelper.CodeServiceFicheArticleElectrique;
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrElectrique;
            var demandes = _context.StkPdrStockContrainte
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (demandes.Count == 0)
                model.Id = 1;
            else
            {
                var m = demandes.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkPdrStockContrainte.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostContrainteStockageMagasin(string values)
        {
            var model = new StkPdrStockContrainte();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdrStockContrainte(model, valuesDict);
            if ((model.StockMaximum <= model.StockMinimum) || (model.StockSécurité <= model.StockMinimum) || (model.StockMaximum <= model.StockSécurité))
            {
                return StatusCode(409, "Vérifiez votre saisie");
            }
            model.CodeFicheArticle = XpertHelper.CodeServiceFicheArticleMagasin;
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrMagasin;
            var demandes = _context.StkPdrStockContrainte
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (demandes.Count == 0)
                model.Id = 1;
            else
            {
                var m = demandes.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkPdrStockContrainte.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostContrainteStockageMecanique(string values)
        {
            var model = new StkPdrStockContrainte();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdrStockContrainte(model, valuesDict);
            if ((model.StockMaximum <= model.StockMinimum) || (model.StockSécurité <= model.StockMinimum) || (model.StockMaximum <= model.StockSécurité))
            {
                return StatusCode(409, "Vérifiez votre saisie");
            }
            model.CodeFicheArticle = XpertHelper.CodeServiceFicheArticleMecanique;
            model.CodePdr = XpertHelper.GestionFicheArticleCodePdrMecanique;
            var demandes = _context.StkPdrStockContrainte
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (demandes.Count == 0)
                model.Id = 1;
            else
            {
                var m = demandes.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            var result = _context.StkPdrStockContrainte.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> PutContrainteStockage(int key, string values)
        {
            var model = await _context.StkPdrStockContrainte.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkPdrStockContrainte(model, valuesDict);
            if ((model.StockMaximum <= model.StockMinimum) || (model.StockSécurité <= model.StockMinimum) || (model.StockMaximum <= model.StockSécurité))
            {
                return StatusCode(409, "Vérifiez votre saisie");
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteContrainteStockage(int key)
        {
            var model = await _context.StkPdrStockContrainte.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkPdrStockContrainte.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================EmplacementPdr==================================
        [HttpGet]
        public async Task<IActionResult> GetEmplacementPDRGestionnaire(int CodePdr, DataSourceLoadOptions loadOptions)
        {
            XpertHelperGestionnaireMagasin.NumStkEmplacementPdr = CodePdr;
            //checkSpotGestionnaire(CodePdr);
            var pdrs = _context.StkEmplacement
                .Where(c => c.CodePdr == CodePdr)
                .Select(i => new {
                    i.NumEmplacement,
                    i.CodeLieu,
                    i.CodeGisement,
                    i.Qte
                });
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetEmplacementPDRSuperviseur(int CodePdr, DataSourceLoadOptions loadOptions)
        {
            XpertHelperMagasinSuperviseur.NumStkEmplacementPdr = CodePdr;
            //checkSpotSuperviseur(CodePdr);
            var pdrs = _context.StkEmplacement
                .Where(c => c.CodePdr == CodePdr)
                .Select(i => new {
                    i.NumEmplacement,
                    i.CodeLieu,
                    i.CodeGisement,
                    i.Qte
                });
            return Json(await DataSourceLoader.LoadAsync(pdrs, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostEmplacementPDR(string values)
        {
            var model = new StkEmplacement();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelEmplacementPdr(model, valuesDict);
            model.CodePdr = XpertHelper.NumStkEmplacementPdr;
            var demandes = _context.StkEmplacement
                .OrderBy(o => o.NumEmplacement)
                .Select(i => new
                {
                    i.NumEmplacement
                }).ToList();

            if (demandes.Count == 0)
                model.NumEmplacement = 1;
            else
            {
                var m = demandes.Last();
                model.NumEmplacement = Convert.ToInt32(m.NumEmplacement) + 1;
            }
            var result = _context.StkEmplacement.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumEmplacement);
        }
        [HttpPut]
        public async Task<IActionResult> PutEmplacementPDR(int key, string values)
        {
            var model = await _context.StkEmplacement.FirstOrDefaultAsync(item => item.NumEmplacement == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelEmplacementPdr(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteEmplacementPDR(int key)
        {
            var model = await _context.StkEmplacement.FirstOrDefaultAsync(item => item.NumEmplacement == key);
            _context.StkEmplacement.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================SuiviPdr========================================
        [HttpGet]
        public object GetSuiviPDR(int CodePdr,DataSourceLoadOptions loadOptions)
        {
            List<SuiviPdrModel> SuiviPdrModelList = new List<SuiviPdrModel>();
            XpertHelper.CodePdrSuivi = CodePdr;
            var itempdrs = _context.StkPdr
            .AsNoTracking()
            .Where(c => c.CodePdr == CodePdr)
            .Select(i => new {
                i.DesignationPdr
            }).ToList().Last();
            //From Entree
            var entree = _context.StkBonEntreeArticles
                        .AsNoTracking()
                        .Where(c => c.CodePdr == CodePdr)
                        .Select(i => new {
                            i.CodePdr,
                            i.QteRecu,
                            i.Montant,
                            i.PrixUnitaire,
                            i.NumBonEntree
                        }).ToList();
            foreach (var itementree in entree)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.TypeMovement = "BE";
                suiviPdrModel.Quantite = (float)itementree.QteRecu;
                var Bonentree = _context.StkBonEntree
                            .AsNoTracking()
                            .Where(c => c.NumBon == itementree.NumBonEntree)
                            .Select(i => new {
                                i.NumBon,
                                i.DateEntree,
                                i.CodeFournisseur
                            }).ToList().Last();
                if (Bonentree == null)
                {
                    return StatusCode(409, "BE N° : "+ itementree.NumBonEntree+" est introuvable");
                }
                var Fournisseur = _context.ApproFournisseurs
                            .AsNoTracking()
                            .Where(c => c.NumeroFournisseur.Equals(Bonentree.CodeFournisseur.ToString()))
                            .Select(i => new {
                                i.SocieteFournisseur
                            }).ToList().Last();
                if (Fournisseur == null)
                {
                    return StatusCode(409, "Fournisseur N° : " + Bonentree.CodeFournisseur.ToString() + " est introuvable");
                }
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itementree.NumBonEntree && c.TypeMovement ==2)
                            .Select(i => new {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();
                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itementree.NumBonEntree;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.Acteur = Fournisseur.SocieteFournisseur;
                    suiviPdrModel.DateMovement = Bonentree.DateEntree;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            //From Sortie
            var sortie = _context.StkBonSortieArticles
            .AsNoTracking()
            .Where(c => c.CodeArticle == CodePdr)
            .Select(i => new {
                i.CodeArticle,
                i.Qte,
                i.PrixUnitaire,
                i.Montant,
                i.NumBonSortie
            }).ToList();
            foreach (var itemsortie in sortie)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.Quantite = (int)itemsortie.Qte;
                var BonSortie = _context.StkBonSortie
                            .AsNoTracking()
                            .Where(c => c.NumBonSortie == itemsortie.NumBonSortie)
                            .Select(i => new {
                                i.DateSortie,
                                i.TypeSortie,
                                i.NumDemandeFourniture
                            }).ToList().Last();
                if (BonSortie == null)
                {
                    return StatusCode(409, "BS N° : " + itemsortie.NumBonSortie + " est introuvable");
                }
                var TypeSortie = _context.LookupTypeBonSorie
                            .AsNoTracking()
                            .Where(c => c.CodeTypeSortie == BonSortie.TypeSortie)
                            .Select(i => new {
                                i.DesignationTypeSortie
                            }).ToList().Last();
                var Fourniture = _context.ApproDemandesFourniture
                            .AsNoTracking()
                            .Where(c => c.NumeroDemande == BonSortie.NumDemandeFourniture)
                            .Select(i => new {
                                i.CodeServiceDemandeur
                            }).ToList();
                if (Fourniture.Count() > 0)
                {
                    var latFoourniture = Fourniture.Last();
                    var Demandeur = _context.Structure
                                .AsNoTracking()
                                .Where(c => c.CodeStructure == latFoourniture.CodeServiceDemandeur)
                                .Select(i => new {
                                    i.Designation
                                }).ToList().Last();
                    suiviPdrModel.Acteur = Demandeur.Designation;
                }
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itemsortie.NumBonSortie && c.TypeMovement == 3)
                            .Select(i => new {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();
                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itemsortie.NumBonSortie;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.TypeMovement = "BS ( " + TypeSortie.DesignationTypeSortie + " )";
                    suiviPdrModel.DateMovement = BonSortie.DateSortie;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
                
            #region AdditionalSuivi

            //From Affectation
            var affectations = _context.StkAffectationsArticles
            .Where(c => c.CodePdr == CodePdr)
            .Select(i => new {
                i.CodePdr,
                i.Qte,
                i.NumBonAffectation
            }).ToList();
            foreach (var itemaffectations in affectations)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.TypeMovement = "Affectation";
                suiviPdrModel.Quantite = (int)itemaffectations.Qte;
                var StkAffectations = _context.StkAffectations
                            .AsNoTracking()
                            .Where(c => c.NumBonAffectation == itemaffectations.NumBonAffectation)
                            .Select(i => new {
                                i.DateAffectation,
                                i.ServiceReceveur
                            }).ToList().Last();
                var Receveur = _context.Structure
                            .AsNoTracking()
                            .Where(c => c.CodeStructure == StkAffectations.ServiceReceveur)
                            .Select(i => new {
                                i.Designation
                            }).ToList().Last();
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itemaffectations.NumBonAffectation && c.TypeMovement == 4)
                            .Select(i => new {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();
                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itemaffectations.NumBonAffectation;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.Acteur = Receveur.Designation;
                    suiviPdrModel.DateMovement = StkAffectations.DateAffectation;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            //From Reintegration
            var StkReintegrationArticles = _context.StkReintegrationArticles
            .Where(c => c.CodeArticle == CodePdr)
            .Select(i => new {
                i.CodeArticle,
                i.Qte,
                i.NumBonReintegration
            }).ToList();
            foreach (var itemStkReintegration in StkReintegrationArticles)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.TypeMovement = "Reintegration";
                suiviPdrModel.Quantite = (int)itemStkReintegration.Qte;
                var StkReintegration = _context.StkReintegration
                            .AsNoTracking()
                            .Where(c => c.NumBonReintegration == itemStkReintegration.NumBonReintegration)
                            .Select(i => new {
                                i.DateReingegration,
                                i.ServiceEmetteur
                            }).ToList().Last();
                var Emetteur = _context.Structure
                            .AsNoTracking()
                            .Where(c => c.CodeStructure == StkReintegration.ServiceEmetteur)
                            .Select(i => new {
                                i.Designation
                            }).ToList().Last();
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itemStkReintegration.NumBonReintegration && c.TypeMovement == 6)
                            .Select(i => new {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();
                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itemStkReintegration.NumBonReintegration;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.Acteur = Emetteur.Designation;
                    suiviPdrModel.DateMovement = StkReintegration.DateReingegration;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            //From Decharge
            var StkDechargeArticles = _context.StkDechargeArticles
            .AsNoTracking()
            .Where(c => c.CodeArticle == CodePdr)
            .Select(i => new {
                i.CodeArticle,
                i.Qte,
                i.NumDecharge
            }).ToList();
            foreach (var itemStkDechargeArticles in StkDechargeArticles)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.TypeMovement = "Decharge";
                suiviPdrModel.Quantite = (int)itemStkDechargeArticles.Qte;
                var StkDecharge = _context.StkDecharge
                            .Where(c => c.NumDecharge == itemStkDechargeArticles.NumDecharge)
                            .Select(i => new {
                                i.DateDecharge,
                                i.ServiceReceveur
                            }).ToList().Last();
                var Reeveur = _context.Structure
                            .AsNoTracking()
                            .Where(c => c.CodeStructure == StkDecharge.ServiceReceveur)
                            .Select(i => new {
                                i.Designation
                            }).ToList().Last();
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itemStkDechargeArticles.NumDecharge && c.TypeMovement == 5)
                            .Select(i => new
                            {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();
                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itemStkDechargeArticles.NumDecharge;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.Acteur = Reeveur.Designation;
                    suiviPdrModel.DateMovement = StkDecharge.DateDecharge;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            //From Restitution
            var StkRestitutionArticles = _context.StkRestitutionArticles
            .AsNoTracking()
            .Where(c => c.CodeArticle == CodePdr)
            .Select(i => new {
                i.CodeArticle,
                i.Qte,
                i.NumRestitution
            }).ToList();
            foreach (var itemStkRestitutionArticles in StkRestitutionArticles)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.TypeMovement = "Restitution";
                suiviPdrModel.Quantite = (int)itemStkRestitutionArticles.Qte;
                var StkRestitution = _context.StkRestitution
                            .Where(c => c.NumRestitution == itemStkRestitutionArticles.NumRestitution)
                            .Select(i => new {
                                i.DateRestitution,
                                i.ServiceEmetteur
                            }).ToList().Last();
                var Emetteur = _context.Structure
                            .AsNoTracking()
                            .Where(c => c.CodeStructure == StkRestitution.ServiceEmetteur)
                            .Select(i => new {
                                i.Designation
                            }).ToList().Last();
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itemStkRestitutionArticles.NumRestitution && c.TypeMovement == 7)
                            .Select(i => new
                            {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();
                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itemStkRestitutionArticles.NumRestitution;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.Acteur = Emetteur.Designation;
                    suiviPdrModel.DateMovement = StkRestitution.DateRestitution;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            //From Retour
            var StkBonRetourArticles = _context.StkBonRetourArticles
            .AsNoTracking()
            .Where(c => c.CodeArticle == CodePdr)
            .Select(i => new {
                i.CodeArticle,
                i.Qte,
                i.NumBonRetour
            }).ToList();
            foreach (var itemStkBonRetourArticles in StkBonRetourArticles)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.TypeMovement = "Retour Fournisseur";
                suiviPdrModel.Quantite = (int)itemStkBonRetourArticles.Qte;
                var SrkBonRetour = _context.SrkBonRetour
                            .AsNoTracking()
                            .Where(c => c.NumBonRetour == itemStkBonRetourArticles.NumBonRetour)
                            .Select(i => new {
                                i.DateRetour,
                                i.CodeFournisseur
                            }).ToList().Last();
                var Fournisseur = _context.ApproFournisseurs
                            .AsNoTracking()
                            .Where(c => c.NumeroFournisseur == SrkBonRetour.CodeFournisseur)
                            .Select(i => new {
                                i.SocieteFournisseur
                            }).ToList().Last();
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itemStkBonRetourArticles.NumBonRetour && c.TypeMovement == 8)
                            .Select(i => new
                            {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();

                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itemStkBonRetourArticles.NumBonRetour;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.Acteur = Fournisseur.SocieteFournisseur;
                    suiviPdrModel.DateMovement = SrkBonRetour.DateRetour;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            //From Transfert
            var StkBonTransfertArticles = _context.StkBonTransfertArticles
            .AsNoTracking()
            .Where(c => c.CodePdr == CodePdr)
            .Select(i => new {
                i.CodePdr,
                i.Qte,
                i.NumBonTransfert
            }).ToList();
            foreach (var itemStkBonTransfertArticles in StkBonTransfertArticles)
            {
                SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                suiviPdrModel.CodePdr = CodePdr;
                suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                suiviPdrModel.TypeMovement = "Transfert";
                suiviPdrModel.Quantite = (int)itemStkBonTransfertArticles.Qte;
                var StkBonTransfert = _context.StkBonTransfert
                            .AsNoTracking()
                            .Where(c => c.NumBonTransfert == itemStkBonTransfertArticles.NumBonTransfert)
                            .Select(i => new {
                                i.DateTransfert,
                                i.Source,
                                i.Destination
                            }).ToList().Last();
                var Source = _context.StkLieu
                            .AsNoTracking()
                            .Where(c => c.CodeLieu == StkBonTransfert.Source)
                            .Select(i => new {
                                i.DesignationLieu
                            }).ToList().Last();
                var Destination = _context.StkLieu
                            .AsNoTracking()
                            .Where(c => c.CodeLieu == StkBonTransfert.Destination)
                            .Select(i => new {
                                i.DesignationLieu
                            }).ToList().Last();
                var Movement = _context.StkMovements
                            .AsNoTracking()
                            .Where(c => c.IdDetail == itemStkBonTransfertArticles.NumBonTransfert && c.TypeMovement == 9)
                            .Select(i => new {
                                i.PrixUnitaire,
                                i.Montant,
                                i.StockTotalSythese
                            }).ToList();
                if (Movement.Count() > 0)
                {
                    var LastMovement = Movement.Last();
                    suiviPdrModel.NumeroTypeMovement = itemStkBonTransfertArticles.NumBonTransfert;
                    suiviPdrModel.Cout = (float)LastMovement.PrixUnitaire;
                    suiviPdrModel.Valeur = (float)LastMovement.Montant;
                    suiviPdrModel.Reste = (float)LastMovement.StockTotalSythese;
                    suiviPdrModel.Acteur = Source.DesignationLieu + " -> " + Destination.DesignationLieu;
                    suiviPdrModel.DateMovement = StkBonTransfert.DateTransfert;
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            #endregion
                
            
            return DataSourceLoader.Load(SuiviPdrModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetSuiviArticles(int CodePdr,DataSourceLoadOptions loadOptions)
        {
            List<SuiviPdrModel> SuiviPdrModelList = new List<SuiviPdrModel>();
            XpertHelper.CodePdrSuivi = CodePdr;

            var Movements = _context.StkMovements
            .AsNoTracking()
            .Where(c => c.CodePdr == CodePdr)
            .Select(i => new {
                i.DateMovment,
                i.IdDetail,
                i.TypeMovement,
                i.PrixUnitaire,
                i.Montant,
                i.Qte,
                i.StockTotalSythese
            }).ToList();
            if (Movements.Count() > 0)
            {
                foreach (var itemMovements in Movements)
                {
                    SuiviPdrModel suiviPdrModel = new SuiviPdrModel();
                    suiviPdrModel.CodePdr = CodePdr;
                    var itempdrs = _context.StkPdr
                    .AsNoTracking()
                    .Where(c => c.CodePdr == CodePdr)
                    .Select(i => new {
                        i.DesignationPdr
                    }).ToList().Last();
                    suiviPdrModel.DesignationPdr = itempdrs.DesignationPdr;
                    suiviPdrModel.DateMovement = itemMovements.DateMovment;
                    suiviPdrModel.Cout = (float)itemMovements.PrixUnitaire;
                    suiviPdrModel.Reste = (float)itemMovements.StockTotalSythese;
                    suiviPdrModel.Valeur = (float)itemMovements.Montant;
                    suiviPdrModel.Quantite = (float)itemMovements.Qte;
                    if (itemMovements.TypeMovement == 2)//Entrees
                    {
                        suiviPdrModel.TypeMovement = "Entree";
                        var StkBonEntreeArticle = _context.StkBonEntreeArticles
                            .AsNoTracking()
                            .Where(c => c.Id == itemMovements.IdDetail)
                            .Select(i => new {
                                i.NumBonEntree
                            }).ToList().Last();
                        var StkBonEntree = _context.StkBonEntree
                            .AsNoTracking()
                            .Where(c => c.NumBon == StkBonEntreeArticle.NumBonEntree)
                            .Select(i => new {
                                i.FournisseurNonGere,
                                i.CodeFournisseur
                            }).ToList().Last();
                        suiviPdrModel.NumeroTypeMovement = StkBonEntreeArticle.NumBonEntree;
                        if(StkBonEntree.FournisseurNonGere != null)
                        {
                            suiviPdrModel.Acteur = StkBonEntree.FournisseurNonGere;
                        }
                        else
                        {
                            var Fournisseur = _context.ApproFournisseurs
                                .AsNoTracking()
                                .Where(c => c.NumeroFournisseur == StkBonEntree.CodeFournisseur)
                                .Select(i => new {
                                    i.SocieteFournisseur
                                }).ToList();
                            if(Fournisseur.Count()>0)
                            {
                                var four = Fournisseur.Last();
                                suiviPdrModel.Acteur = four.SocieteFournisseur;
                            }
                        }
                    }
                    if (itemMovements.TypeMovement == 3)//Sorties
                    {
                        suiviPdrModel.TypeMovement = "Sortie";
                        var StkBonSortieArticles = _context.StkBonSortieArticles
                            .AsNoTracking()
                            .Where(c => c.Id == itemMovements.IdDetail)
                            .Select(i => new {
                                i.NumBonSortie
                            }).ToList().Last();
                        var StkBonSortie = _context.StkBonSortie
                            .AsNoTracking()
                            .Where(c => c.NumBonSortie == StkBonSortieArticles.NumBonSortie)
                            .Select(i => new {
                                i.CentreFrais
                            }).ToList().Last();
                        suiviPdrModel.NumeroTypeMovement = StkBonSortieArticles.NumBonSortie;
                        var StkCentreFrais = _context.StkCentreFrais
                            .AsNoTracking()
                            .Where(c => c.CodeCentreFrais == StkBonSortie.CentreFrais)
                            .Select(i => new {
                                i.DesignationCentreFrais
                            }).ToList();
                        if (StkCentreFrais.Count() > 0)
                        {
                            suiviPdrModel.Acteur = StkCentreFrais.Last().DesignationCentreFrais;
                        }
                    }
                    if(itemMovements.TypeMovement == 4)//Affectations
                    {
                        suiviPdrModel.TypeMovement = "Affectation";
                        var StkAffectationsArticles = _context.StkAffectationsArticles
                            .AsNoTracking()
                            .Where(c => c.Id == itemMovements.IdDetail)
                            .Select(i => new {
                                i.NumBonAffectation
                            }).ToList().Last();
                        var StkAffectations = _context.StkAffectations
                            .AsNoTracking()
                            .Where(c => c.NumBonAffectation == StkAffectationsArticles.NumBonAffectation)
                            .Select(i => new {
                                i.ServiceReceveur
                            }).ToList().Last();
                        suiviPdrModel.NumeroTypeMovement = StkAffectationsArticles.NumBonAffectation;
                        var StkCentreFrais = _context.StkCentreFrais
                            .AsNoTracking()
                            .Where(c => c.CodeCentreFrais == StkAffectations.ServiceReceveur)
                            .Select(i => new {
                                i.DesignationCentreFrais
                            }).ToList().Last();
                        suiviPdrModel.Acteur = StkCentreFrais.DesignationCentreFrais;
                    }
                    if(itemMovements.TypeMovement == 5)//Decharges
                    {
                        suiviPdrModel.TypeMovement = "Decharge";
                        var StkDechargeArticles = _context.StkDechargeArticles
                            .AsNoTracking()
                            .Where(c => c.Id == itemMovements.IdDetail)
                            .Select(i => new {
                                i.NumDecharge
                            }).ToList().Last();
                        var StkDecharge = _context.StkDecharge
                            .AsNoTracking()
                            .Where(c => c.NumDecharge == StkDechargeArticles.NumDecharge)
                            .Select(i => new {
                                i.ServiceReceveur
                            }).ToList().Last();
                        suiviPdrModel.NumeroTypeMovement = StkDechargeArticles.NumDecharge;
                        var StkCentreFrais = _context.StkCentreFrais
                            .AsNoTracking()
                            .Where(c => c.CodeCentreFrais == StkDecharge.ServiceReceveur)
                            .Select(i => new {
                                i.DesignationCentreFrais
                            }).ToList().Last();
                        suiviPdrModel.Acteur = StkCentreFrais.DesignationCentreFrais;
                    }
                    if(itemMovements.TypeMovement == 6)//Reintegrations
                    {
                        suiviPdrModel.TypeMovement = "Reintegration";
                        var StkReintegrationArticles = _context.StkReintegrationArticles
                            .AsNoTracking()
                            .Where(c => c.Id == itemMovements.IdDetail)
                            .Select(i => new {
                                i.NumBonReintegration
                            }).ToList().Last();
                        var StkReintegration = _context.StkReintegration
                            .AsNoTracking()
                            .Where(c => c.NumBonReintegration == StkReintegrationArticles.NumBonReintegration)
                            .Select(i => new {
                                i.ServiceEmetteur
                            }).ToList().Last();
                        suiviPdrModel.NumeroTypeMovement = StkReintegrationArticles.NumBonReintegration;
                        var StkCentreFrais = _context.StkCentreFrais
                            .AsNoTracking()
                            .Where(c => c.CodeCentreFrais == StkReintegration.ServiceEmetteur)
                            .Select(i => new {
                                i.DesignationCentreFrais
                            }).ToList().Last();
                        suiviPdrModel.Acteur = StkCentreFrais.DesignationCentreFrais;
                    }
                    if(itemMovements.TypeMovement == 7)//Restitutions
                    {
                        suiviPdrModel.TypeMovement = "Restitution";
                        var StkRestitutionArticles = _context.StkRestitutionArticles
                            .AsNoTracking()
                            .Where(c => c.Id == itemMovements.IdDetail)
                            .Select(i => new {
                                i.NumRestitution
                            }).ToList().Last();
                        var StkRestitution = _context.StkRestitution
                            .AsNoTracking()
                            .Where(c => c.NumRestitution == StkRestitutionArticles.NumRestitution)
                            .Select(i => new {
                                i.ServiceEmetteur
                            }).ToList().Last();
                        suiviPdrModel.NumeroTypeMovement = StkRestitutionArticles.NumRestitution;
                        var StkCentreFrais = _context.StkCentreFrais
                            .AsNoTracking()
                            .Where(c => c.CodeCentreFrais == StkRestitution.ServiceEmetteur)
                            .Select(i => new {
                                i.DesignationCentreFrais
                            }).ToList().Last();
                        suiviPdrModel.Acteur = StkCentreFrais.DesignationCentreFrais;
                    }
                    if(itemMovements.TypeMovement == 8)//Retours
                    {
                        suiviPdrModel.TypeMovement = "Retour";
                        var StkBonRetourArticles = _context.StkBonRetourArticles
                            .AsNoTracking()
                            .Where(c => c.Id == itemMovements.IdDetail)
                            .Select(i => new {
                                i.NumBonRetour
                            }).ToList().Last();
                        var SrkBonRetour = _context.SrkBonRetour
                            .AsNoTracking()
                            .Where(c => c.NumBonRetour == StkBonRetourArticles.NumBonRetour)
                            .Select(i => new {
                                i.CodeFournisseur
                            }).ToList().Last();
                        suiviPdrModel.NumeroTypeMovement = StkBonRetourArticles.NumBonRetour;
                        var ApproFournisseurs = _context.ApproFournisseurs
                            .AsNoTracking()
                            .Where(c => c.NumeroFournisseur == SrkBonRetour.CodeFournisseur)
                            .Select(i => new {
                                i.SocieteFournisseur
                            }).ToList().Last();
                        suiviPdrModel.Acteur = ApproFournisseurs.SocieteFournisseur;
                    }
                    SuiviPdrModelList.Add(suiviPdrModel);
                }
            }
            return DataSourceLoader.Load(SuiviPdrModelList.AsEnumerable(), loadOptions);
        }
        //=================================================LookUps========================================
        private void checkSpotGestionnaire(int CodePdr)
        {
            var emplacement = _context.StkEmplacement
                .AsNoTracking()
                .Where(c => c.CodePdr == CodePdr).ToList();
            if (emplacement.Count > 0)
            {
                StkEmplacement MagasinP = emplacement.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);
                if(MagasinP != null)
                {
                    var mvt = _context.StkMovements
                    .OrderBy(o => o.DateMovment)
                    .AsNoTracking()
                    .Where(c => c.CodePdr == CodePdr).ToList();
                    if (mvt.Count > 0)
                    {
                        MagasinP.Qte = mvt.Last().StockTotalSythese;
                        //we get sum of qte in other lieux then we substruct it to get the result
                        double sommeOtherPlaces = 0;
                        foreach (var itememplacement in emplacement)
                        {
                            if (itememplacement.CodeLieu != XpertHelper.CodeMagasin)
                            {
                                sommeOtherPlaces += (double)itememplacement.Qte;
                            }
                        }
                        MagasinP.Qte -= sommeOtherPlaces;
                    }
                    else
                    {
                        var stkInit = _context.StkStockInitial.Where(c => c.CodePdr == CodePdr).ToList();
                        if (stkInit.Count > 0)
                        {
                            MagasinP.Qte = stkInit.Last().Qte;
                        }
                    }
                    _context.StkEmplacement.Update(MagasinP);
                    _context.SaveChanges();
                }
            }
        }
        private void checkSpotSuperviseur(int CodePdr)
        {
            var emplacement = _context.StkEmplacement
                .AsNoTracking()
                .Where(c => c.CodePdr == CodePdr).ToList();
            if (emplacement.Count > 0)
            {
                StkEmplacement MagasinP = emplacement.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);
                if(MagasinP != null)
                {
                    var mvt = _context.StkMovements
                    .OrderBy(o => o.DateMovment)
                    .AsNoTracking()
                    .Where(c => c.CodePdr == CodePdr).ToList();
                    if (mvt.Count > 0)
                    {
                        MagasinP.Qte = mvt.Last().StockTotalSythese;
                        //we get sum of qte in other lieux then we substruct it to get the result
                        double sommeOtherPlaces = 0;
                        foreach (var itememplacement in emplacement)
                        {
                            if (itememplacement.CodeLieu != XpertHelper.CodeMagasin)
                            {
                                sommeOtherPlaces += (double)itememplacement.Qte;
                            }
                        }
                        MagasinP.Qte -= sommeOtherPlaces;
                    }
                    else
                    {
                        var stkInit = _context.StkStockInitial.Where(c => c.CodePdr == CodePdr).ToList();
                        if (stkInit.Count > 0)
                        {
                            MagasinP.Qte = stkInit.Last().Qte;
                        }
                    }
                    _context.StkEmplacement.Update(MagasinP);
                    _context.SaveChanges();
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> GroupeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkGroupePdr
                         orderby i.CodeGroupe
                         select new
                         {
                             Value = i.CodeGroupe,
                             Text = i.DesignationGroupe
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> SousFamilleLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkSousFamillePdr
                         orderby i.CodeSousFamille
                         select new
                         {
                             Value = i.CodeSousFamille,
                             Text = i.DesignationSousFamille
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
        [HttpGet]
        public async Task<IActionResult> CodeFabricantLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.ApproFournisseurs
                         orderby i.NumeroFournisseur
                         select new
                         {
                             Value = i.NumeroFournisseur,
                             Text = i.SocieteFournisseur
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> UniteMesureLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkUniteMesurePdr
                         orderby i.CodeUniteMesurePdr
                         select new
                         {
                             Value = i.CodeUniteMesurePdr,
                             Text = i.DesignationUniteMesurePdr
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DesignationPdrLookup(DataSourceLoadOptions loadOptions)
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
        [HttpGet]
        public async Task<IActionResult> CodeGisementLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkGismentPdr
                         orderby i.CodeGisment
                         select new
                         {
                             Value = i.CodeGisment,
                             Text = i.DesignationGisment
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> CodelieuLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Structure
                         orderby i.CodeStructure
                         select new
                         {
                             Value = i.CodeStructure,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeArticleLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupTypeArticle
                         orderby i.CodeTypeArtile
                         select new
                         {
                             Value = i.CodeTypeArtile,
                             Text = i.DesignationTypeArticle
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeValorisationLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkTypeValorisation
                         orderby i.CodeValorisation
                         select new
                         {
                             Value = i.CodeValorisation,
                             Text = i.DesignationValorisation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //==================================================================================================
        private void PopulateModelStkPdr(StkPdr model, IDictionary values)
        {
            ArticlesEntreesLookupModel articlesEntreesLookupModel;
            string CodePdr = nameof(StkPdr.CodePdr);     
            string ArticleCritique = nameof(StkPdr.ArticleCritique);     
            string CodeFabricant = nameof(StkPdr.CodeFabricant);     
            string CodeFamillePdr = nameof(StkPdr.CodeFamillePdr);     
            string CodeGroupe = nameof(StkPdr.CodeGroupe);     
            string CodeSousFamillePdr = nameof(StkPdr.CodeSousFamillePdr);
            string CodeUniteMesurePdr = nameof(StkPdr.CodeUniteMesurePdr);
            string UniteMesure = nameof(articlesEntreesLookupModel.UniteMesure);
            string CompteComptable = nameof(StkPdr.CompteComptable);
            string Conditionnement = nameof(StkPdr.Conditionnement);
            string DesignationPdr = nameof(StkPdr.DesignationPdr);
            string TypeValorisation = nameof(StkPdr.TypeValorisation);
            string TypeArticle = nameof(StkPdr.TypeArticle);
            string NatureArticle = nameof(StkPdr.NatureArticle);
            string ReferenceModele = nameof(StkPdr.ReferenceModele);
            if (values.Contains(NatureArticle))
            {
                model.NatureArticle = Convert.ToInt32(values[NatureArticle]);
            }
            if (values.Contains(CodePdr))
            {
                model.CodePdr = Convert.ToInt32(values[CodePdr]);
            }
            if (values.Contains(TypeArticle))
            {
                model.TypeArticle = Convert.ToInt32(values[TypeArticle]);
            }
            if (values.Contains(CodeFabricant))
            {
                model.CodeFabricant = Convert.ToString(values[CodeFabricant]);
            }
            if (values.Contains(ArticleCritique))
            {
                model.ArticleCritique = Convert.ToBoolean(values[ArticleCritique]);
            }
            if (values.Contains(CodeGroupe))
            {
                model.CodeGroupe = Convert.ToInt32(values[CodeGroupe]);
            }
            if (values.Contains(CodeSousFamillePdr))
            {
                model.CodeSousFamillePdr = Convert.ToString(values[CodeSousFamillePdr]);
            }
            if (values.Contains(CompteComptable))
            {
                model.CompteComptable = Convert.ToInt32(values[CompteComptable]);
            }
            if (values.Contains(CodeUniteMesurePdr))
            {
                model.CodeUniteMesurePdr = Convert.ToInt32(values[CodeUniteMesurePdr]);
            }
            //Adding from Entree
            if (values.Contains(UniteMesure))
            {
                model.CodeUniteMesurePdr = Convert.ToInt32(values[UniteMesure]);
            }
            if (values.Contains(TypeValorisation))
            {
                model.TypeValorisation = Convert.ToInt32(values[TypeValorisation]);
            }
            if (values.Contains(CodeFamillePdr))
            {
                model.CodeFamillePdr = Convert.ToString(values[CodeFamillePdr]);
            }
            if (values.Contains(ReferenceModele))
            {
                model.ReferenceModele = Convert.ToString(values[ReferenceModele]);
            }
            if (values.Contains(DesignationPdr))
            {
                model.DesignationPdr = Convert.ToString(values[DesignationPdr]);
            }
            if (values.Contains(Conditionnement))
            {
                model.Conditionnement = Convert.ToString(values[Conditionnement]);
            }
        }
        private void PopulateModelFicheArticle(StkFicheArticle model, IDictionary values)
        {
            string Date = nameof(StkFicheArticle.Date);     
            if (values.Contains(Date))
            {
                model.Date = Convert.ToDateTime(values[Date]);
            }
        }
        private void PopulateModelStkPdrStockContrainte(StkPdrStockContrainte model, IDictionary values)
        {
            string CodeGestion = nameof(StkPdrStockContrainte.CodeGestion);
            string CodeModelAppro = nameof(StkPdrStockContrainte.CodeModelAppro);  
            string StockMaximum = nameof(StkPdrStockContrainte.StockMaximum);  
            string StockMinimum = nameof(StkPdrStockContrainte.StockMinimum);  
            string StockSécurité = nameof(StkPdrStockContrainte.StockSécurité);  
            if (values.Contains(CodeGestion))
            {
                model.CodeGestion = Convert.ToInt32(values[CodeGestion]);
            }
            if (values.Contains(CodeModelAppro))
            {
                model.CodeModelAppro = Convert.ToInt32(values[CodeModelAppro]);
            }
            if (values.Contains(StockMaximum))
            {
                model.StockMaximum = Convert.ToInt32(values[StockMaximum]);
            }
            if (values.Contains(StockMinimum))
            {
                model.StockMinimum = Convert.ToInt32(values[StockMinimum]);
            }
            if (values.Contains(StockSécurité))
            {
                model.StockSécurité = Convert.ToInt32(values[StockSécurité]);
            }
        }
        private void PopulateModelEmplacementPdr(StkEmplacement model, IDictionary values)
        {
            string CodeLieu = nameof(StkEmplacement.CodeLieu);
            string CodeGisement = nameof(StkEmplacement.CodeGisement);
            string Qte = nameof(StkEmplacement.Qte);
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToDouble(values[Qte]);
            }
            if (values.Contains(CodeLieu))
            {
                model.CodeLieu = Convert.ToInt32(values[CodeLieu]);
            }
            if (values.Contains(CodeGisement))
            {
                model.CodeGisement = Convert.ToInt32(values[CodeGisement]);
            }
        }
        private void PopulateModelPdrStockSurveillence(StkPdrStockSurveillenceService model, IDictionary values)
        {
            string CodePdr = nameof(StkPdrStockSurveillenceService.CodePdr);
            string QteAlerte = nameof(StkPdrStockSurveillenceService.QteAlerte);
            if (values.Contains(CodePdr))
            {
                var CodePdrvar = values[CodePdr];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var value = SplitThesecond[0];
                model.CodePdr = Convert.ToInt32(value);
            }            
            if (values.Contains(QteAlerte))
            {
                model.QteAlerte = Convert.ToInt32(values[QteAlerte]);
            }
        }

    }
}
