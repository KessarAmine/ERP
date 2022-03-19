#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d6a297435e511749fda5be558b882d218a14d4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_RhManager_Views_RhManager_ContratsEmployes), @"mvc.1.0.view", @"/Areas/RhManager/Views/RhManager/ContratsEmployes.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d6a297435e511749fda5be558b882d218a14d4b", @"/Areas/RhManager/Views/RhManager/ContratsEmployes.cshtml")]
    public class Areas_RhManager_Views_RhManager_ContratsEmployes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
  
    ViewData["Title"] = "Contrats des employés";
    Layout = "~/Views/Shared/_LayoutRhManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
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
    }
    )
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.RhContratsEmployes>()
.DataSource(ds => ds.Mvc()
 .Controller("RhContratsEmployes")
 .LoadAction("Get")
 .InsertAction("Post")
 .UpdateAction("Put")
 .DeleteAction("Delete")
 .Key("Id")
 )
.Scrolling(scrolling => scrolling
.ScrollByContent(true)
.ShowScrollbar(ShowScrollbarMode.Always)
.Mode(GridScrollingMode.Virtual))
.Height("95%")
.RemoteOperations(true)
.ID("RhContratsDesEmployesGrid")
.NoDataText("Aucune donnée à afficher")
.CacheEnabled(true)
.SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
.Columns(columns => {

columns.AddFor(m => m.IdEmployee)
    .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("RhContratsEmployes").LoadAction("EmployeLookup").Key("Value"))
    .AllowClearing(true)
    .ValueExpr("Value")
    .DisplayExpr("Text")
    )
    .EditCellTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        ");
#nullable restore
#line 56 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
   Write(Html.Partial("DxDropDownBox"));

#line default
#line hidden
#nullable disable
    WriteLiteral("\r\n        ");
    PopWriter();
}
))
        .AllowGrouping(true);

        columns.AddFor(m => m.DateAmbouche).Format("d/M/yyyy")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
        columns.AddFor(m => m.Periode);
        columns.AddFor(m => m.DateFinAmbouche).Format("d/M/yyyy").AllowEditing(false)
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

        columns.AddFor(m => m.UniteRecrutement)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("RhContratsEmployes").LoadAction("UniteRecrutementLookup").Key("Value"))
        .AllowClearing(true)
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );
        columns.AddFor(m => m.TypeContrat)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("RhContratsEmployes").LoadAction("TypeContratLookup").Key("Value"))
        .AllowClearing(true)
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );

        columns.AddFor(m => m.Etat).AllowEditing(false)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("RhContratsEmployes").LoadAction("EtatLookup").Key("Value"))
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
    WriteLiteral("imprimerContrat");
    PopWriter();
}
))
                .Icon("print");
        });
    })
    .Editing(editing =>
    {
        editing.AllowUpdating(true);
        editing.AllowDeleting(true);
        editing.AllowAdding(true);
        editing.Mode(GridEditMode.Popup)
        .Popup(p => p.Title("Contrat Infos")
        .ShowTitle(true)
        .Position(pos => pos
        .My(HorizontalAlignment.Center, VerticalAlignment.Center)
        .At(HorizontalAlignment.Center, VerticalAlignment.Center)
        .Of(new JS("window"))))
        .Form(f => f.Items(items =>
        {
            items.AddGroup()
                .ColCount(2)
                .ColSpan(2)
                .Items(groupItems =>
                {
                    groupItems.AddSimpleFor(m => m.IdEmployee)
                    .ColSpan(2);
                    groupItems.AddSimpleFor(m => m.TypeContrat);
                    groupItems.AddSimpleFor(m => m.Periode);
                    groupItems.AddSimpleFor(m => m.UniteRecrutement);
                    groupItems.AddSimpleFor(m => m.DateAmbouche);
                });
        }));
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 139 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
 using (Html.DevExtreme().NamedTemplate("EmbeddedDataGridMultipleIdEmployee"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 141 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
Write(Html.DevExtreme().DataGrid()
        .ID("embedded-datagridMultipleIdEmployee")
        .DataSource(new JS(@"component.getDataSource()"))
        .Columns(columns => {
            columns.Add().DataField("Nom");
            columns.Add().DataField("Prenom");
            columns.Add().DataField("Departement")
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("RhListeDesEmployes").LoadAction("DepartementsLookup").Key("Value"))
            .AllowClearing(true)
            .ValueExpr("Value")
            .DisplayExpr("Text")
            );})
        .HoverStateEnabled(true)
        .Paging(p => p.PageSize(10))
        .FilterRow(f => f.Visible(true))
        .Scrolling(s => s.Mode(GridScrollingMode.Infinite))
        .Height(345)
        .Selection(s => s.Mode(SelectionMode.Single))
        .SelectedRowKeys(new JS("component.option('value')"))
        .OnSelectionChanged(@"function(args) { onSelectionChanged(args, component); }")
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 162 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
     
}

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
        var demandesTravailGrid = $(""#RhContratsDesEmployesGrid"").dxDataGrid(""instance"");
   ");
            WriteLiteral(@"     var demandesTravailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();
        demandesTravailGrid.endCustomLoading();
    }

    function addButton_click() {
        DevExpress.ui.notify(""Ajouter une demande!"");
        window.location.href = '");
#nullable restore
#line 202 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
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
#line 235 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
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
    var imprimerContrat = function (e) {
        var TypeContrat = e.row.data.TypeContrat;
        var num = e.row.data.Id;
        if (TypeContrat == 4)//Stagiere
        {
            window.open(' ");
#nullable restore
#line 252 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
                     Write(Url.Action("ContratTravailStagiereViewer", "RhManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n        }\r\n        else\r\n        {\r\n            window.open(\' ");
#nullable restore
#line 256 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\RhManager\Views\RhManager\ContratsEmployes.cshtml"
                     Write(Url.Action("ContratTravailViewer", "RhManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n        }\r\n    }\r\n</script>");
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