#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6a545d16f3af75e02ee58aec567f0986205fd66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UsinageManager_Views_UsinageManager_CylindrePreprocessing), @"mvc.1.0.view", @"/Areas/UsinageManager/Views/UsinageManager/CylindrePreprocessing.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6a545d16f3af75e02ee58aec567f0986205fd66", @"/Areas/UsinageManager/Views/UsinageManager/CylindrePreprocessing.cshtml")]
    public class Areas_UsinageManager_Views_UsinageManager_CylindrePreprocessing : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
  
    ViewData["Title"] = "Usinage-Preprocessing Cylindres";
    Layout = "~/Views/Shared/_LayoutUsinageManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
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

    })
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ProdPreProccessingCylindresUsinage>()
 .DataSource(ds => ds.Mvc()
     .Controller("CylindresPreprocess")
     .LoadAction("GetPreProcessing")
     .UpdateAction("PutPreProcessing")
     .Key("Id")
     .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value")}))
     .ColumnChooser(cc => cc.Enabled(true).AllowSearch(true))
     .Scrolling(scrolling => scrolling
     .ScrollByContent(true)
     .ShowScrollbar(ShowScrollbarMode.Always)
     .Mode(GridScrollingMode.Virtual))
     .Height("95%")
     .RemoteOperations(true)
     .ID("demandesTravailGrid")
     .NoDataText("Aucune donnée à afficher")
     .CacheEnabled(true)
     .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
 .Columns(columns => {
     columns.AddFor(m => m.DateChangement)
     .Format("yyyy-MM-dd")
     .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.AddFor(m => m.RefCylindre).Caption("Cylindre")
     .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("CylindresPreprocess").LoadAction("CylindresLookup").Key("Value"))
    .AllowClearing(true)
    .ValueExpr("Value")
    .DisplayExpr("Text")
    );
     columns.AddFor(m => m.DiametreAtteint).Caption("⌀Entrée");
     columns.AddFor(m => m.DateEntreeUsinage)
     .Format("yyyy-MM-dd")
     .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.AddFor(m => m.DateSortieUsinage)
     .Format("yyyy-MM-dd")
     .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.AddFor(m => m.DiametreSortieCylindre).Caption("⌀Sortie");

     columns.AddFor(m => m.EtatPreProcessing).Caption("Etat")
     .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("DemandeTravails").LoadAction("StatutLookup").Key("Value"))
    .AllowClearing(true)
    .ValueExpr("Value")
    .DisplayExpr("Text")
    );
 columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(50)
        .Buttons(b => {
        b.Add().Name(GridColumnButtonName.Edit);
        });
 })
   .Editing(editing =>
   {
       editing.AllowUpdating(true);
       editing.AllowDeleting(false);
       editing.AllowAdding(false);
       editing.Mode(GridEditMode.Form);
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
        var demandesTravailGrid = $(""#demandesTravailGrid"").dxDataGrid(""instance"");
       ");
            WriteLiteral(@" var demandesTravailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();
        demandesTravailGrid.endCustomLoading();
    }

    function addButton_click() {
        DevExpress.ui.notify(""Ajouter une demande!"");
        window.location.href = '");
#nullable restore
#line 143 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
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
                $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
                $links.filter("".dx-link-dele");
            WriteLiteral(@"te"").addClass(""dx-icon-trash"");
            }
        }
        if (e.rowType === ""data"") {
            var dangerColor = ""#f54542"";
            if (e.column.dataField == ""DateFinAmbouche"") {
                var Today = new Date();
                var DateFin = new Date();
                DateFin = e.value;
                var limit = ");
#nullable restore
#line 176 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\CylindrePreprocessing.cshtml"
                       Write(XpertHelper.FacteurContratEnding);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
                Today.setHours(0, 0, 0, 0)
                DateFin.setHours(0, 0, 0, 0)
                var diffInMs = Math.abs(DateFin - Today);
                diffInMs = diffInMs / (1000 * 60 * 60 * 24);

                if (diffInMs <= limit) {
                    $(e.cellElement).get(0).style.backgroundColor = dangerColor;
                }
            }
        }
    }
</script>");
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
