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
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Internal;
using DevExpress.Data.Extensions;
using Newtonsoft.Json.Linq;
using DevKbfSteel.Helpers;
namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class GestionPersonnelsMagasinController : Controller
    {
        private KBFsteelContext _context;
        public GestionPersonnelsMagasinController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var intervenants = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(c =>c.Departement == XpertHelper.CodeMagasin)
                .Select(i => new {
                    i.Id,
                    i.Nom,
                    i.Prenom,
                    i.CodeSpecialité,
                    i.CodeEquipe,
                    i.TelProfesionnel
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(intervenants, loadOptions));
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.RhListeDesEmployes.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //============ Suivi ===========================
        [HttpGet]
        public async Task<IActionResult> GetEntrees(int id,DataSourceLoadOptions loadOptions)
        {
            var StkBonEntree = _context.StkBonEntree
                .Where(c => c.CodeIntervenant ==id)
                .Select(i => new {
                    i.NumBon,
                    i.CodeFournisseur,
                    i.DateEntree,
                    i.DateDa,
                    i.Nda,
                    i.NumSource,
                    i.TauxChange,
                    i.TypeAchat,
                    i.TypeDevise,
                    i.TypeSource
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkBonEntree, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetSorties(int id,DataSourceLoadOptions loadOptions)
        {
            var StkBonSortie = _context.StkBonSortie
                .Where(c => c.CodeIntervenant == id)
                .Select(i => new {
                    i.CodeServiceEmetteur,
                    i.DateSortie,
                    i.NumBonSortie,
                    i.NumDemandeFourniture,
                    i.TypeSortie
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkBonSortie, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDécharges(int id, DataSourceLoadOptions loadOptions)
        {
            var StkDecharge = _context.StkDecharge
                .Where(c => c.CodeIntervenant == id)
                .Select(i => new
                {
                    i.DateDecharge,
                    i.NumDecharge,
                    i.ServiceReceveur
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkDecharge, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetRestitutions(int id,DataSourceLoadOptions loadOptions)
        {
            var StkRestitution = _context.StkRestitution
                .Where(c => c.CodeIntervenant == id)
                .Select(i => new {
                    i.DateRestitution,
                    i.NumDecharge,
                    i.NumRestitution,
                    i.ServiceEmetteur
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkRestitution, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetAffectations(int id, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkAffectations
                .Where(c => c.CodeIntervenant == id)
                .Select(i => new {
                    i.DateAffectation,
                    i.DateEntree,
                    i.NumBonAffectation,
                    i.NumBonEntree,
                    i.SericeEmetteur,
                    i.ServiceReceveur
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetReintegration(int id,DataSourceLoadOptions loadOptions)
        {
            var StkReintegration = _context.StkReintegration
                .Where(c => c.CodeIntervenant == id)
                .Select(i => new {
                    i.DateReingegration,
                    i.NumBonReintegration,
                    i.ServiceEmetteur
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkReintegration, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetTransferts(int id,DataSourceLoadOptions loadOptions)
        {
            var StkBonTransfert = _context.StkBonTransfert
                .Where(c => c.CodeIntervenant == id)
                .Select(i => new {
                    i.DateTransfert,
                    i.NumBonTransfert,
                    i.Source,
                    i.Destination
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkBonTransfert, loadOptions));
        }
        //============ Lookup ===========================
        [HttpGet]
        public async Task<IActionResult> NomLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         where i.Departement == XpertHelper.CodeMecanqiue && i.Disponnible != 3 && i.Disponnible != null
                         select new
                         {
                             Value = i.Id,
                             Text = i.Nom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //============ PopulateModel============================
        private void PopulateModel(RhListeDesEmployes model, IDictionary values)
        {
            string CodeEquipe = nameof(RhListeDesEmployes.CodeEquipe);

            if (values.Contains(CodeEquipe))
            {
                model.CodeEquipe = Convert.ToInt32(values[CodeEquipe]);
            }
        }

    }
}