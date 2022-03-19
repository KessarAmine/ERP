#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e4bf69b0e385dc4829dadb9c5878a5b4a8f038f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UsinageManager_Views_UsinageManager_SuiviTraveaux), @"mvc.1.0.view", @"/Areas/UsinageManager/Views/UsinageManager/SuiviTraveaux.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e4bf69b0e385dc4829dadb9c5878a5b4a8f038f", @"/Areas/UsinageManager/Views/UsinageManager/SuiviTraveaux.cshtml")]
    public class Areas_UsinageManager_Views_UsinageManager_SuiviTraveaux : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
  
    ViewData["Title"] = "Usinage-Suivi des travaux";
    Layout = "~/Views/Shared/_LayoutUsinageManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
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
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("yyyy-MM-dd").ID("FilterDateDebut"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);

        items.Add()
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("yyyy-MM-dd").ID("FilterDateFin"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);

        items.Add()
        .Widget(w => w.Button()
            .Icon("fas fa-clipboard-list")
            .OnClick("FicheSuiviActiviteMecanique_click")
            .Hint("Fiche de suivi des activitées mécanique")
    )

    .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
    .Location(ToolbarItemLocation.Before);

    items.Add()
        .Widget(w => w.Button()
            .Icon("fas fa-calendar-check")
            .OnClick("RapportMensuelDTOT_click")
            .Hint("Rapport Mensuelle DT OT")
    )

    .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
    .Location(ToolbarItemLocation.Before);

    items.Add()
        .Widget(w => w.Button()
            .Icon("fas fa-industry")
            .OnClick("RapportObjectifsQualiteViewerMecanique_click")
            .Hint("Objectif Qualité maintenance")
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
#line 68 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.AssOtTraveaux>()
 .DataSource(ds => ds.Mvc()
     .Controller("AssOtTraveaux")
     .LoadAction("GetSuivi")
     .Key("Id")
     .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value"), Structure =XpertHelper.CodeUsinage })
 )
 .Height("95%")
 .RemoteOperations(true)
 .ID("demandesTravailGrid")
.Scrolling(scrolling => scrolling
.ScrollByContent(true)
.ShowScrollbar(ShowScrollbarMode.Always)
.Mode(GridScrollingMode.Virtual))
 .NoDataText("Aucune donnée à afficher")
 .CacheEnabled(true)
.ColumnChooser(cc => cc.Enabled(true).AllowSearch(true))
 .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
 .Columns(columns => {
     columns.AddFor(m => m.TypeTraveaux)
     .Lookup(lookup => lookup
     .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("TypeTraveauxLookup").Key("Value"))
     .AllowClearing(true)
     .ValueExpr("Value")
     .DisplayExpr("Text"));
     columns.AddFor(m => m.Qte);
     columns.AddFor(m => m.CodeMachine).Caption("Machine")
     .Lookup(lookup => lookup
     .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("MachinesLookup").Key("Value"))
     .AllowClearing(true)
     .ValueExpr("Value")
     .DisplayExpr("Text"));
     columns.AddFor(m => m.CodeEquipement).Caption("Equipement")
     .Lookup(lookup => lookup
     .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("EquipementsLookup").Key("Value"))
     .AllowClearing(true)
     .ValueExpr("Value")
     .DisplayExpr("Text"));
     columns.AddFor(m => m.Autres);
     columns.AddFor(m => m.NumOt).Caption("Date Intervention").Lookup(lookup => lookup
     .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("DateInterventionLookup").Key("Value"))
     .AllowClearing(true)
     .ValueExpr("Value")
     .DisplayExpr("Text"))
     .Format("d/M/yyyy")
     .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.AddFor(m => m.NumOt).Caption("Durée Intervention")
     .Lookup(lookup => lookup
     .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("DureeInterventionLookup").Key("Value"))
     .AllowClearing(true)
     .ValueExpr("Value")
     .DisplayExpr("Text"));
 })
   .Export(e => e.Enabled(true).AllowExportSelectedData(true))
   .FilterRow(f => f.Visible(true))
   .HeaderFilter(headerfilter => headerfilter.Visible(true))
   .GroupPanel(p => p.Visible(true))
   .AllowColumnReordering(true)
   .AllowColumnResizing(true)
   .OnCellPrepared("receptionCell_prepared")
   .Selection(s => s.Mode(SelectionMode.Multiple))
);

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

    function FicheSuiviActiviteMecanique_click() {
        //GetDateDebut GetDateFin
        var ServiceCurrent = ""Usinage""
        var Datedebut = $(""#FilterDateDebut"").dxDateBox(""instance"").option(""text"");
        var Datefin = $(""#FilterDateFin"").dxDateBox(""instance"").option(""text"");
        window.open(' ");
#nullable restore
#line 148 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
                 Write(Url.Action("ActiviteUsinageViewer", "UsinageManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?ServiceCurrent=' + ServiceCurrent + '&Datedebut=' + Datedebut + '&Datefin=' + Datefin,
            '_blank').focus();
    }
    function RapportMensuelDTOT_click() {
        //GetDateDebut GetDateFin
        var Datedebut = $(""#FilterDateDebut"").dxDateBox(""instance"").option(""text"");
        var Datefin = $(""#FilterDateFin"").dxDateBox(""instance"").option(""text"");
        window.open(' ");
#nullable restore
#line 155 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
                 Write(Url.Action("RapportMensuelViewerUsinage", "UsinageManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?Datedebut=' + Datedebut + '&Datefin=' + Datefin,
            '_blank').focus();
    }
    function RapportObjectifsQualiteViewerMecanique_click() {
        //GetDateDebut GetDateFin
        var Datedebut = $(""#FilterDateDebut"").dxDateBox(""instance"").option(""text"");
        var Datefin = $(""#FilterDateFin"").dxDateBox(""instance"").option(""text"");
        window.open( ' ");
#nullable restore
#line 162 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\SuiviTraveaux.cshtml"
                  Write(Url.Action("ObjectifsQualiteViewerUsinage", "UsinageManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?Datedebut=' + Datedebut + '&Datefin=' + Datefin,
            '_blank').focus();
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
                $links.filter("".dx-link-e");
            WriteLiteral("dit\").addClass(\"dx-icon-edit\");\r\n                $links.filter(\".dx-link-delete\").addClass(\"dx-icon-trash\");\r\n            }\r\n        }\r\n        }\r\n\r\n</script>");
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