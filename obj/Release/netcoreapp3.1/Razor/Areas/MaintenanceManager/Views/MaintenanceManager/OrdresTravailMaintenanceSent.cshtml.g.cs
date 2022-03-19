#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a7c04c46c1ce3567206d451bd4e3c3a461e88e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MaintenanceManager_Views_MaintenanceManager_OrdresTravailMaintenanceSent), @"mvc.1.0.view", @"/Areas/MaintenanceManager/Views/MaintenanceManager/OrdresTravailMaintenanceSent.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a7c04c46c1ce3567206d451bd4e3c3a461e88e2", @"/Areas/MaintenanceManager/Views/MaintenanceManager/OrdresTravailMaintenanceSent.cshtml")]
    public class Areas_MaintenanceManager_Views_MaintenanceManager_OrdresTravailMaintenanceSent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
  
    ViewData["Title"] = "Ordres Travail Maintenance Sent";
    Layout = "~/Views/Shared/_LayoutExploitationManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
Write(Html.DevExtreme().Toolbar()
    .Items(items =>
    {
        items.Add()
           .Widget(w => w
           .Button()
           .Icon("refresh")
           .OnClick("refreshButton_click")
       )
       .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
       .Location(ToolbarItemLocation.Before);

        items.Add()
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("dd/MM/yyyy").ID("FilterDateDebut"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);

        items.Add()
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("dd/MM/yyyy").ID("FilterDateFin"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);

        items.Add()
        .Widget(w => w.Button()
            .Icon("plus")
            .OnClick("addButton_click")

    )

    .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
    .Location(ToolbarItemLocation.Before);

    }
    )
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 47 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.OrdreTravail>()
        .DataSource(ds => ds.Mvc()
        .Controller("OrdresTravailMaintenance")
        .LoadAction("GetSent")
        .InsertAction("Post")
        .UpdateAction("Put")
        .DeleteAction("Delete")
        .Key("NumOt")
        .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
        )
        .RemoteOperations(true)
        .ID("demandesTravailGrid")
        .NoDataText("Aucune donnée à afficher")
        .CacheEnabled(true)
        .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
        .Columns(columns => {
            columns.AddFor(m => m.NumOt)
        .CellTemplate("<a class=\"btn btn-outline-success my-2 my-sm-0\"><%= value %></a>")
        .AllowEditing(false);
            columns.AddFor(m => m.NumDt).Lookup(lookup => lookup
          .DataSource(ds => ds.WebApi().Controller("OrdresTravailMaintenance").LoadAction("NumDtLookup").Key("Value"))
          .ValueExpr("Value")
          .DisplayExpr("Text")
          .AllowClearing(true)
          );

            columns.AddFor(m => m.DateOt)
        .Format("d/M/yyyy")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

            columns.AddFor(m => m.HeureInstallation).Format("dd/MM/yyyy HH:mm")
        .DataType(GridColumnDataType.DateTime)
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

            columns.AddFor(m => m.CodeMaintenance).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("OrdresTravailMaintenance").LoadAction("TypeMaintenanceLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );

        columns.AddFor(m => m.CodeMachine).Caption("Installation")
      .Lookup(lookup => lookup
       .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMaintenance").LoadAction("MachinesLookup").Key("Value"))
       .AllowClearing(true)
       .ValueExpr("Value")
       .DisplayExpr("Text")
      );
        columns.AddFor(m => m.NumEquipement).Caption("Equipement")
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMaintenance").LoadAction("EquipementsLookup").Key("Value"))
        .AllowClearing(true)
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );
        columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b => {
        b.Add().Name(GridColumnButtonName.Edit);
        b.Add().Name(GridColumnButtonName.Delete);
        b.Add()
            .Hint("Imprimer")
            .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerOrdreTravail");
    PopWriter();
}
))
                           .Icon("print");
            });


})
                .MasterDetail(md => md
        .Enabled(true)
        .Template(new TemplateName("RapportInterventionDetails"))
    )
   .Editing(editing =>
   {
       editing.AllowUpdating(true);
       editing.AllowDeleting(true);
       editing.AllowAdding(true);
       editing.Mode(GridEditMode.Popup)
        .Popup(p => p.Title("Editer Demande")
        .ShowTitle(true)
        .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
   })
   .Export(e => e.Enabled(true).AllowExportSelectedData(true))
   .FilterRow(f => f.Visible(true))
   .HeaderFilter(headerfilter => headerfilter.Visible(true))
   .GroupPanel(p => p.Visible(true))
   .AllowColumnReordering(true)
   .AllowColumnResizing(true)
   .OnCellPrepared("receptionCell_prepared")
   .Selection(s => s.Mode(SelectionMode.Multiple)
)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
#nullable restore
#line 143 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
 using (Html.DevExtreme().NamedTemplate("RapportInterventionDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 145 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Rapport Intervention")
                .Template(new TemplateName("RapportInterventionGrid"))
                .Option("masterGridData", new { id = new JS("data.NumOt") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 153 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
         
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 156 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
 using (Html.DevExtreme().NamedTemplate("RapportInterventionGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 158 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.RapportIntervention>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(false))
        .Columns(columns =>
        {
            columns.AddFor(m => m.NumOt).Lookup(lookup => lookup
              .DataSource(ds => ds.WebApi().Controller("OrdresTravailMaintenance").LoadAction("NumOtLookup").Key("Value"))
              .ValueExpr("Value")
              .DisplayExpr("Text")
              .AllowClearing(true)
              );
            columns.AddFor(m => m.DateIntervention).DataType(GridColumnDataType.DateTime);
            columns.AddFor(m => m.DebutIntervention).DataType(GridColumnDataType.DateTime);
            columns.AddFor(m => m.DureeIntervention);
            columns.AddFor(m => m.CompteRendu);
            columns.AddFor(m => m.Observation);
            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b =>
                {
                    b.Add().Name(GridColumnButtonName.Edit);
                    b.Add().Name(GridColumnButtonName.Delete);
                });
        })
         .DataSource(ds => ds.Mvc()
             .Controller("RapportInterventionsMaintenance")
             .LoadAction("Get")
             .InsertAction("Post")
             .UpdateAction("Put")
             .DeleteAction("Delete")
             .Key("NumIntervention")
             .LoadParams(new
             {
                 id = new JS("masterGridData.id")
             }
             )
            )
         .Editing(editing =>
         {
             editing.AllowUpdating(true);
             editing.AllowDeleting(true);
             editing.AllowAdding(true);
             editing.Mode(GridEditMode.Popup)
              .Popup(p => p.Title("Editer Demande")
              .ShowTitle(true)
              .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
         })

    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 207 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>

        function refreshButton_click() {
         DevExpress.ui.notify(""Rafraichissement en cours!"");
         var demandesTravailGrid = $(""#demandesTravailGrid"").dxDataGrid(""instance"");
         var demandesTravailDS = demandesTravailGrid.getDataSource();
         demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
         demandesTravailDS.reload();
         demandesTravailGrid.refresh();
         demandesTravailGrid.endCustomLoading();
        }

        function addButton_click() {
            DevExpress.ui.notify(""Ajouter une demande!"");
            window.location.href = '");
#nullable restore
#line 224 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
                               Write(Url.Action("NewReception"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
        }

        function dateDebutBox_value() {
            var dateDebutBox = $(""#FilterDateDebut"").dxDateBox(""instance"");
            console.log(dateDebutBox.option('value'));
            return new Date(dateDebutBox.option('value')).toJSON();
        }

        function dateFinBox_value() {
            var dateFinBox = $(""#FilterDateFin"").dxDateBox(""instance"");
            console.log(dateFinBox.option('value'));
            return new Date(dateFinBox.option('value')).toJSON();
        }

        function receptionCell_prepared(e) {
            if (e.rowType === ""data"" && e.column.command === ""edit"") {
                var isEditing = e.row.isEditing, $links = e.cellElement.find("".dx-link"");
                $links.text("""");
                if (isEditing) {
                    $links.filter("".dx-link-save"").addClass(""dx-icon-save"");
                    $links.filter("".dx-link-cancel"").addClass(""dx-icon-revert"");
                } else {
                    $links.filter("".dx-lin");
            WriteLiteral(@"k-edit"").addClass(""dx-icon-edit"");
                    $links.filter("".dx-link-delete"").addClass(""dx-icon-trash"");
                }
            }
        }

        var imprimerOrdreTravail = function (e) {
            var num = e.row.data.NumOt;

               window.location.href = ' ");
#nullable restore
#line 256 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MaintenanceManager\Views\MaintenanceManager\OrdresTravailMaintenanceSent.cshtml"
                                   Write(Url.Action("OrdreTravailViewer"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
         }

        var docViewer;
        function GetDocumentViewer(s, e) {
            docViewer = s;
        }

        function BuildOnClick() {
            var parameterValue = 2;
            docViewer.GetParametersModel()[""NumDt""](parameterValue);
            docViewer.StartBuild();
        }

        function GoToLastPage(s, e) {
            s.GoToPage(e.PageCount - 1);
        }

        function WebDocumentViewerInit(s, e) {
            var parametersModel = s.GetParametersModel();
            if (!parametersModel) { return; }
            var serializeParametersOriginal = parametersModel.serializeParameters;
            parametersModel.serializeParameters = function () {
                var serializedParameters = serializeParametersOriginal.apply(parametersModel);
                var reportParameter = serializedParameters.filter(function (p) { return p.Key === ""MyParameterName"" })[0];
                if (reportParameter) {
                    reportParameter.Value = ""my ");
            WriteLiteral("custom parameter value\";\r\n                }\r\n                return serializedParameters;\r\n            }\r\n        }\r\n\r\n\r\n\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
