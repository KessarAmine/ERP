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

namespace DevKbfSteel.Areas.MagasinManager.Controllers
{
    [Area(nameof(Areas.MagasinManager))]

    public class MovementsController : Controller
    {
        private KBFsteelContext _context;
        public MovementsController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkBonSortie = _context.StkMovements
                .Where(c => c.DateMovment.Date >= dateDebut.Date && c.DateMovment.Date <= dateFin.Date)
                .Select(i => new {
                    i.IdMovement,
                    i.IdDetail,
                    i.CodePdr,
                    i.DateMovment,
                    i.Montant,
                    i.PrixUnitaire,
                    i.Qte,
                    i.StockTotalSythese,
                    i.TypeMovement,
                    i.TypeValorisation,
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonSortie, loadOptions));
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> TypeMovementLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkTypeMovement
                         orderby i.CodeMovement
                         select new
                         {
                             Value = i.CodeMovement,
                             Text = i.DesignationMovement
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
        //=================================================PopulateModels===================================
    }
}
