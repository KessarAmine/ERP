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
using DevKbfSteel.Areas.MagasinManager.Models;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class ApproDemandesFournituresController : Controller
    {
        private KBFsteelContext _context;
        public ApproDemandesFournituresController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetDemandesAchatMagasin(int numDemandeFourniture, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDemandeFournitureMagasin = numDemandeFourniture;
            var approDemandesFourniture = _context.ApproDemandeAchats
                .Where(c => c.NumDemandeFourniture == numDemandeFourniture)
                .Select(i => new {
                    i.NumDemandeAchat,
                    i.CodeServiceDemandeur,
                    i.DateDemandeAchat,
                    i.StatutDemandeAchat,
                    i.CodeNatureDemandeAchat,
                    i.MotifDemandeAchat
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approDemandesFourniture, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetFournitureMagasin(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var approDemandesFourniture = _context.ApproDemandesFourniture
                .Where(c => c.DateDemande.Date >= dateDebut.Date && c.DateDemande.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumeroDemande,
                    i.DateBesoin,
                    i.DateDemande,
                    i.CodeServiceDemandeur,
                    i.Obeservations,
                    i.Status
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approDemandesFourniture, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetFourniture(DateTime dateDebut, DateTime dateFin, int structure, DataSourceLoadOptions loadOptions)
        {
            var approDemandesFourniture = _context.ApproDemandesFourniture
                .Where(c => c.DateDemande.Date >= dateDebut.Date && c.DateDemande.Date <= dateFin.Date
                       && c.CodeServiceDemandeur == structure)
                .Select(i => new {
                    i.NumeroDemande,
                    i.DateBesoin,
                    i.DateDemande,
                    i.Obeservations,
                    i.Status,
                    i.Destination
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approDemandesFourniture, loadOptions));
        }
        [HttpGet]
        public object GetFournitureArticlesMagasin(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDemandeFournitureMagasin = id;
            var approDemandesFourniture = _context.ApproFournituresArticles
                .AsNoTracking()
                .Where(c => c.NumeroDemandeFourniture == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.DesignationArticle,
                    i.CodeUniteMesure,
                    i.QteDemande,
                    i.QteValable
                }).ToList();
            List<ApproFournituresArticlesMagasinModel> ApproFournituresArticlesMagasinModelList = new List<ApproFournituresArticlesMagasinModel>();
            foreach (var itemapproDemandesFourniture in approDemandesFourniture)
            {
                var StockSecurite = 0.0;
                var StockTotalSynthese = 0.0;
                ApproFournituresArticlesMagasinModel approFournituresArticlesMagasinModel = new ApproFournituresArticlesMagasinModel();
                approFournituresArticlesMagasinModel.CodeArticle = itemapproDemandesFourniture.CodeArticle;
                approFournituresArticlesMagasinModel.CodeUniteMesure = itemapproDemandesFourniture.CodeUniteMesure;
                approFournituresArticlesMagasinModel.DesignationArticle = itemapproDemandesFourniture.DesignationArticle;
                approFournituresArticlesMagasinModel.Id = itemapproDemandesFourniture.Id;
                approFournituresArticlesMagasinModel.QteDemande = itemapproDemandesFourniture.QteDemande;
                //Get StockSecurtié du PDR
                var PdrContrainte = _context.StkPdrStockContrainte.AsNoTracking().Where(c => c.CodePdr == itemapproDemandesFourniture.CodeArticle).ToList();
                if (PdrContrainte != null && PdrContrainte.Count() > 0)
                {
                    var LastContrainte = PdrContrainte.Last();
                    StockSecurite = LastContrainte.StockSécurité;
                }
                // Get QTE En stok du PDR des movements
                var PdrMovemnts = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == itemapproDemandesFourniture.CodeArticle).ToList();
                if (PdrMovemnts != null && PdrMovemnts.Count() > 0)
                {
                    var LastMovement = PdrMovemnts.Last();
                    StockTotalSynthese = (double)LastMovement.StockTotalSythese;
                }
                else
                {
                    var stkInit = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == itemapproDemandesFourniture.CodeArticle).ToList();
                    if (stkInit != null && stkInit.Count() > 0)
                    {
                        var stkInitVal = stkInit.Last();
                        StockTotalSynthese = stkInitVal.Qte;
                    }
                }
                // Compute Availabelity
                approFournituresArticlesMagasinModel.QteValable = StockTotalSynthese - StockSecurite;

                ApproFournituresArticlesMagasinModelList.Add(approFournituresArticlesMagasinModel);
            }
            return DataSourceLoader.Load(ApproFournituresArticlesMagasinModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public async Task<IActionResult> GetFournitureArticles(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDemandeFourniture = id;
            var approDemandesFourniture = _context.ApproFournituresArticles
                .Where(c => c.NumeroDemandeFourniture == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.DesignationArticle,
                    i.CodeUniteMesure,
                    i.QteDemande
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approDemandesFourniture, loadOptions));
        }
        public async Task<IActionResult> PostFourniture(DemandeFournitureModel values, int structure)
        {
            var model = new ApproDemandesFourniture();
            model.DateDemande = values.DateDemande;
            model.DateBesoin = values.DateBesoin;
            model.CodeServiceDemandeur = structure; //Technique
            model.Status = "En Attente";
            model.Obeservations = values.Obeservations;
            if (structure == XpertHelper.CodeMethode)
            {
                model.Destination = values.Destination;
            }
            var ordres = _context.ApproDemandesFourniture
                .OrderBy(o => o.NumeroDemande)
                .Select(i => new
                {
                    i.NumeroDemande
                }).ToList();
            if (ordres.Count == 0)
                model.NumeroDemande = 1;
            else
            {
                var m = ordres.Last();
                model.NumeroDemande = Convert.ToInt32(m.NumeroDemande) + 1;
            }
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.ApproDemandesFourniture.Add(model);
            await _context.SaveChangesAsync();


            var articles = _context.TempApproArticlesDemandes.AsNoTracking()
            .OrderBy(o => o.Id)
            .Select(i => new
            {
                i.CodeArticle,
                i.ArticleNonGere,
                i.Qte
            }).ToList();
            foreach (var itemarticles in articles)
            {
                ApproFournituresArticles modele = new ApproFournituresArticles();
                if (!itemarticles.CodeArticle.Equals(null))
                {
                    modele.CodeArticle = (int)itemarticles.CodeArticle;
                    var DesignationArticle = _context.StkPdr.AsNoTracking()
                    .Where(o => o.CodePdr == itemarticles.CodeArticle)
                    .Select(i => new
                    {
                        i.DesignationPdr
                    }).ToList();
                    modele.DesignationArticle = DesignationArticle.Last().DesignationPdr;
                    var CodeUniteMesure = _context.StkPdr.AsNoTracking()
                    .Where(o => o.CodePdr == itemarticles.CodeArticle)
                    .Select(i => new
                    {
                        i.CodeUniteMesurePdr
                    }).ToList();
                    if (CodeUniteMesure.Last().CodeUniteMesurePdr != null)
                    {
                        modele.CodeUniteMesure = (int)CodeUniteMesure.Last().CodeUniteMesurePdr;
                    }
                    else
                    {
                        modele.CodeUniteMesure = 0;
                    }
                }
                else
                {
                    modele.CodeUniteMesure = 0;
                    modele.DesignationArticle = itemarticles.ArticleNonGere;
                }
                modele.QteDemande = itemarticles.Qte;
                modele.NumeroDemandeFourniture = model.NumeroDemande;
                var countt = _context.ApproFournituresArticles
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
                _context.ApproFournituresArticles.Add(modele);
                await _context.SaveChangesAsync();
            }
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_APPRO_ArticlesDemandes");
            return Json(result.Entity.NumeroDemande);
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new ApproFournituresArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelArticle(model, valuesDict);
            var ordres = _context.ApproFournituresArticles
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
            model.NumeroDemandeFourniture = (int)XpertHelper.NumDemandeFourniture;
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> PutArticle(int key, string values)
        {
            var model = await _context.ApproFournituresArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelArticle(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.ApproDemandesFourniture.FirstOrDefaultAsync(item => item.NumeroDemande == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.ApproDemandesFourniture.FirstOrDefaultAsync(item => item.NumeroDemande == key);
            _context.ApproDemandesFourniture.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteArticle(int key)
        {
            var model = await _context.ApproFournituresArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.ApproFournituresArticles.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CodeNatureDemandeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.ApproNatureDemandeFourniture
                         orderby i.CodeNatureDemande
                         select new
                         {
                             Value = i.CodeNatureDemande,
                             Text = i.DesignationNatureDemande
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> StatusLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.ApproStatut
                         orderby i.DesignationStatut
                         select new
                         {
                             Value = i.DesignationStatut,
                             Text = i.DesignationStatut
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DestinationLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupDestinationDf
                         select new
                         {
                             Value = i.Id,
                             Text = i.Destination
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> CodeDemandeurLookup(DataSourceLoadOptions loadOptions)
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
        public async Task<IActionResult> DesignationArticleLookup(DataSourceLoadOptions loadOptions)
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
        public async Task<IActionResult> CodeUniteMesureLookup(DataSourceLoadOptions loadOptions)
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


        [HttpPost]
        public async Task<IActionResult> Post_Demande_From_With_Form_Usinage(DemandeFournitureModel values)
        {
            await PostFourniture(values, XpertHelper.CodeUsinage);
            return RedirectToAction("DemandesFourniture", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Demande_From_With_Form_Sodure(DemandeFournitureModel values)
        {
            await PostFourniture(values, XpertHelper.CodeSodure);
            return RedirectToAction("DemandesFourniture", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Demande_From_With_Form_Methode(DemandeFournitureModel values)
        {
            await PostFourniture(values, XpertHelper.CodeMethode);
            return RedirectToAction("DemandesFourniture", "MethodeManager", new { area = "MethodeManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Demande_From_With_Form_Electrique(DemandeFournitureModel values)
        {
            await PostFourniture(values, XpertHelper.CodeElectrique);
            return RedirectToAction("DemandesFourniture", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Demande_From_With_Form_Exploitation(DemandeFournitureModel values)
        {
            await PostFourniture(values, XpertHelper.CodeExploitation);
            return RedirectToAction("DemandesFourniture", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Demande_From_With_Form_Mecanique(DemandeFournitureModel values)
        {
            await PostFourniture(values, XpertHelper.CodeMecanqiue);
            return RedirectToAction("DemandesFourniture", "MecaniqueManager", new { area = "MecaniqueManager" });
        }

        [HttpPost]
        public async Task<IActionResult> Post_Article_Detail_With_Form_Usinage(AjouterArticleFournitureModel values)
        {
            var model = new ApproFournituresArticles();
            if (!values.CodeArticle.Equals(null))
            {
                model.CodeArticle = values.CodeArticle;
                var DesignationArticle = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.DesignationPdr
                }).ToList();
                model.DesignationArticle = DesignationArticle.Last().DesignationPdr;
                var CodeUniteMesure = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.CodeUniteMesurePdr
                }).ToList();
                if (CodeUniteMesure.Last().CodeUniteMesurePdr != null)
                {
                    model.CodeUniteMesure = (int)CodeUniteMesure.Last().CodeUniteMesurePdr;
                }
                else
                {
                    model.CodeUniteMesure = 0;
                }
            }
            else
            {
                model.DesignationArticle = values.ArticleNonGere;
            }
            var ordres = _context.ApproFournituresArticles.AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (ordres.Count() != 0)
            {
                var l = ordres.Last();
                model.Id = l.Id + 1;
            }
            else
            {
                model.Id = 1;
            }
            model.QteDemande = values.Qte;
            model.NumeroDemandeFourniture = (int)XpertHelper.NumDemandeFourniture;

            var LastMovemnt = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
            if (LastMovemnt != null)
            {
                model.QteValable = LastMovemnt.StockTotalSythese;
            }
            else
            {
                var StkInitial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
                if (StkInitial != null)
                {
                    model.QteValable = StkInitial.Qte;
                }
                else
                {
                    model.QteValable = 0;
                }
            }
            _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("DemandesFourniture", "UsinageManager", new { area = "UsinageManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Article_Detail_With_Form_Sodure(AjouterArticleFournitureModel values)
        {
            var model = new ApproFournituresArticles();
            if (!values.CodeArticle.Equals(null))
            {
                model.CodeArticle = values.CodeArticle;
                var DesignationArticle = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.DesignationPdr
                }).ToList();
                model.DesignationArticle = DesignationArticle.Last().DesignationPdr;
                var CodeUniteMesure = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.CodeUniteMesurePdr
                }).ToList();
                if (CodeUniteMesure.Last().CodeUniteMesurePdr != null)
                {
                    model.CodeUniteMesure = (int)CodeUniteMesure.Last().CodeUniteMesurePdr;
                }
                else
                {
                    model.CodeUniteMesure = 0;
                }
            }
            else
            {
                model.DesignationArticle = values.ArticleNonGere;
            }
            var ordres = _context.ApproFournituresArticles.AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (ordres.Count() != 0)
            {
                var l = ordres.Last();
                model.Id = l.Id + 1;
            }
            else
            {
                model.Id = 1;
            }
            model.QteDemande = values.Qte;
            model.NumeroDemandeFourniture = (int)XpertHelper.NumDemandeFourniture;

            var LastMovemnt = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
            if (LastMovemnt != null)
            {
                model.QteValable = LastMovemnt.StockTotalSythese;
            }
            else
            {
                var StkInitial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
                if (StkInitial != null)
                {
                    model.QteValable = StkInitial.Qte;
                }
                else
                {
                    model.QteValable = 0;
                }
            }
            _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("DemandesFourniture", "SodureManager", new { area = "SodureManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Article_Detail_With_Form_Methodes(AjouterArticleFournitureModel values)
        {
            var model = new ApproFournituresArticles();
            if (!values.CodeArticle.Equals(null))
            {
                model.CodeArticle = values.CodeArticle;
                var DesignationArticle = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.DesignationPdr
                }).ToList();
                model.DesignationArticle = DesignationArticle.Last().DesignationPdr;
                var CodeUniteMesure = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.CodeUniteMesurePdr
                }).ToList();
                if (CodeUniteMesure.Last().CodeUniteMesurePdr != null)
                {
                    model.CodeUniteMesure = (int)CodeUniteMesure.Last().CodeUniteMesurePdr;
                }
                else
                {
                    model.CodeUniteMesure = 0;
                }
            }
            else
            {
                model.DesignationArticle = values.ArticleNonGere;
            }
            var ordres = _context.ApproFournituresArticles.AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (ordres.Count() != 0)
            {
                var l = ordres.Last();
                model.Id = l.Id + 1;
            }
            else
            {
                model.Id = 1;
            }
            model.QteDemande = values.Qte;
            model.NumeroDemandeFourniture = (int)XpertHelper.NumDemandeFourniture;

            var LastMovemnt = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
            if (LastMovemnt != null)
            {
                model.QteValable = LastMovemnt.StockTotalSythese;
            }
            else
            {
                var StkInitial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
                if (StkInitial != null)
                {
                    model.QteValable = StkInitial.Qte;
                }
                else
                {
                    model.QteValable = 0;
                }
            }
            _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("DemandesFourniture", "MethodeManager", new { area = "MethodeManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Article_Detail_With_Form_Electrique(AjouterArticleFournitureModel values)
        {
            var model = new ApproFournituresArticles();
            if (!values.CodeArticle.Equals(null))
            {
                model.CodeArticle = values.CodeArticle;
                var DesignationArticle = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.DesignationPdr
                }).ToList();
                model.DesignationArticle = DesignationArticle.Last().DesignationPdr;
                var CodeUniteMesure = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.CodeUniteMesurePdr
                }).ToList();
                if (CodeUniteMesure.Last().CodeUniteMesurePdr != null)
                {
                    model.CodeUniteMesure = (int)CodeUniteMesure.Last().CodeUniteMesurePdr;
                }
                else
                {
                    model.CodeUniteMesure = 0;
                }
            }
            else
            {
                model.DesignationArticle = values.ArticleNonGere;
            }
            var ordres = _context.ApproFournituresArticles.AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (ordres.Count() != 0)
            {
                var l = ordres.Last();
                model.Id = l.Id + 1;
            }
            else
            {
                model.Id = 1;
            }
            model.QteDemande = values.Qte;
            model.NumeroDemandeFourniture = (int)XpertHelper.NumDemandeFourniture;

            var LastMovemnt = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
            if (LastMovemnt != null)
            {
                model.QteValable = LastMovemnt.StockTotalSythese;
            }
            else
            {
                var StkInitial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
                if (StkInitial != null)
                {
                    model.QteValable = StkInitial.Qte;
                }
                else
                {
                    model.QteValable = 0;
                }
            }
            _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("DemandesFourniture", "ElectriqueManager", new { area = "ElectriqueManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Article_Detail_With_Form_Exploitation(AjouterArticleFournitureModel values)
        {
            var model = new ApproFournituresArticles();
            if (!values.CodeArticle.Equals(null))
            {
                model.CodeArticle = values.CodeArticle;
                var DesignationArticle = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.DesignationPdr
                }).ToList();
                model.DesignationArticle = DesignationArticle.Last().DesignationPdr;
                var CodeUniteMesure = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.CodeUniteMesurePdr
                }).ToList();
                if (CodeUniteMesure.Last().CodeUniteMesurePdr != null)
                {
                    model.CodeUniteMesure = (int)CodeUniteMesure.Last().CodeUniteMesurePdr;
                }
                else
                {
                    model.CodeUniteMesure = 0;
                }
            }
            else
            {
                model.DesignationArticle = values.ArticleNonGere;
            }
            var ordres = _context.ApproFournituresArticles.AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (ordres.Count() != 0)
            {
                var l = ordres.Last();
                model.Id = l.Id + 1;
            }
            else
            {
                model.Id = 1;
            }
            model.QteDemande = values.Qte;
            model.NumeroDemandeFourniture = (int)XpertHelper.NumDemandeFourniture;

            var LastMovemnt = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
            if (LastMovemnt != null)
            {
                model.QteValable = LastMovemnt.StockTotalSythese;
            }
            else
            {
                var StkInitial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
                if (StkInitial != null)
                {
                    model.QteValable = StkInitial.Qte;
                }
                else
                {
                    model.QteValable = 0;
                }
            }
            _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("DemandesFourniture", "ExploitationManager", new { area = "ExploitationManager" });
        }
        [HttpPost]
        public async Task<IActionResult> Post_Article_Detail_With_Form_Mecanique(AjouterArticleFournitureModel values)
        {
            var model = new ApproFournituresArticles();
            if (!values.CodeArticle.Equals(null))
            {
                model.CodeArticle = values.CodeArticle;
                var DesignationArticle = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.DesignationPdr
                }).ToList();
                model.DesignationArticle = DesignationArticle.Last().DesignationPdr;
                var CodeUniteMesure = _context.StkPdr.AsNoTracking()
                .Where(o => o.CodePdr == values.CodeArticle)
                .Select(i => new
                {
                    i.CodeUniteMesurePdr
                }).ToList();
                if (CodeUniteMesure.Last().CodeUniteMesurePdr != null)
                {
                    model.CodeUniteMesure = (int)CodeUniteMesure.Last().CodeUniteMesurePdr;
                }
                else
                {
                    model.CodeUniteMesure = 0;
                }
            }
            else
            {
                model.DesignationArticle = values.ArticleNonGere;
            }
            var ordres = _context.ApproFournituresArticles.AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (ordres.Count() != 0)
            {
                var l = ordres.Last();
                model.Id = l.Id + 1;
            }
            else
            {
                model.Id = 1;
            }
            model.QteDemande = values.Qte;
            model.NumeroDemandeFourniture = (int)XpertHelper.NumDemandeFourniture;

            var LastMovemnt = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
            if (LastMovemnt != null)
            {
                model.QteValable = LastMovemnt.StockTotalSythese;
            }
            else
            {
                var StkInitial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList().Last();
                if (StkInitial != null)
                {
                    model.QteValable = StkInitial.Qte;
                }
                else
                {
                    model.QteValable = 0;
                }
            }
            _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("DemandesFourniture", "MecaniqueManager", new { area = "MecaniqueManager" });
        }

        private void PopulateModel(ApproDemandesFourniture model, IDictionary values)
        {

            string NumeroDemande = nameof(ApproDemandesFourniture.NumeroDemande);
            string DateBesoin = nameof(ApproDemandesFourniture.DateBesoin);
            string DateDemande = nameof(ApproDemandesFourniture.DateDemande);
            string Obeservations = nameof(ApproDemandesFourniture.Obeservations);

            if (values.Contains(NumeroDemande))
            {
                model.NumeroDemande = Convert.ToInt32(values[NumeroDemande]);
            }
            if (values.Contains(DateBesoin))
            {
                model.DateBesoin = Convert.ToDateTime(values[DateBesoin]);
            }
            if (values.Contains(DateDemande))
            {
                model.DateDemande = Convert.ToDateTime(values[DateDemande]);
            }
            if (values.Contains(Obeservations))
            {
                model.Obeservations = Convert.ToString(values[Obeservations]);
            }
        }
        private void PopulateModelArticle(ApproFournituresArticles model, IDictionary values)
        {
            string QteDemande = nameof(ApproFournituresArticles.QteDemande);
            if (values.Contains(QteDemande))
            {
                model.QteDemande = Convert.ToInt32(values[QteDemande]);
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