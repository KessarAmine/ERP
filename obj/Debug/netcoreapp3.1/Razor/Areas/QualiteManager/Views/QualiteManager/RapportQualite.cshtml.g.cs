#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d442a216677753e7565ae369c1d0fba8514ad4f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_QualiteManager_Views_QualiteManager_RapportQualite), @"mvc.1.0.view", @"/Areas/QualiteManager/Views/QualiteManager/RapportQualite.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d442a216677753e7565ae369c1d0fba8514ad4f1", @"/Areas/QualiteManager/Views/QualiteManager/RapportQualite.cshtml")]
    public class Areas_QualiteManager_Views_QualiteManager_RapportQualite : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
  
    ViewData["Title"] = "Rapports production et charge";
    Layout = "~/Views/Shared/_LayoutQualiteManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
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
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).DisplayFormat("yyyy-MM-dd").ID("FilterDateDebut"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);

        items.Add()
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("yyyy-MM-dd").ID("FilterDateFin"))
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
#line 37 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.QualiteRapports>()
    .DataSource(ds => ds.Mvc()
    .Controller("RapportQualite")
    .InsertAction("Post")
    .LoadAction("Get")
    .UpdateAction("Put")
    .DeleteAction("Delete")
    .Key("Id")
    .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
    )
    .OnRowExpanding(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        function(e) {\r\n        \te.component.collapseAll(-1);\r\n        }\r\n    ");
    PopWriter();
}
))
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
    columns.AddFor(m => m.Id);
    columns.AddFor(m => m.Date)
    .DataType(GridColumnDataType.DateTime)
    .Format("yyyy-MM-dd HH:mm")
    .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
    columns.AddFor(m => m.Profile).Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("BonCession").LoadAction("ProduiFiniLookup").Key("Value"))
    .ValueExpr("Value")
    .DisplayExpr("Text")
    .AllowClearing(true)
    );
    columns.AddFor(m => m.Controleur).Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("BonCession").LoadAction("QualitePersonnelLookup").Key("Value"))
    .ValueExpr("Value")
    .DisplayExpr("Text")
    .AllowClearing(true)
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
    WriteLiteral("imprimerRapport");
    PopWriter();
}
))
        .Icon("print");

    });


    })
    .MasterDetail(md => md
    .Enabled(true)
    .Template(new TemplateName("RapportsDetails"))
    )
   .Editing(editing =>
   {
       editing.AllowUpdating(true);
       editing.AllowDeleting(true);
       editing.AllowAdding(true);
       editing.Mode(GridEditMode.Form);
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
            WriteLiteral("\r\n");
#nullable restore
#line 118 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
 using (Html.DevExtreme().NamedTemplate("RapportsDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Détails")
                .Template(new TemplateName("DétailsGrid"))
                .Option("DétailsGrid", new { id = new JS("data.Id") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 128 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 130 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
 using (Html.DevExtreme().NamedTemplate("DétailsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 132 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.QualiteRapportsDetails>()
            .DataSource(ds => ds.Mvc()
            .Controller("RapportQualite")
            .LoadAction("GetDetails")
            .InsertAction("PostDetails")
            .UpdateAction("PutDetails")
            .DeleteAction("DeleteDetails")
            .Key("Id")
            .LoadParams(new
            {
                id = new JS("DétailsGrid.id")
            }
            )
            )
            .RemoteOperations(true)
            .NoDataText("Aucune donnée à afficher")
            .CacheEnabled(true)
            .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
            .Columns(columns => {
            columns.AddFor(m => m.Jour)
            .DataType(GridColumnDataType.DateTime)
            .Format("yyyy-MM-dd")
            .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
            columns.AddFor(m => m.Fardeau1);
            columns.AddFor(m => m.Fardeau2);
            columns.AddFor(m => m.Fardeau3);
            columns.AddFor(m => m.Rebut1);
            columns.AddFor(m => m.Rebut2);
            columns.AddFor(m => m.Rebut3);
            columns.AddFor(m => m.FardeauExpedie1);
            columns.AddFor(m => m.FardeauExpedie2);
            columns.AddFor(m => m.FardeauExpedie3);
            columns.AddFor(m => m.FardeauStockTheorique);
            columns.AddFor(m => m.FardeauStockReel);
            })
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
       editing.AllowUpdating(true);
       editing.AllowDeleting(true);
       editing.AllowAdding(true); editing.Mode(GridEditMode.Form);
   })

);

#line default
#line hidden
#nullable disable
#nullable restore
#line 182 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
 
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function toolbar_preparing_Rapport(e) {
        var dataGrid = e.component;

        e.toolbarOptions.items.unshift({
            location: ""after"",
            widget: ""dxButton"",
            options: {
                icon: ""plus"",
                width: 34,
                onClick: function (e) {
                    var popup = $(""#AddOt-popup"").dxPopup(""instance"");
                    popup.option(""contentTemplate"", $(""#EditerRapport""));
                    popup.show();
                }
            }
        });
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
        dropDownBoxInstance.optio");
            WriteLiteral(@"n(""value"", keys);
    }
    function onCloseBtnClick(args, dropDownBoxInstance) {
        dropDownBoxInstance.close();
    }
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
        DevExpress.ui.notify(""Rafraichissem");
            WriteLiteral(@"ent en cours!"");
        var demandesTravailGrid = $(""#demandesTravailGrid"").dxDataGrid(""instance"");
        var demandesTravailDS = demandesTravailGrid.getDataSource();
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
    function dateFinBox_value() {
        var dateFinBox = $(""#FilterDateFin"").dxDateBox(""instance"");
        console.log(dateFinBox.option('value'));
        return new Date(dateFinBox.option('value')).toJSON();
    }
    function receptionCell_prepared(e) {
        if (e.rowType === ""data"" && e.column.command === ""edit"") {
            var isEditing = e.row.isEditing, $links = e.cellElement.find("".");
            WriteLiteral(@"dx-link"");
            $links.text("""");
            if (isEditing) {
                $links.filter("".dx-link-save"").addClass(""dx-icon-save"");
                $links.filter("".dx-link-cancel"").addClass(""dx-icon-revert"");
            } else {
                $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
                $links.filter("".dx-link-delete"").addClass(""dx-icon-trash"");
            }
        }
    }
    var imprimerRapport = function (e) {
        var num = e.row.data.Id;
        window.open(' ");
#nullable restore
#line 273 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\QualiteManager\Views\QualiteManager\RapportQualite.cshtml"
                 Write(Url.Action("RapportQualiteViewer", "QualiteManager"));

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
    function onCloseBtnClick(args, dropDownBoxInstance) {
        dropDownBoxInstance.close();
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