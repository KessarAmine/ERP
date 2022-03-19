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
using DevKbfSteel.Areas.MagasinSuperviseur.Models;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Controllers
{
    [Area(nameof(Areas.MagasinSuperviseur))]

    public class InventairesController : Controller
    {
        private KBFsteelContext _context;
        public InventairesController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> GetInventaires(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkInventaires
                .Where(c => c.DateDebut.Date >= dateDebut.Date)
                .Select(i => new {
                    i.NumInventaire,
                    i.DateDebut,
                    i.DateFin
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetInventairesArticles(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumInventaire = id;
            var StkAffectations = _context.StkInventairesArticles
                .Where(c => c.NumInventaire == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.CodeEquipe,
                    i.Qte
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetInventairesEquipesMembres(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumInventaireEquipe = id;
            var StkAffectationsArticles = _context.StkInventairesEquipeMembres
                .Where(c => c.NumEquipe == id)
                .Select(i => new {
                    i.Id,
                    i.CodeMembre
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectationsArticles, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetInventairesEquipes(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumInventaire = id;
            var StkAffectationsArticles = _context.StkInventairesEquipes
                .Where(c => c.NumInventaire == id)
                .Select(i => new {
                    i.Id,
                    i.NomEquipe,
                    i.CodeResponsable
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectationsArticles, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetInventairesLieux(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumInventaire = id;
            var StkAffectationsArticles = _context.StkInventairesLieux
                .Where(c => c.NumInventaire == id)
                .Select(i => new {
                    i.Id,
                    i.CodeLieu
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectationsArticles, loadOptions));
        }
        [HttpGet]
        public object GetPapillonComptageEquipe(int id, DataSourceLoadOptions loadOptions)
        {
            List<PapillonComptageEquipeModel> PapillonComptageEquipeModelList = new List<PapillonComptageEquipeModel>();
            var StkInventairesArticles = _context.StkInventairesArticles
                .AsNoTracking()
                .Where(c => c.CodeEquipe == id && c.Qte != null)
                .Select(i => new {
                    i.CodeArticle,
                    i.Qte
                }).ToList();
            foreach (var itemStkInventairesArticles in StkInventairesArticles)
            {
                PapillonComptageEquipeModel papillonComptageEquipeModel = new PapillonComptageEquipeModel();
                var StkPdr = _context.StkPdr
                    .AsNoTracking()
                    .Where(c => c.CodePdr == itemStkInventairesArticles.CodeArticle)
                    .Select(i => new {
                        i.CodeUniteMesurePdr
                    }).ToList();
                var pdr = StkPdr.Last();
                var StkEmplacement = _context.StkEmplacement
                    .AsNoTracking()
                    .Where(c => c.CodePdr == itemStkInventairesArticles.CodeArticle)
                    .Select(i => new {
                        i.CodeGisement
                    }).ToList();
                var empl = StkEmplacement.Last();
                papillonComptageEquipeModel.CodePdr = itemStkInventairesArticles.CodeArticle;
                papillonComptageEquipeModel.CodeUniteMesure = (int)pdr.CodeUniteMesurePdr;
                papillonComptageEquipeModel.CodeGisement = (int)empl.CodeGisement;
                if(itemStkInventairesArticles.Qte != null)
                {
                    papillonComptageEquipeModel.Quantite = (float)itemStkInventairesArticles.Qte;
                }
                PapillonComptageEquipeModelList.Add(papillonComptageEquipeModel);
            }
            return DataSourceLoader.Load(PapillonComptageEquipeModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetEcartInventaire(int id, DataSourceLoadOptions loadOptions)
        {
            List<EcartInventaireModel> EcartInventaireModelList = new List<EcartInventaireModel>();
            var StkInventairesArticles = _context.StkInventairesArticles
                .AsNoTracking()
                .Where(c => c.NumInventaire == id)
                .Select(i => new {
                    i.CodeArticle,
                    i.CodeEquipe,
                    i.Qte
                }).ToList();

            foreach (var itemStkInventairesArticles in StkInventairesArticles)
            {
                var isUpdate = 0;
                foreach (var itemEcartInventaireModelList in EcartInventaireModelList)
                {
                    if(itemEcartInventaireModelList.CodeArticle == itemStkInventairesArticles.CodeArticle)
                    {
                        var UpdtStkInventairesEquipes = _context.StkInventairesEquipes
                        .AsNoTracking()
                        .Where(c => c.Id == itemStkInventairesArticles.CodeEquipe)
                        .Select(i => new {
                            i.NomEquipe
                        }).ToList();
                        var Updteq = UpdtStkInventairesEquipes.Last();
                        if (Updteq.NomEquipe.Equals("1"))
                        {
                            if (itemStkInventairesArticles.Qte.Equals(null))
                                itemEcartInventaireModelList.Equipe1 = 0;
                            else
                                itemEcartInventaireModelList.Equipe1 = (int)itemStkInventairesArticles.Qte;
                        }
                        if (Updteq.NomEquipe.Equals("2"))
                        {
                            if (itemStkInventairesArticles.Qte.Equals(null))
                                itemEcartInventaireModelList.Equipe2 = 0;
                            else
                                itemEcartInventaireModelList.Equipe2 = (int)itemStkInventairesArticles.Qte;
                        }
                        if (Updteq.NomEquipe.Equals("Control"))
                        {
                            if (itemStkInventairesArticles.Qte.Equals(null))
                                itemEcartInventaireModelList.EquipeControl = 0;
                            else
                                itemEcartInventaireModelList.EquipeControl = (int)itemStkInventairesArticles.Qte;
                        }
                        itemEcartInventaireModelList.Ecart = itemEcartInventaireModelList.Equipe1 - itemEcartInventaireModelList.Equipe2;
                        itemEcartInventaireModelList.ECE1 = itemEcartInventaireModelList.EquipeControl - itemEcartInventaireModelList.Equipe1;
                        itemEcartInventaireModelList.ECE2 = itemEcartInventaireModelList.EquipeControl - itemEcartInventaireModelList.Equipe2;
                        isUpdate = 1;
                    }
                }
                if (isUpdate == 0)
                {
                    EcartInventaireModel ecartInventaireModel = new EcartInventaireModel();
                    ecartInventaireModel.CodeArticle = itemStkInventairesArticles.CodeArticle;
                    var StkInventairesEquipes = _context.StkInventairesEquipes
                    .AsNoTracking()
                    .Where(c => c.Id == itemStkInventairesArticles.CodeEquipe)
                    .Select(i => new {
                        i.NomEquipe
                    }).ToList();
                    if(StkInventairesEquipes.Count() > 0)
                    {
                        var eq = StkInventairesEquipes.Last();
                        if (eq.NomEquipe.Equals("1"))
                        {
                            if(itemStkInventairesArticles.Qte.Equals(null))
                                ecartInventaireModel.Equipe1 = 0;
                            else
                                ecartInventaireModel.Equipe1 = (int)itemStkInventairesArticles.Qte;
                            ecartInventaireModel.Equipe2 = 0;
                            ecartInventaireModel.EquipeControl = 0;
                        }
                        if (eq.NomEquipe.Equals("2"))
                        {
                            ecartInventaireModel.Equipe1 = 0;
                            if (itemStkInventairesArticles.Qte.Equals(null))
                                ecartInventaireModel.Equipe2 = 0;
                            else
                                ecartInventaireModel.Equipe2 = (int)itemStkInventairesArticles.Qte; 
                            ecartInventaireModel.EquipeControl = 0;
                        }
                        if (eq.NomEquipe.Equals("Control"))
                        {
                            ecartInventaireModel.Equipe1 = 0;
                            ecartInventaireModel.Equipe2 = 0;
                            if (itemStkInventairesArticles.Qte.Equals(null))
                                ecartInventaireModel.EquipeControl = 0;
                            else
                                ecartInventaireModel.EquipeControl = (int)itemStkInventairesArticles.Qte;
                        }
                        ecartInventaireModel.Ecart = ecartInventaireModel.Equipe1 - ecartInventaireModel.Equipe2;
                        ecartInventaireModel.ECE1 = ecartInventaireModel.EquipeControl - ecartInventaireModel.Equipe1;
                        ecartInventaireModel.ECE2 = ecartInventaireModel.EquipeControl - ecartInventaireModel.Equipe2;

                        EcartInventaireModelList.Add(ecartInventaireModel);
                    }
                }
            }
            return DataSourceLoader.Load(EcartInventaireModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetEtatInventaire(int id, DataSourceLoadOptions loadOptions)
        {
            List<EtatInventaireModel> EtatInventaireModelList = new List<EtatInventaireModel>();
            var StkInventairesEquipes = _context.StkInventairesEquipes
            .AsNoTracking()
            .Where(c => c.NumInventaire == id && c.NomEquipe.Equals("Control"))
            .Select(i => new {
                i.Id
            }).ToList();
            if(StkInventairesEquipes.Count() >0)
            {
                var IdEquipe = StkInventairesEquipes.Last().Id;
                var StkInventairesArticles = _context.StkInventairesArticles
                .AsNoTracking()
                .Where(c => c.CodeEquipe == IdEquipe && c.Qte != null)
                .Select(i => new {
                    i.CodeArticle,
                    i.Qte
                }).ToList();
                foreach (var itemStkInventairesArticles in StkInventairesArticles)
                {
                    EtatInventaireModel etatInventaireModel = new EtatInventaireModel();
                    etatInventaireModel.CodeArticle = itemStkInventairesArticles.CodeArticle;
                    var ArticleCmup = _context.StkMovements
                    .AsNoTracking()
                    .Where(c => c.CodePdr == etatInventaireModel.CodeArticle)
                    .Select(i => new {
                        i.ValeurValorisation,
                        i.ValeurStockTotal
                    }).ToList();
                    if (ArticleCmup.Count() > 0)
                    {
                        etatInventaireModel.Cout = (double)ArticleCmup.Last().ValeurValorisation;
                        etatInventaireModel.QuantiteThe = (int)ArticleCmup.Last().ValeurStockTotal;
                        etatInventaireModel.ValeurThe = etatInventaireModel.Cout * etatInventaireModel.QuantiteThe;
                    }
                    else
                    {
                        etatInventaireModel.Cout = 0.0;
                        etatInventaireModel.QuantiteThe = 0;
                        etatInventaireModel.ValeurThe = 0;
                    }
                    etatInventaireModel.QuantitePhy = (int)itemStkInventairesArticles.Qte;
                    etatInventaireModel.ValeurPhy = etatInventaireModel.QuantitePhy * etatInventaireModel.Cout;
                    etatInventaireModel.QuantiteEcart = etatInventaireModel.QuantiteThe - etatInventaireModel.QuantitePhy;
                    etatInventaireModel.ValeurEcart = etatInventaireModel.ValeurThe - etatInventaireModel.ValeurPhy;
                    EtatInventaireModelList.Add(etatInventaireModel);
                }
            }
            return DataSourceLoader.Load(EtatInventaireModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetInventaireFinal(int id, DataSourceLoadOptions loadOptions)
        {
            List<InventaireFinalModel> InventaireFinalModelList = new List<InventaireFinalModel>();
            var StkInventairesEquipes = _context.StkInventairesEquipes
            .AsNoTracking()
            .Where(c => c.NumInventaire == id && c.NomEquipe.Equals("Control"))
            .Select(i => new {
                i.Id
            }).ToList();
            if(StkInventairesEquipes.Count() >0)
            {
                var IdEquipe = StkInventairesEquipes.Last().Id;
                var StkInventairesArticles = _context.StkInventairesArticles
                .AsNoTracking()
                .Where(c => c.CodeEquipe == IdEquipe && c.Qte != null)
                .Select(i => new {
                    i.CodeArticle,
                    i.Qte
                }).ToList();
                foreach (var itemStkInventairesArticles in StkInventairesArticles)
                {
                    InventaireFinalModel inventaireFinalModel = new InventaireFinalModel();
                    inventaireFinalModel.CodeArticle = itemStkInventairesArticles.CodeArticle;
                    var ArticleCmup = _context.StkMovements
                    .AsNoTracking()
                    .Where(c => c.CodePdr == inventaireFinalModel.CodeArticle)
                    .Select(i => new {
                        i.ValeurValorisation
                    }).ToList();
                    if (ArticleCmup.Count() > 0)
                    {
                        inventaireFinalModel.Cout = (double)ArticleCmup.Last().ValeurValorisation;
                    }
                    else
                    {
                        inventaireFinalModel.Cout = 0.0;
                    }
                    inventaireFinalModel.Quantite = (int)itemStkInventairesArticles.Qte;
                    inventaireFinalModel.Valeur = (float)(inventaireFinalModel.Quantite * inventaireFinalModel.Cout);
                    InventaireFinalModelList.Add(inventaireFinalModel);
                }
            }
            return DataSourceLoader.Load(InventaireFinalModelList.AsEnumerable(), loadOptions);
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostInventaire(string values)
        {
            var model = new StkInventaires();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaire(model, valuesDict);
            var StkReceptionBillette = _context.StkInventaires
                .OrderBy(o => o.NumInventaire)
                .Select(i => new
                {
                    i.NumInventaire
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.NumInventaire = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.NumInventaire = Convert.ToInt32(m.NumInventaire) + 1;
            }
            var result = _context.StkInventaires.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumInventaire);
        }
        [HttpPost]
        public async Task<IActionResult> PostInventaireLieu(string values)
        {
            var model = new StkInventairesLieux();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireLieux(model, valuesDict);
            var StkReceptionBillette = _context.StkInventairesLieux
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.NumInventaire = (int)XpertHelper.NumInventaire;
            var result = _context.StkInventairesLieux.Add(model);
            //==================== ADD articles from this lieu to inventaireArticles
            var Articles = _context.StkEmplacement
                .AsNoTracking()
                .Where(o => o.CodeLieu == model.CodeLieu)
                .Select(i => new
                {
                    i.CodePdr
                }).ToList();
            foreach (var itemArticles in Articles)
            {
                var StkInventairesEquipes = _context.StkInventairesEquipes
                .AsNoTracking()
                .Where(o => o.NumInventaire == XpertHelper.NumInventaire)
                .Select(i => new
                {
                    i.Id
                }).ToList();
                foreach (var itemStkInventairesEquipes in StkInventairesEquipes)
                {
                    var modelArticle = new StkInventairesArticles();
                    var StkInventairesArticles = _context.StkInventairesArticles
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();

                    if (StkInventairesArticles.Count == 0)
                        modelArticle.Id = 1;
                    else
                    {
                        var m = StkInventairesArticles.Last();
                        modelArticle.Id = Convert.ToInt32(m.Id) + 1;
                    }
                    modelArticle.CodeArticle = (int)itemArticles.CodePdr;
                    modelArticle.CodeEquipe = itemStkInventairesEquipes.Id;
                    modelArticle.NumInventaire = (int)XpertHelper.NumInventaire;
                    var resultArticle = _context.StkInventairesArticles.Add(modelArticle);
                    _context.SaveChanges();
                }
            }
            if (Articles.Count == 0)
            {
                return StatusCode(406, "La Lieu : " + model.CodeLieu + "ne contient aucun article");
            }
            await _context.SaveChangesAsync();
            return StatusCode(200, "La Lieu : " + model.CodeLieu + "est ajouté ainsi que ses articles");
        }
        [HttpPost]
        public async Task<IActionResult> PostInventaireEquipe(string values)
        {
            var model = new StkInventairesEquipes();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireEquipe(model, valuesDict);
            var StkReceptionBillette = _context.StkInventairesEquipes
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.NumInventaire = (int)XpertHelper.NumInventaire;
            var result = _context.StkInventairesEquipes.Add(model);
            List<int> PdrList = new List<int>();
            var StkInventairesArticles = _context.StkInventairesArticles
            .AsNoTracking()
            .Distinct()
            .Where(o => o.NumInventaire == XpertHelper.NumInventaire)
            .Select(i => new
            {
                i.CodeArticle
            }).ToList();
            foreach (var itemStkInventairesArticles in StkInventairesArticles)
            {
                if (!PdrList.Contains(itemStkInventairesArticles.CodeArticle))
                {
                    PdrList.Add(itemStkInventairesArticles.CodeArticle);
                }
            }
            foreach (var itemPdrList in PdrList)
            {
                StkInventairesArticles modelArticle = new StkInventairesArticles();
                var Articles = _context.StkInventairesArticles
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

                if (Articles.Count == 0)
                    modelArticle.Id = 1;
                else
                {
                    var m = Articles.Last();
                    modelArticle.Id = Convert.ToInt32(m.Id) + 1;
                }
                modelArticle.CodeArticle = itemPdrList;
                modelArticle.CodeEquipe = model.Id;
                modelArticle.NumInventaire = (int)XpertHelper.NumInventaire;
                var resultArticle = _context.StkInventairesArticles.Add(modelArticle);
                _context.SaveChanges();
            }
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostInventaireEquipeMembres(string values)
        {
            var model = new StkInventairesEquipeMembres();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireEquipeMembre(model, valuesDict);
            var StkReceptionBillette = _context.StkInventairesEquipeMembres
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.NumEquipe = (int)XpertHelper.NumInventaireEquipe;
            var result = _context.StkInventairesEquipeMembres.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostInventaireArticles(string values)
        {
            var model = new StkInventairesArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireArticles(model, valuesDict);
            var StkReceptionBillette = _context.StkInventairesArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.NumInventaire = (int)XpertHelper.NumInventaire;
            var result = _context.StkInventairesArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutInventaire(int key, string values)
        {
            var model = await _context.StkInventaires.FirstOrDefaultAsync(item => item.NumInventaire == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaire(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutInventaireLieu(int key, string values)
        {
            var model = await _context.StkInventairesLieux.FirstOrDefaultAsync(item => item.Id == key);
            var OldEmpl = model.CodeLieu;
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireLieux(model, valuesDict);
            var newEmpl = model.CodeLieu;
            //We delete Articles of oldEmpl and add new Articles of new Empl if they are not the same
            if (!OldEmpl.Equals(newEmpl))
            {
                var OldArticles = _context.StkEmplacement
                .AsNoTracking()
                .Where(o => o.CodeLieu == OldEmpl)
                .Select(i => new
                {
                    i.CodePdr
                }).ToList();
                foreach (var itemOldArticles in OldArticles)
                {

                    var modelOldArtilce = await _context.StkInventairesArticles.FirstOrDefaultAsync(item => item.CodeArticle == itemOldArticles.CodePdr);
                    _context.StkInventairesArticles.Remove(modelOldArtilce);
                }
                var NewArticles = _context.StkEmplacement
                .AsNoTracking()
                .Where(o => o.CodeLieu == newEmpl)
                .Select(i => new
                {
                    i.CodePdr
                }).ToList();
                foreach (var itemNewArticles in NewArticles)
                {

                    var StkInventairesEquipes = _context.StkInventairesEquipes
                    .AsNoTracking()
                    .Where(o => o.NumInventaire == XpertHelper.NumInventaire)
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();
                    foreach (var itemStkInventairesEquipes in StkInventairesEquipes)
                    {
                        var modelArticle = new StkInventairesArticles();
                        var StkInventairesArticles = _context.StkInventairesArticles
                        .AsNoTracking()
                        .OrderBy(o => o.Id)
                        .Select(i => new
                        {
                            i.Id
                        }).ToList();

                        if (StkInventairesArticles.Count == 0)
                            modelArticle.Id = 1;
                        else
                        {
                            var m = StkInventairesArticles.Last();
                            modelArticle.Id = Convert.ToInt32(m.Id) + 1;
                        }
                        modelArticle.CodeArticle = (int)itemNewArticles.CodePdr;
                        modelArticle.CodeEquipe = itemStkInventairesEquipes.Id;
                        modelArticle.NumInventaire = (int)XpertHelper.NumInventaire;
                        var resultArticle = _context.StkInventairesArticles.Add(modelArticle);
                        _context.SaveChanges();

                    }
                }
                if (NewArticles.Count == 0)
                {
                    return StatusCode(406, "La nouveau Lieu : " + newEmpl + "ne contient aucun article");
                }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutInventaireEquipe(int key, string values)
        {
            var model = await _context.StkInventairesEquipes.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireEquipe(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutInventaireEquipeMembres(int key, string values)
        {
            var model = await _context.StkInventairesEquipeMembres.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireEquipeMembre(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutInventaireArticles(int key, string values)
        {
            var model = await _context.StkInventairesArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelInventaireArticles(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteInventaire(int key)
        {
            var model = await _context.StkInventaires.FirstOrDefaultAsync(item => item.NumInventaire == key);
            _context.StkInventaires.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task<ObjectResult> DeleteInventaireLieu(int key)
        {
            var model = await _context.StkInventairesLieux.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkInventairesLieux.Remove(model);
            var OldArticles = _context.StkEmplacement
            .AsNoTracking()
            .Where(o => o.CodeLieu == model.CodeLieu)
            .Select(i => new
            {
                i.CodePdr
            }).ToList();
            foreach (var itemOldArticles in OldArticles)
            {

                var modelOldArtilce = await _context.StkInventairesArticles.FirstOrDefaultAsync(item => item.CodeArticle == itemOldArticles.CodePdr);
                _context.StkInventairesArticles.Remove(modelOldArtilce);
            }
            await _context.SaveChangesAsync();
            return StatusCode(200, "La Lieu : " + model.CodeLieu + "est retiré ainsi que ses articles");
        }
        [HttpDelete]
        public async Task DeleteInventaireEquipe(int key)
        {
            var model = await _context.StkInventairesEquipes.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkInventairesEquipes.Remove(model);
            var OldArticles = _context.StkInventairesArticles
            .AsNoTracking()
            .Where(o => o.CodeEquipe == model.Id)
            .Select(i => new
            {
                i.Id
            }).ToList();
            foreach (var itemOldArticles in OldArticles)
            {

                var modelOldArtilce = await _context.StkInventairesArticles.FirstOrDefaultAsync(item => item.Id == itemOldArticles.Id);
                _context.StkInventairesArticles.Remove(modelOldArtilce);
            }
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteInventaireEquipeMembres(int key)
        {
            var model = await _context.StkInventairesEquipeMembres.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkInventairesEquipeMembres.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteInventaireArticles(int key)
        {
            var model = await _context.StkInventairesArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkInventairesArticles.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> NomEquipeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupEquipeInventaire
                         select new
                         {
                             Value = i.DesignationEquipe,
                             Text = i.DesignationEquipe
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> EquipeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkInventairesEquipes
                         where i.NumInventaire == XpertHelper.NumInventaire
                         select new
                         {
                             Value = i.Id,
                             Text = i.NomEquipe
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
        private void PopulateModelInventaire(StkInventaires model, IDictionary values)
        {
            string DateDebut = nameof(StkInventaires.DateDebut);
            string DateFin = nameof(StkInventaires.DateFin);
            if (values.Contains(DateDebut))
            {
                model.DateDebut = Convert.ToDateTime(values[DateDebut]);
            }
            if (values.Contains(DateFin))
            {
                model.DateFin = Convert.ToDateTime(values[DateFin]);
            }
        }
        private void PopulateModelInventaireArticles(StkInventairesArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkInventairesArticles.CodeArticle);
            string CodeEquipe = nameof(StkInventairesArticles.CodeEquipe);
            string Qte = nameof(StkInventairesArticles.Qte);
            if (values.Contains(CodeArticle))
            {
                model.CodeArticle = Convert.ToInt32(values[CodeArticle]);
            }
            if (values.Contains(CodeEquipe))
            {
                model.CodeEquipe = Convert.ToInt32(values[CodeEquipe]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
        }
        private void PopulateModelInventaireEquipeMembre(StkInventairesEquipeMembres model, IDictionary values)
        {
            string CodeMembre = nameof(StkInventairesEquipeMembres.CodeMembre);
            if (values.Contains(CodeMembre))
            {
                model.CodeMembre = Convert.ToInt32(values[CodeMembre]);
            }
        }
        private void PopulateModelInventaireEquipe(StkInventairesEquipes model, IDictionary values)
        {
            string CodeResponsable = nameof(StkInventairesEquipes.CodeResponsable);
            string NomEquipe = nameof(StkInventairesEquipes.NomEquipe);
            if (values.Contains(CodeResponsable))
            {
                model.CodeResponsable = Convert.ToInt32(values[CodeResponsable]);
            }
            if (values.Contains(NomEquipe))
            {
                model.NomEquipe = Convert.ToString(values[NomEquipe]);
            }
        }
        private void PopulateModelInventaireLieux(StkInventairesLieux model, IDictionary values)
        {
            string CodeLieu = nameof(StkInventairesLieux.CodeLieu);
            if (values.Contains(CodeLieu))
            {
                model.CodeLieu = Convert.ToInt32(values[CodeLieu]);
            }
        }
    }
}
