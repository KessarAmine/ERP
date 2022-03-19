#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddbaa34c0057eac2aaa19ece1022adbf0151ea0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinSuperviseur_Views_MagasinSuperviseur_Movements), @"mvc.1.0.view", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/Movements.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevKbfSteel.Areas.MagasinManager.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
using DevKbfSteel.Areas.MagasinSuperviseur.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddbaa34c0057eac2aaa19ece1022adbf0151ea0c", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/Movements.cshtml")]
    public class Areas_MagasinSuperviseur_Views_MagasinSuperviseur_Movements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
  
    ViewData["Title"] = "Magasin-Movements";
    Layout = "~/Views/Shared/_LayoutMagasinSuperviseur.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
Write(Html.DevExtreme().Toolbar()
    .Items(items =>
    {
        items.Add()
           .Widget(w => w
           .Button()
           .Icon("refresh")
           .OnClick("refreshButton_click"))
       .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
       .Location(ToolbarItemLocation.Before);
        items.Add()
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("dd-MM-yyyy").ID("FilterDateDebut"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);
        items.Add()
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("dd-MM-yyyy").ID("FilterDateFin"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);
        items.Add()
           .Widget(w => w
           .Button()
           .Hint("Suivi E/S")
           .Icon("print")
           .OnClick("imprimerSuivi"))
           .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
           .Location(ToolbarItemLocation.Before);
        items.Add()
           .Widget(w => w
           .Button()
           .Hint("Suivi Movements")
           .Icon("print")
           .OnClick("imprimerSuiviMovements"))
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
#line 53 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
Write(Html.DevExtreme().DataGrid<SuiviMovementsModel>()
.ID("IdMovement")
.DataSource(ds => ds.Mvc()
.Controller("Movements")
.LoadAction("GetSuiviMovements")
.LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
.Key("IdMovement"))
.RemoteOperations(true)
.NoDataText("Aucune donnée à afficher")
.CacheEnabled(true)
.SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
.Columns(columns => {
    columns.AddFor(m => m.NumBon);
    columns.AddFor(m => m.DateMovment)
    .Format("dd-MM-yyyy")
    .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
    columns.AddFor(m => m.TypeMovement)
    .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("Movements").LoadAction("TypeMovementLookup").Key("Value"))
    .ValueExpr("Value")
    .DisplayExpr("Text")
    .AllowClearing(true));
    columns.AddFor(m => m.CodePdr);
    columns.AddFor(m => m.CodePdr).Caption("Article")
    .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("Movements").LoadAction("DesignationPdrLookup").Key("Value"))
    .ValueExpr("Value")
    .DisplayExpr("Text")
    .AllowClearing(true));
    columns.AddFor(m => m.Gisement);
    columns.AddFor(m => m.ArticleNonGere);
    columns.AddFor(m => m.UniteMesure);
    columns.AddFor(m => m.Qte);
    columns.AddFor(m => m.PrixUnitaire);
    columns.AddFor(m => m.Montant);
    columns.AddFor(m => m.StockTotalSythese);
    columns.AddFor(m => m.ValeurStockTotal);
    columns.AddFor(m => m.ValeurValorisation);
    columns.AddFor(m => m.TypeValorisation)
    .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("Movements").LoadAction("TypeValorisationLookup").Key("Value"))
    .ValueExpr("Value")
    .DisplayExpr("Text")
    .AllowClearing(true));
})
.OnRowExpanding("CollpaseAll")
.OnRowExpanded("refreshButton_click")
.Scrolling(s => s.Mode(GridScrollingMode.Infinite))
.ColumnChooser(cc => cc
.Enabled(true)
.AllowSearch(true))
.Height("95%")
.Export(e => e.Enabled(true).AllowExportSelectedData(true))
.FilterRow(f => f.Visible(true))
.HeaderFilter(headerfilter => headerfilter.Visible(true))
.GroupPanel(p => p.Visible(true))
.AllowColumnReordering(true)
.AllowColumnResizing(true)
.OnCellPrepared("receptionCell_prepared")
.Selection(s => s.Mode(SelectionMode.Multiple))
.Editing(editing =>
{
    editing.AllowUpdating(false);
    editing.AllowDeleting(false);
    editing.AllowAdding(false);
    editing.Mode(GridEditMode.Form);
})
);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function gridBoxIdEmployee_valueChanged(e) {
        var $dataGrid = $(""#embedded-datagridMultipleIdEmployee"");
        if ($dataGrid.length) {
            var dataGrid = $dataGrid.dxDataGrid(""instance"");
            dataGrid.selectRows(e.value, false);
        }
    }
    function gridBox_valueChanged(args, setValueMethod) {
        var $dataGrid = $(""#embedded-datagridMultipleIdEmployee"");

        if ($dataGrid.length) {
            var dataGrid = $dataGrid.dxDataGrid(""instance"");
            dataGrid.selectRows(args.value, false);
        }
        setValueMethod(args.value);
    }
    function onSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option(""value"", keys);
        console.log(dropDownBoxInstance);
    }
    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#IdMovement"").dxDataGrid(""instance"");
        var demandesTrav");
            WriteLiteral(@"ailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();
        demandesTravailGrid.endCustomLoading();
    }
    function dateDebutBox_value() {
        var dateDebutBox = $(""#FilterDateDebut"").dxDateBox(""instance"");
        console.log(dateDebutBox.option('value'));
        return new Date(dateDebutBox.option('value')).toJSON();
    }
    function CollpaseAll(e) {
        e.component.collapseAll(-1);
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
       ");
            WriteLiteral(@"     if (isEditing) {
                $links.filter("".dx-link-save"").addClass(""dx-icon-save"");
                $links.filter("".dx-link-cancel"").addClass(""dx-icon-revert"");
            } else {
                $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
                $links.filter("".dx-link-delete"").addClass(""dx-icon-trash"");
            }
        }
    }
    var imprimerBoneSortie = function (e) {
        var num = e.row.data.NumBonSortie;
        window.open(' ");
#nullable restore
#line 181 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
                 Write(Url.Action("BonSortieViewer", "MagasinManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?id='+num, '_blank').focus();
        }
    function gridBox_valueChanged(args, setValueMethod) {
        var $dataGrid = $(""#embedded-datagridMultipleIdEmployee"");
        if ($dataGrid.length) {
            var dataGrid = $dataGrid.dxDataGrid(""instance"");
            dataGrid.selectRows(args.value, false);
        }
        setValueMethod(args.value);
    }
    function onSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option(""value"", keys);
    }
    var imprimerSuivi = function (e) {
        window.open(' ");
#nullable restore
#line 196 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
                 Write(Url.Action("SuiviESViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'_blank\').focus();\r\n    }\r\n    var imprimerSuiviMovements = function (e) {\r\n        window.open(\' ");
#nullable restore
#line 199 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Movements.cshtml"
                 Write(Url.Action("SuiviMovementViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'_blank\').focus();\r\n    }\r\n    function onCloseBtnClick(args, dropDownBoxInstance) {\r\n        dropDownBoxInstance.close();\r\n    }\r\n</script>");
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
