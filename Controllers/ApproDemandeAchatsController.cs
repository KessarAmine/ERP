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
using DevKbfSteel.Helpers;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApproDemandeAchatsController : Controller
    {
        private KBFsteelContext _context;

        public ApproDemandeAchatsController(KBFsteelContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions) {
            var approdemandeachats = _context.ApproDemandeAchats.Where(c => c.DateDemandeAchat.Date >= dateDebut.Date && c.DateDemandeAchat.Date <= dateFin.Date)
                .Select(i => new {
                i.NumDemandeAchat,
                i.CodeServiceDemandeur,
                i.DateDemandeAchat,
                i.CodeNatureDemandeAchat,
                i.MotifDemandeAchat,
                i.StatutDemandeAchat,
                i.UrgenceDemande
            });
            return Json(await DataSourceLoader.LoadAsync(approdemandeachats, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetFromFourniture(int numDemandeFourniture, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumDemandeFournitureMagasin = numDemandeFourniture;
            var approdemandeachats = _context.ApproDemandeAchats.Where(c => c.NumDemandeFourniture == numDemandeFourniture)
                .Select(i => new {
                i.NumDemandeAchat,
                i.CodeServiceDemandeur,
                i.DateDemandeAchat,
                i.CodeNatureDemandeAchat,
                i.MotifDemandeAchat,
                i.StatutDemandeAchat,
                i.UrgenceDemande
                });
            return Json(await DataSourceLoader.LoadAsync(approdemandeachats, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetArticles(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDemandeAchatMagasin = id;
            var approdemandeachats = _context.ApproArticlesDemandes.Where(c => c.NumeroDemande== id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.ArticleNonGere,
                    i.NumeroDemande,
                    i.Qte,
                    i.QteValable,
                    i.QteLivrees,
                    i.QteReste
                });
            return Json(await DataSourceLoader.LoadAsync(approdemandeachats, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetArticlesEntres(int id, DataSourceLoadOptions loadOptions)
        {
            var approdemandeachats = _context.ApproArticlesEntres.Where(c => c.NumBon == id)
                .Select(i => new {
                    i.Id,
                    i.NumBon,
                    i.DesignationArticle,
                    i.Qte
                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumDemandeAchat" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(approdemandeachats, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new ApproDemandeAchats();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.NumDemandeFourniture = XpertHelper.NumDemandeFournitureMagasin;
            model.CodeServiceDemandeur = XpertHelper.CodeMagasin;
            //model.DateDemandeAchat = DateTime.Now.Date;
            model.StatutDemandeAchat = "En Attente";

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var approDemandeAchats = _context.ApproDemandeAchats
              .OrderBy(o => o.NumDemandeAchat)
              .Select(i => new
              {
                  i.NumDemandeAchat
              }).ToList();

            if (approDemandeAchats.Count == 0)
                model.NumDemandeAchat = 1;
            else
            {
                var m = approDemandeAchats.Last();
                model.NumDemandeAchat = Convert.ToInt32(m.NumDemandeAchat) + 1;
            }
            var result = _context.ApproDemandeAchats.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumDemandeAchat);
        }
        [HttpPost]
        public async Task<IActionResult> PostArticles(string values)
        {
            var model = new ApproArticlesDemandes();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelArticles(model, valuesDict);
            if (model.Qte <= 0)
            {
                return StatusCode(409, "Veuillez entrer une QTE supérieur à 0");
            }
            else
            {
                model.NumeroDemande = (int)XpertHelper.NumDemandeAchatMagasin;
                if (!TryValidateModel(model))
                    return BadRequest(GetFullErrorMessage(ModelState));
                var ArticlesDemandes = _context.ApproArticlesDemandes
                  .OrderBy(o => o.Id)
                  .Select(i => new
                  {
                      i.Id
                  }).ToList();

                if (ArticlesDemandes.Count == 0)
                    model.Id = 1;
                else
                {
                    var m = ArticlesDemandes.Last();
                    model.Id = Convert.ToInt32(m.Id) + 1;
                }
            }
            var Movemnts = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList();
            if (Movemnts.Count() > 0)
            {
                var LastMovemnt = Movemnts.Last();
                model.QteValable = LastMovemnt.StockTotalSythese;
            }
            else
            {
                var StkInitials = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == model.CodeArticle).ToList();
                if (StkInitials.Count() > 0)
                {
                    var StkInitial = StkInitials.Last();
                    model.QteValable = StkInitial.Qte;
                }
                else
                {
                    model.QteValable = 0;
                }
            }
            var result = _context.ApproArticlesDemandes.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostBons(string values)
        {
            var model = new ApproBonsEntrees();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBons(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var BonsEntrees = _context.ApproBonsEntrees
              .OrderBy(o => o.NumBon)
              .Select(i => new
              {
                  i.NumBon
              }).ToList();

            if (BonsEntrees.Count == 0)
                model.NumBon = 1;
            else
            {
                var m = BonsEntrees.Last();
                model.NumBon = Convert.ToInt32(m.NumBon) + 1;
            }
            model.DateEntree = DateTime.Now.Date;

            var result = _context.ApproBonsEntrees.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBon);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.ApproDemandeAchats.FirstOrDefaultAsync(item => item.NumDemandeAchat == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutArticles(int key, string values)
        {
            var model = await _context.ApproArticlesDemandes.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelArticles(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutBons(int key, string values)
        {
            var model = await _context.ApproBonsEntrees.FirstOrDefaultAsync(item => item.NumBon == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBons(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.ApproDemandeAchats.FirstOrDefaultAsync(item => item.NumDemandeAchat == key);
            _context.ApproDemandeAchats.Remove(model);
            //Change  Status of Demande Fourniture

            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteArticles(int key)
        {
            var model = await _context.ApproArticlesDemandes.FirstOrDefaultAsync(item => item.Id == key);

            _context.ApproArticlesDemandes.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteBons(int key)
        {
            var model = await _context.ApproBonsEntrees.FirstOrDefaultAsync(item => item.NumBon == key);

            _context.ApproBonsEntrees.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult> ApproServicesDemandeursLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.ApproServicesDemandeurs
                         orderby i.DesignationService
                         select new {
                             Value = i.CodeService,
                             Text = i.DesignationService
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> ApproNatureDemandeAchatLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.ApproNatureDemandeFourniture
                         orderby i.CodeNatureDemande
                         select new {
                             Value = i.CodeNatureDemande,
                             Text = i.DesignationNatureDemande
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> UregenceDemandeLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.UrgenceTravaille
                         orderby i.CodeUrgence
                         select new {
                             Value = i.CodeUrgence,
                             Text = i.DesignationUrgence
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> ApproStatutLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.ApproStatut
                         orderby i.DesignationStatut
                         select new {
                             Value = i.DesignationStatut,
                             Text = i.DesignationStatut
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(ApproDemandeAchats model, IDictionary values) {
            string NUM_DEMANDE_ACHAT = nameof(ApproDemandeAchats.NumDemandeAchat);
            string CODE_SERVICE_DEMANDEUR = nameof(ApproDemandeAchats.CodeServiceDemandeur);
            string DATE_DEMANDE_ACHAT = nameof(ApproDemandeAchats.DateDemandeAchat);
            string StatutDemandeAchat = nameof(ApproDemandeAchats.StatutDemandeAchat);
            string MotifDemandeAchat = nameof(ApproDemandeAchats.MotifDemandeAchat);
            string CodeNatureDemandeAchat = nameof(ApproDemandeAchats.CodeNatureDemandeAchat);
            string UrgenceDemande = nameof(ApproDemandeAchats.UrgenceDemande);

            if(values.Contains(MotifDemandeAchat)) {
                model.MotifDemandeAchat = Convert.ToString(values[MotifDemandeAchat]);
            }
            if(values.Contains(StatutDemandeAchat)) {
                model.StatutDemandeAchat = Convert.ToString(values[StatutDemandeAchat]);
            }
            if(values.Contains(NUM_DEMANDE_ACHAT)) {
                model.NumDemandeAchat = Convert.ToInt32(values[NUM_DEMANDE_ACHAT]);
            }
            if(values.Contains(CodeNatureDemandeAchat)) {
                model.CodeNatureDemandeAchat = Convert.ToInt32(values[CodeNatureDemandeAchat]);
            }
            if(values.Contains(CODE_SERVICE_DEMANDEUR)) {
                model.CodeServiceDemandeur = Convert.ToInt32(values[CODE_SERVICE_DEMANDEUR]);
            }
            if(values.Contains(UrgenceDemande)) {
                model.UrgenceDemande = Convert.ToBoolean(values[UrgenceDemande]);
            }
            if(values.Contains(DATE_DEMANDE_ACHAT)) {
                model.DateDemandeAchat = Convert.ToDateTime(values[DATE_DEMANDE_ACHAT]);
            }
        }
        private void PopulateModelArticles(ApproArticlesDemandes model, IDictionary values)
        {
            string CodeArticle = nameof(ApproArticlesDemandes.CodeArticle);
            string ArticleNonGere = nameof(ApproArticlesDemandes.ArticleNonGere);
            string NumeroDemande = nameof(ApproArticlesDemandes.NumeroDemande);
            string Qte = nameof(ApproArticlesDemandes.Qte);
            string QteLivrees = nameof(ApproArticlesDemandes.QteLivrees);
            string QteReste = nameof(ApproArticlesDemandes.QteReste);

            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(ArticleNonGere))
            {
                model.ArticleNonGere = Convert.ToString(values[ArticleNonGere]);
            }
            if (values.Contains(NumeroDemande))
            {
                model.NumeroDemande = Convert.ToInt32(values[NumeroDemande]);
            }

            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToDouble(values[Qte]);
            }
            if (values.Contains(QteLivrees))
            {
                model.QteLivrees = Convert.ToDouble(values[QteLivrees]);
            }
            if (values.Contains(QteReste))
            {
                model.QteReste = Convert.ToDouble(values[QteReste]);
            }

        }
        private void PopulateModelBons(ApproBonsEntrees model, IDictionary values)
        {
            string NumBon = nameof(ApproBonsEntrees.NumBon);
            string DateEntree = nameof(ApproBonsEntrees.DateEntree);

            if (values.Contains(NumBon))
            {
                model.NumBon = Convert.ToInt32(values[NumBon]);
            }
            if (values.Contains(DateEntree))
            {
                model.DateEntree = Convert.ToDateTime(values[DateEntree]);
            }


        }
        private void PopulateModelArticlesEntres(ApproArticlesEntres model, IDictionary values)
        {
            string Id = nameof(ApproArticlesEntres.Id);
            string NumBon = nameof(ApproArticlesEntres.NumBon);
            string DesignationArticle = nameof(ApproArticlesEntres.DesignationArticle);
            string Qte = nameof(ApproArticlesEntres.Qte);
            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(NumBon))
            {
                model.NumBon = Convert.ToInt32(values[NumBon]);
            }
            if (values.Contains(DesignationArticle))
            {
                model.DesignationArticle = Convert.ToString(values[DesignationArticle]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
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