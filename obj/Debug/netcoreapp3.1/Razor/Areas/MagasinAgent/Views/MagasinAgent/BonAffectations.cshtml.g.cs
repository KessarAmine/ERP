#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80dea41c3865c4cce21305e6c3b8940175453db6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinAgent_Views_MagasinAgent_BonAffectations), @"mvc.1.0.view", @"/Areas/MagasinAgent/Views/MagasinAgent/BonAffectations.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
using DevKbfSteel.Areas.MagasinAgent.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80dea41c3865c4cce21305e6c3b8940175453db6", @"/Areas/MagasinAgent/Views/MagasinAgent/BonAffectations.cshtml")]
    public class Areas_MagasinAgent_Views_MagasinAgent_BonAffectations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
  
    ViewData["Title"] = "Magasin-Bons d'affectations";
    Layout = "~/Views/Shared/_LayoutMagasinAgent.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
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

    }
    )
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 40 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkAffectations>()
.ID("BonAffectation")
.DataSource(ds => ds.Mvc()
.Controller("StkAffectations")
.LoadAction("GetBonAffectation")
.LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
.Key("NumBonAffectation")
)
.RemoteOperations(true)
.NoDataText("Aucune donnée à afficher")
.CacheEnabled(true)
.SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
.Columns(columns => {
columns.AddFor(m => m.DateAffectation).Caption("Date Affectation")
        .Format("yyyy-MM-dd")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month)).AllowEditing(false);
columns.AddFor(m => m.NumBonEntree).Caption("N° Bon d'entrée");
columns.AddFor(m => m.DateEntree).Caption("Date Entrée");
columns.AddFor(m => m.ServiceReceveur)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkAffectations").LoadAction("ServiceReceveurLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true));
columns.AddFor(m => m.CodeIntervenant)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("Sorties").LoadAction("IntervenantLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true));
columns.Add()
    .Type(GridCommandColumnType.Buttons)
    .Width(110)
    .Buttons(b => {
    b.Add()
            .Hint("Imprimer")
            .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerBonAffectation");
    PopWriter();
}
))
                    .Icon("print");
        });
        })
.ColumnChooser(cc => cc
.Enabled(true)
.AllowSearch(true))
.Height("95%")
.Export(e => e.Enabled(true).AllowExportSelectedData(true))
.FilterRow(f => f.Visible(true))
.HeaderFilter(headerfilter => headerfilter.Visible(true))
.GroupPanel(p => p.Visible(true))
.MasterDetail(md => md
.Enabled(true)
.Template(new TemplateName("BonAffectationDetails")))
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
            WriteLiteral("\r\n");
#nullable restore
#line 103 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
 using (Html.DevExtreme().NamedTemplate("BonAffectationDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 105 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Détails bon d'affectation")
                .Template(new TemplateName("ArticlesBonAffectationGrid"))
                .Option("BonAffectationDetailsGrid", new { id = new JS("data.NumBonAffectation") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 113 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesBonAffectationGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkAffectationsArticles>()
            .DataSource(ds => ds.Mvc()
            .Controller("StkAffectations")
            .LoadAction("GetBonAffectationDemandeArticles")
            .Key("Id")
            .LoadParams(new
            {
                numBonAffectation = new JS("BonAffectationDetailsGrid.id")
            }
            )
            )
                 .Scrolling(scrolling => scrolling
     .ScrollByContent(true)
     .ShowScrollbar(ShowScrollbarMode.Always)
     .Mode(GridScrollingMode.Virtual))
    .RemoteOperations(true)
    .NoDataText("Aucune donnée à afficher")
    .CacheEnabled(true)
    .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
    .Columns(columns => {
        columns.AddFor(m => m.CodePdr)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("ApproDemandesFournitures").LoadAction("DesignationArticleLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        )
        .EditCellTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral(" ");
#nullable restore
#line 144 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
                             Write(Html.Partial("DxDropDownBoxArticlesBonAffectation"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
        columns.AddFor(m => m.Qte);
    })
.OnRowExpanding("CollpaseAll")
.OnRowExpanded("refreshButton_click")
   .ColumnChooser(cc => cc
   .Enabled(true)
   .AllowSearch(true))
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
#nullable restore
#line 167 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
 
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
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
    function CollpaseAll(e) {
        e.component.collapseAll(-1);
    }

    function onSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option(""value"", keys);
        console.log(dropDownBoxInstance);
    }
    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTrav");
            WriteLiteral(@"ailGrid = $(""#BonAffectation"").dxDataGrid(""instance"");
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
        if (e.rowType === ""data"" && e.column.command == ""edit"") {
            let d = new Date(e.row.data.DateAffectation);
            let DateRef = new Date(d.getFullYear(), d.getMonth()");
            WriteLiteral(@", d.getDate())
            let Now = new Date();
            let today = new Date(Now.getFullYear(), Now.getMonth(), Now.getDate());
            if (DateRef < today) {
                e.cellElement.find("".dx-link-edit"").remove();
                e.cellElement.find("".dx-link-delete"").remove();
            }
        }
        if (e.rowType === ""data"" && e.column.command === ""edit"") {
            var isEditing = e.row.isEditing, $links = e.cellElement.find("".dx-link"");
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
    var imprimerDemandeFourniture = function (e) {
        var num = e.row.data.NumeroDemande;
        window.open(' ");
#nullable restore
#line 239 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
                 Write(Url.Action("DemandeFournitureViewer", "MagasinManager"));

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

    var imprimerBonAffectation = function (e) {
        var num = e.row.data.NumBonAffectation;
        window.open(' ");
#nullable restore
#line 252 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinAgent\Views\MagasinAgent\BonAffectations.cshtml"
                 Write(Url.Action("BonAffectationViewer", "MagasinManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?id='+num, '_blank').focus();
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
