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

    public class ConsignationController : Controller
    {
        private KBFsteelContext _context;
        public ConsignationController(KBFsteelContext context)
        {
            _context = context;
        }
        //=====================================Consignation / Master ==============================================
        //==========================================Gets==================================================
        [HttpGet]
        public async Task<IActionResult> GetMethodes(DataSourceLoadOptions loadOptions)
        {
            var Consignation = _context.Consignation.AsNoTracking()
                .Select(i => new {
                    i.Equipement,
                    i.ServiceUtilisateur,
                    i.NumConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Consignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetExploitation(DataSourceLoadOptions loadOptions)
        {
            var Consignation = _context.Consignation.AsNoTracking()
                .Where(o => o.ServiceUtilisateur == XpertHelper.CodeExploitation)
                .Select(i => new {
                    i.Equipement,
                    i.NumConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Consignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetUsinage(DataSourceLoadOptions loadOptions)
        {
            var Consignation = _context.Consignation.AsNoTracking()
                .Where(o => o.ServiceUtilisateur == XpertHelper.CodeUsinage)
                .Select(i => new {
                    i.Equipement,
                    i.NumConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Consignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetMecanique(DataSourceLoadOptions loadOptions)
        {
            var Consignation = _context.Consignation.AsNoTracking()
                .Where(o => o.ServiceUtilisateur == XpertHelper.CodeMecanqiue)
                .Select(i => new {
                    i.Equipement,
                    i.NumConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Consignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetElectrique(DataSourceLoadOptions loadOptions)
        {
            var Consignation = _context.Consignation.AsNoTracking()
                .Select(i => new {
                    i.Equipement,
                    i.ServiceUtilisateur,
                    i.NumConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Consignation, loadOptions));
        }
        //==========================================Posts==================================================
        [HttpPost]
        public async Task<IActionResult> PostUsinage(string values)
        {
            var model = new Consignation();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationUsinage(model, valuesDict);
            model.ServiceUtilisateur = XpertHelper.CodeUsinage;
            var result = _context.Consignation.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumConsignation);
        }
        [HttpPost]
        public async Task<IActionResult> PostMethodes(string values)
        {
            var model = new Consignation();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationMethodes(model, valuesDict);
            model.ServiceUtilisateur = XpertHelper.CodeMethode;
            var result = _context.Consignation.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumConsignation);
        }
        [HttpPost]
        public async Task<IActionResult> PostExploitation(string values)
        {
            var model = new Consignation();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationExploitation(model, valuesDict);
            model.ServiceUtilisateur = XpertHelper.CodeExploitation;
            var result = _context.Consignation.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumConsignation);
        }
        [HttpPost]
        public async Task<IActionResult> PostElectrique(string values)
        {
            var model = new Consignation();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationElectrique(model, valuesDict);
            model.ServiceUtilisateur = XpertHelper.CodeElectrique;
            var result = _context.Consignation.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumConsignation);
        }
        [HttpPost]
        public async Task<IActionResult> PostMecanique(string values)
        {
            var model = new Consignation();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationMecanique(model, valuesDict);
            model.ServiceUtilisateur = XpertHelper.CodeMecanqiue;
            var result = _context.Consignation.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumConsignation);
        }
        //==========================================Put==================================================
        [HttpPut]
        public async Task<IActionResult> PutUsinage(int key, string values)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationUsinage(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutMethodes(int key, string values)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationMethodes(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutExploitation(int key, string values)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationExploitation(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutElectrique(int key, string values)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationElectrique(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutMecanique(int key, string values)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationMecanique(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Delete===================================
        [HttpDelete]
        public async Task DeleteMethodes(int key)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            _context.Consignation.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteUsinage(int key)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            _context.Consignation.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteExploitation(int key)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            _context.Consignation.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteElectrique(int key)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            _context.Consignation.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteMecanique(int key)
        {
            var model = await _context.Consignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            _context.Consignation.Remove(model);
            await _context.SaveChangesAsync();
        }
        //==================================================================================================
        private void PopulateModelConsignationUsinage(Consignation model, IDictionary values)
        {
            string Equipement = nameof(Consignation.Equipement);
            string ServiceUtilisateur = nameof(Consignation.ServiceUtilisateur);
            if (values.Contains(Equipement))
            {
                model.Equipement = Convert.ToInt32(values[Equipement]);
            }
            if (values.Contains(ServiceUtilisateur))
            {
                model.ServiceUtilisateur = Convert.ToInt32(values[ServiceUtilisateur]);
            }
        }
        private void PopulateModelConsignationExploitation(Consignation model, IDictionary values)
        {
            string Equipement = nameof(Consignation.Equipement);
            if (values.Contains(Equipement))
            {
                model.Equipement = Convert.ToInt32(values[Equipement]);
            }
        }
        private void PopulateModelConsignationElectrique(Consignation model, IDictionary values)
        {
            string Equipement = nameof(Consignation.Equipement);
            string ServiceUtilisateur = nameof(Consignation.ServiceUtilisateur);
            if (values.Contains(Equipement))
            {
                model.Equipement = Convert.ToInt32(values[Equipement]);
            }
            if (values.Contains(ServiceUtilisateur))
            {
                model.ServiceUtilisateur = Convert.ToInt32(values[ServiceUtilisateur]);
            }
        }
        private void PopulateModelConsignationMethodes(Consignation model, IDictionary values)
        {
            string Equipement = nameof(Consignation.Equipement);
            string ServiceUtilisateur = nameof(Consignation.ServiceUtilisateur);
            if (values.Contains(Equipement))
            {
                model.Equipement = Convert.ToInt32(values[Equipement]);
            }
            if (values.Contains(ServiceUtilisateur))
            {
                model.ServiceUtilisateur = Convert.ToInt32(values[ServiceUtilisateur]);
            }
        }
        private void PopulateModelConsignationMecanique(Consignation model, IDictionary values)
        {
            string Equipement = nameof(Consignation.Equipement);
            string ServiceUtilisateur = nameof(Consignation.ServiceUtilisateur);
            if (values.Contains(Equipement))
            {
                model.Equipement = Convert.ToInt32(values[Equipement]);
            }
            if (values.Contains(ServiceUtilisateur))
            {
                model.ServiceUtilisateur = Convert.ToInt32(values[ServiceUtilisateur]);
            }
        }
        //=====================================Consignation / Details =============================================       
        //==========================================Gets==================================================
        [HttpGet]
        public async Task<IActionResult> GetDetailsMethodes(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationMethodes = id;
            var ConsignationDetails = _context.ConsignationDetails.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.AutresOperation,
                    i.Condamnation,
                    i.DateChangementChargeTravaux,
                    i.DateChargeConsignation,
                    i.DateChargeTravaux,
                    i.Id,
                    i.IdChangementChargeTravaux,
                    i.IdChargeConsignation,
                    i.IdChargeTravaux,
                    i.Identification,
                    i.MesureSecurite,
                    i.NumConsignation,
                    i.Separation,
                    i.Signalsiation,
                    i.Verification
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(ConsignationDetails, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetailsExploitation(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationExploitation = id;
            var ConsignationDetails = _context.ConsignationDetails.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.AutresOperation,
                    i.Condamnation,
                    i.DateChangementChargeTravaux,
                    i.DateChargeConsignation,
                    i.DateChargeTravaux,
                    i.Id,
                    i.IdChangementChargeTravaux,
                    i.IdChargeConsignation,
                    i.IdChargeTravaux,
                    i.Identification,
                    i.MesureSecurite,
                    i.NumConsignation,
                    i.Separation,
                    i.Signalsiation,
                    i.Verification
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(ConsignationDetails, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetailsUsinage(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationUsinage = id;
            var ConsignationDetails = _context.ConsignationDetails.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.AutresOperation,
                    i.Condamnation,
                    i.DateChangementChargeTravaux,
                    i.DateChargeConsignation,
                    i.DateChargeTravaux,
                    i.Id,
                    i.IdChangementChargeTravaux,
                    i.IdChargeConsignation,
                    i.IdChargeTravaux,
                    i.Identification,
                    i.MesureSecurite,
                    i.NumConsignation,
                    i.Separation,
                    i.Signalsiation,
                    i.Verification
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(ConsignationDetails, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetailsMecanique(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationMecanique = id;
            var ConsignationDetails = _context.ConsignationDetails.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.AutresOperation,
                    i.Condamnation,
                    i.DateChangementChargeTravaux,
                    i.DateChargeConsignation,
                    i.DateChargeTravaux,
                    i.Id,
                    i.IdChangementChargeTravaux,
                    i.IdChargeConsignation,
                    i.IdChargeTravaux,
                    i.Identification,
                    i.MesureSecurite,
                    i.NumConsignation,
                    i.Separation,
                    i.Signalsiation,
                    i.Verification
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(ConsignationDetails, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetailsElectrique(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationElectrique = id;
            var ConsignationDetails = _context.ConsignationDetails.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.AutresOperation,
                    i.Condamnation,
                    i.DateChangementChargeTravaux,
                    i.DateChargeConsignation,
                    i.DateChargeTravaux,
                    i.Id,
                    i.IdChangementChargeTravaux,
                    i.IdChargeConsignation,
                    i.IdChargeTravaux,
                    i.Identification,
                    i.MesureSecurite,
                    i.NumConsignation,
                    i.Separation,
                    i.Signalsiation,
                    i.Verification
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(ConsignationDetails, loadOptions));
        }
        //==========================================Posts==================================================
        [HttpPost]
        public async Task<IActionResult> PostDetailsUsinage(string values)
        {
            var model = new ConsignationDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsUsinage(model, valuesDict);
            model.NumConsignation = XpertHelper.ConsignationUsinage;
            model.DateChargeConsignation = DateTime.Now.Date;
            var result = _context.ConsignationDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetailsMethodes(string values)
        {
            var model = new ConsignationDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsMethodes(model, valuesDict);
            model.NumConsignation = XpertHelper.ConsignationMethodes;
            model.DateChargeConsignation = DateTime.Now.Date;
            var result = _context.ConsignationDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetailsExploitation(string values)
        {
            var model = new ConsignationDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsExploitation(model, valuesDict);
            model.NumConsignation = XpertHelper.ConsignationExploitation;
            model.DateChargeConsignation = DateTime.Now.Date;
            var result = _context.ConsignationDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetailsElectrique(string values)
        {
            var model = new ConsignationDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsElectrique(model, valuesDict);
            model.NumConsignation = XpertHelper.ConsignationElectrique;
            var result = _context.ConsignationDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetailsMecanique(string values)
        {
            var model = new ConsignationDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsMecanique(model, valuesDict);
            model.NumConsignation = XpertHelper.ConsignationMecanique;
            model.DateChargeConsignation = DateTime.Now.Date;
            var result = _context.ConsignationDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        //==========================================Put==================================================
        [HttpPut]
        public async Task<IActionResult> PutDetailsUsinage(int key, string values)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsUsinage(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetailsMethodes(int key, string values)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsMethodes(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetailsExploitation(int key, string values)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsExploitation(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetailsElectrique(int key, string values)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsElectrique(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetailsMecanique(int key, string values)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelConsignationDetailsMecanique(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Delete===================================
        [HttpDelete]
        public async Task DeleteDetailsMethodes(int key)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            _context.ConsignationDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetailsUsinage(int key)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            _context.ConsignationDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetailsExploitation(int key)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            _context.ConsignationDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetailsElectrique(int key)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            _context.ConsignationDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetailsMecanique(int key)
        {
            var model = await _context.ConsignationDetails.FirstOrDefaultAsync(item => item.Id == key);
            _context.ConsignationDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        //==================================================================================================
        private void PopulateModelConsignationDetailsUsinage(ConsignationDetails model, IDictionary values)
        {
            string Separation = nameof(ConsignationDetails.Separation);
            string Condamnation = nameof(ConsignationDetails.Condamnation);
            string Identification = nameof(ConsignationDetails.Identification);
            string Verification = nameof(ConsignationDetails.Verification);
            string AutresOperation = nameof(ConsignationDetails.AutresOperation);
            string MesureSecurite = nameof(ConsignationDetails.MesureSecurite);

            string IdChargeConsignation = nameof(ConsignationDetails.IdChargeConsignation);
            string DateChargeConsignation = nameof(ConsignationDetails.DateChargeConsignation);
            string IdChargeTravaux = nameof(ConsignationDetails.IdChargeTravaux);
            string DateChargeTravaux = nameof(ConsignationDetails.DateChargeTravaux);
            string IdChangementChargeTravaux = nameof(ConsignationDetails.IdChangementChargeTravaux);
            string DateChangementChargeTravaux = nameof(ConsignationDetails.DateChangementChargeTravaux);
            if (values.Contains(Separation))
            {
                model.Separation = Convert.ToBoolean(values[Separation]);
            }
            if (values.Contains(Condamnation))
            {
                model.Condamnation = Convert.ToBoolean(values[Condamnation]);
            }
            if (values.Contains(Identification))
            {
                model.Identification = Convert.ToBoolean(values[Identification]);
            }
            if (values.Contains(Verification))
            {
                model.Verification = Convert.ToBoolean(values[Verification]);
            }
            if (values.Contains(AutresOperation))
            {
                model.AutresOperation = Convert.ToString(values[AutresOperation]);
            }
            if (values.Contains(MesureSecurite))
            {
                model.MesureSecurite = Convert.ToString(values[MesureSecurite]);
            }
            if (values.Contains(DateChargeConsignation))
            {
                model.DateChargeConsignation = Convert.ToDateTime(values[DateChargeConsignation]);
            }
            if (values.Contains(DateChargeTravaux))
            {
                model.DateChargeTravaux = Convert.ToDateTime(values[DateChargeTravaux]);
            }
            if (values.Contains(DateChangementChargeTravaux))
            {
                model.DateChangementChargeTravaux = Convert.ToDateTime(values[DateChangementChargeTravaux]);
            }
            if (values.Contains(IdChargeConsignation))
            {
                var CodePdrvar = values[IdChargeConsignation];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeConsignation = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChargeTravaux))
            {
                var CodePdrvar = values[IdChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChangementChargeTravaux))
            {
                var CodePdrvar = values[IdChangementChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChangementChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
        }
        private void PopulateModelConsignationDetailsMethodes(ConsignationDetails model, IDictionary values)
        {
            string Separation = nameof(ConsignationDetails.Separation);
            string Condamnation = nameof(ConsignationDetails.Condamnation);
            string Identification = nameof(ConsignationDetails.Identification);
            string Verification = nameof(ConsignationDetails.Verification);
            string AutresOperation = nameof(ConsignationDetails.AutresOperation);
            string MesureSecurite = nameof(ConsignationDetails.MesureSecurite);

            string IdChargeConsignation = nameof(ConsignationDetails.IdChargeConsignation);
            string DateChargeConsignation = nameof(ConsignationDetails.DateChargeConsignation);
            string IdChargeTravaux = nameof(ConsignationDetails.IdChargeTravaux);
            string DateChargeTravaux = nameof(ConsignationDetails.DateChargeTravaux);
            string IdChangementChargeTravaux = nameof(ConsignationDetails.IdChangementChargeTravaux);
            string DateChangementChargeTravaux = nameof(ConsignationDetails.DateChangementChargeTravaux);
            if (values.Contains(Separation))
            {
                model.Separation = Convert.ToBoolean(values[Separation]);
            }
            if (values.Contains(Condamnation))
            {
                model.Condamnation = Convert.ToBoolean(values[Condamnation]);
            }
            if (values.Contains(Identification))
            {
                model.Identification = Convert.ToBoolean(values[Identification]);
            }
            if (values.Contains(Verification))
            {
                model.Verification = Convert.ToBoolean(values[Verification]);
            }
            if (values.Contains(AutresOperation))
            {
                model.AutresOperation = Convert.ToString(values[AutresOperation]);
            }
            if (values.Contains(MesureSecurite))
            {
                model.MesureSecurite = Convert.ToString(values[MesureSecurite]);
            }
            if (values.Contains(DateChargeConsignation))
            {
                model.DateChargeConsignation = Convert.ToDateTime(values[DateChargeConsignation]);
            }
            if (values.Contains(DateChargeTravaux))
            {
                model.DateChargeTravaux = Convert.ToDateTime(values[DateChargeTravaux]);
            }
            if (values.Contains(DateChangementChargeTravaux))
            {
                model.DateChangementChargeTravaux = Convert.ToDateTime(values[DateChangementChargeTravaux]);
            }
            if (values.Contains(IdChargeConsignation))
            {
                var CodePdrvar = values[IdChargeConsignation];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeConsignation = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChargeTravaux))
            {
                var CodePdrvar = values[IdChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChangementChargeTravaux))
            {
                var CodePdrvar = values[IdChangementChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChangementChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
        }
        private void PopulateModelConsignationDetailsElectrique(ConsignationDetails model, IDictionary values)
        {
            string Separation = nameof(ConsignationDetails.Separation);
            string Condamnation = nameof(ConsignationDetails.Condamnation);
            string Identification = nameof(ConsignationDetails.Identification);
            string Verification = nameof(ConsignationDetails.Verification);
            string AutresOperation = nameof(ConsignationDetails.AutresOperation);
            string MesureSecurite = nameof(ConsignationDetails.MesureSecurite);

            string IdChargeConsignation = nameof(ConsignationDetails.IdChargeConsignation);
            string DateChargeConsignation = nameof(ConsignationDetails.DateChargeConsignation);
            string IdChargeTravaux = nameof(ConsignationDetails.IdChargeTravaux);
            string DateChargeTravaux = nameof(ConsignationDetails.DateChargeTravaux);
            string IdChangementChargeTravaux = nameof(ConsignationDetails.IdChangementChargeTravaux);
            string DateChangementChargeTravaux = nameof(ConsignationDetails.DateChangementChargeTravaux);
            if (values.Contains(Separation))
            {
                model.Separation = Convert.ToBoolean(values[Separation]);
            }
            if (values.Contains(Condamnation))
            {
                model.Condamnation = Convert.ToBoolean(values[Condamnation]);
            }
            if (values.Contains(Identification))
            {
                model.Identification = Convert.ToBoolean(values[Identification]);
            }
            if (values.Contains(Verification))
            {
                model.Verification = Convert.ToBoolean(values[Verification]);
            }
            if (values.Contains(AutresOperation))
            {
                model.AutresOperation = Convert.ToString(values[AutresOperation]);
            }
            if (values.Contains(MesureSecurite))
            {
                model.MesureSecurite = Convert.ToString(values[MesureSecurite]);
            }
            if (values.Contains(DateChargeConsignation))
            {
                model.DateChargeConsignation = Convert.ToDateTime(values[DateChargeConsignation]);
            }
            if (values.Contains(DateChargeTravaux))
            {
                model.DateChargeTravaux = Convert.ToDateTime(values[DateChargeTravaux]);
            }
            if (values.Contains(DateChangementChargeTravaux))
            {
                model.DateChangementChargeTravaux = Convert.ToDateTime(values[DateChangementChargeTravaux]);
            }
            if (values.Contains(IdChargeConsignation))
            {
                var CodePdrvar = values[IdChargeConsignation];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeConsignation = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChargeTravaux))
            {
                var CodePdrvar = values[IdChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChangementChargeTravaux))
            {
                var CodePdrvar = values[IdChangementChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChangementChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
        }
        private void PopulateModelConsignationDetailsExploitation(ConsignationDetails model, IDictionary values)
        {
            string Separation = nameof(ConsignationDetails.Separation);
            string Condamnation = nameof(ConsignationDetails.Condamnation);
            string Identification = nameof(ConsignationDetails.Identification);
            string Verification = nameof(ConsignationDetails.Verification);
            string AutresOperation = nameof(ConsignationDetails.AutresOperation);
            string MesureSecurite = nameof(ConsignationDetails.MesureSecurite);

            string IdChargeConsignation = nameof(ConsignationDetails.IdChargeConsignation);
            string DateChargeConsignation = nameof(ConsignationDetails.DateChargeConsignation);
            string IdChargeTravaux = nameof(ConsignationDetails.IdChargeTravaux);
            string DateChargeTravaux = nameof(ConsignationDetails.DateChargeTravaux);
            string IdChangementChargeTravaux = nameof(ConsignationDetails.IdChangementChargeTravaux);
            string DateChangementChargeTravaux = nameof(ConsignationDetails.DateChangementChargeTravaux);
            if (values.Contains(Separation))
            {
                model.Separation = Convert.ToBoolean(values[Separation]);
            }
            if (values.Contains(Condamnation))
            {
                model.Condamnation = Convert.ToBoolean(values[Condamnation]);
            }
            if (values.Contains(Identification))
            {
                model.Identification = Convert.ToBoolean(values[Identification]);
            }
            if (values.Contains(Verification))
            {
                model.Verification = Convert.ToBoolean(values[Verification]);
            }
            if (values.Contains(AutresOperation))
            {
                model.AutresOperation = Convert.ToString(values[AutresOperation]);
            }
            if (values.Contains(MesureSecurite))
            {
                model.MesureSecurite = Convert.ToString(values[MesureSecurite]);
            }
            if (values.Contains(DateChargeConsignation))
            {
                model.DateChargeConsignation = Convert.ToDateTime(values[DateChargeConsignation]);
            }
            if (values.Contains(DateChargeTravaux))
            {
                model.DateChargeTravaux = Convert.ToDateTime(values[DateChargeTravaux]);
            }
            if (values.Contains(DateChangementChargeTravaux))
            {
                model.DateChangementChargeTravaux = Convert.ToDateTime(values[DateChangementChargeTravaux]);
            }
            if (values.Contains(IdChargeConsignation))
            {
                var CodePdrvar = values[IdChargeConsignation];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeConsignation = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChargeTravaux))
            {
                var CodePdrvar = values[IdChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChangementChargeTravaux))
            {
                var CodePdrvar = values[IdChangementChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChangementChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
        }
        private void PopulateModelConsignationDetailsMecanique(ConsignationDetails model, IDictionary values)
        {
            string Separation = nameof(ConsignationDetails.Separation);
            string Condamnation = nameof(ConsignationDetails.Condamnation);
            string Identification = nameof(ConsignationDetails.Identification);
            string Verification = nameof(ConsignationDetails.Verification);
            string AutresOperation = nameof(ConsignationDetails.AutresOperation);
            string MesureSecurite = nameof(ConsignationDetails.MesureSecurite);

            string IdChargeConsignation = nameof(ConsignationDetails.IdChargeConsignation);
            string DateChargeConsignation = nameof(ConsignationDetails.DateChargeConsignation);
            string IdChargeTravaux = nameof(ConsignationDetails.IdChargeTravaux);
            string DateChargeTravaux = nameof(ConsignationDetails.DateChargeTravaux);
            string IdChangementChargeTravaux = nameof(ConsignationDetails.IdChangementChargeTravaux);
            string DateChangementChargeTravaux = nameof(ConsignationDetails.DateChangementChargeTravaux);
            if (values.Contains(Separation))
            {
                model.Separation = Convert.ToBoolean(values[Separation]);
            }
            if (values.Contains(Condamnation))
            {
                model.Condamnation = Convert.ToBoolean(values[Condamnation]);
            }
            if (values.Contains(Identification))
            {
                model.Identification = Convert.ToBoolean(values[Identification]);
            }
            if (values.Contains(Verification))
            {
                model.Verification = Convert.ToBoolean(values[Verification]);
            }
            if (values.Contains(AutresOperation))
            {
                model.AutresOperation = Convert.ToString(values[AutresOperation]);
            }
            if (values.Contains(MesureSecurite))
            {
                model.MesureSecurite = Convert.ToString(values[MesureSecurite]);
            }
            if (values.Contains(DateChargeConsignation))
            {
                model.DateChargeConsignation = Convert.ToDateTime(values[DateChargeConsignation]);
            }
            if (values.Contains(DateChargeTravaux))
            {
                model.DateChargeTravaux = Convert.ToDateTime(values[DateChargeTravaux]);
            }
            if (values.Contains(DateChangementChargeTravaux))
            {
                model.DateChangementChargeTravaux = Convert.ToDateTime(values[DateChangementChargeTravaux]);
            }
            if (values.Contains(IdChargeConsignation))
            {
                var CodePdrvar = values[IdChargeConsignation];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeConsignation = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChargeTravaux))
            {
                var CodePdrvar = values[IdChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdChangementChargeTravaux))
            {
                var CodePdrvar = values[IdChangementChargeTravaux];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdChangementChargeTravaux = Convert.ToInt32(CodePdrSplited);
            }
        }
        //=====================================Consignation / Deconsignation =========================================
        //==========================================Gets==================================================
        [HttpGet]
        public async Task<IActionResult> GetMethodesDeconsignation(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationMethodes = id;
            var Deconsignation = _context.Deconsignation.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.DateBonDeconsgination,
                    i.DateDemandeDeconsignation,
                    i.Id,
                    i.IdBonDéconsignation,
                    i.IdDemandeDeConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Deconsignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetExploitationDeconsignation(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationExploitation = id;
            var Deconsignation = _context.Deconsignation.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.DateBonDeconsgination,
                    i.DateDemandeDeconsignation,
                    i.Id,
                    i.IdBonDéconsignation,
                    i.IdDemandeDeConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Deconsignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetUsinageDeconsignation(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationUsinage = id;
            var Deconsignation = _context.Deconsignation.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.DateBonDeconsgination,
                    i.DateDemandeDeconsignation,
                    i.Id,
                    i.IdBonDéconsignation,
                    i.IdDemandeDeConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Deconsignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetMecaniqueDeconsignation(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationMecanique = id;
            var Deconsignation = _context.Deconsignation.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.DateBonDeconsgination,
                    i.DateDemandeDeconsignation,
                    i.Id,
                    i.IdBonDéconsignation,
                    i.IdDemandeDeConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Deconsignation, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetElectriqueDeconsignation(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.ConsignationElectrique = id;
            var Deconsignation = _context.Deconsignation.AsNoTracking()
                .Where(o => o.NumConsignation == id)
                .Select(i => new {
                    i.DateBonDeconsgination,
                    i.DateDemandeDeconsignation,
                    i.Id,
                    i.IdBonDéconsignation,
                    i.IdDemandeDeConsignation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(Deconsignation, loadOptions));
        }
        //==========================================Posts==================================================
        public async Task<IActionResult> PostDeconsingationElectrique(string values)
        {
            var model = new Deconsignation();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDeconsingationElectrique(model, valuesDict);
            model.NumConsignation = XpertHelper.ConsignationElectrique;
            var result = _context.Deconsignation.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumConsignation);
        }
        //==========================================Put====================================================
        [HttpPut]
        public async Task<IActionResult> PutDeconsingationElectrique(int key, string values)
        {
            var model = await _context.Deconsignation.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDeconsingationElectrique(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Delete=========================================
        [HttpDelete]
        public async Task DeleteDeconsingationElectrique(int key)
        {
            var model = await _context.Deconsignation.FirstOrDefaultAsync(item => item.NumConsignation == key);
            _context.Deconsignation.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================LookUps========================================
        [HttpGet]
        public async Task<IActionResult> EmployeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================================================================
        private void PopulateModelDeconsingationElectrique(Deconsignation model, IDictionary values)
        {
            string DateBonDeconsgination = nameof(Deconsignation.DateBonDeconsgination);
            string DateDemandeDeconsignation = nameof(Deconsignation.DateDemandeDeconsignation);
            string IdBonDéconsignation = nameof(Deconsignation.IdBonDéconsignation);
            string IdDemandeDeConsignation = nameof(Deconsignation.IdDemandeDeConsignation);
            if (values.Contains(DateBonDeconsgination))
            {
                model.DateBonDeconsgination = Convert.ToDateTime(values[DateBonDeconsgination]);
            }
            if (values.Contains(DateDemandeDeconsignation))
            {
                model.DateDemandeDeconsignation = Convert.ToDateTime(values[DateDemandeDeconsignation]);
            }
            if (values.Contains(IdBonDéconsignation))
            {
                var CodePdrvar = values[IdBonDéconsignation];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdBonDéconsignation = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(IdDemandeDeConsignation))
            {
                var CodePdrvar = values[IdDemandeDeConsignation];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.IdDemandeDeConsignation = Convert.ToInt32(CodePdrSplited);
            }
        }
    }
}