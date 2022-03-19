#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abe97dae4a714461fa4c860ddf26ff9583786911"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinSuperviseur_Views_MagasinSuperviseur_BonRetour), @"mvc.1.0.view", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/BonRetour.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
using DevKbfSteel.Areas.MagasinManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abe97dae4a714461fa4c860ddf26ff9583786911", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/BonRetour.cshtml")]
    public class Areas_MagasinSuperviseur_Views_MagasinSuperviseur_BonRetour : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
  
    ViewData["Title"] = "Magasin-Bons Retour";
    Layout = "~/Views/Shared/_LayoutMagasinSuperviseur.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
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
#line 40 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.SrkBonRetour>()
    .ID("Retour")
    .DataSource(ds => ds.Mvc()
    .Controller("BonRetour")
    .LoadAction("GetBonRetour")
    .InsertAction("PostBonRetour")
    .UpdateAction("PutBonRetour")
    .DeleteAction("DeleteBonRetour")
    .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
    .Key("NumBonRetour")
    )
    .RemoteOperations(true)
    .NoDataText("Aucune donnée à afficher")
    .CacheEnabled(true)
    .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
    .Columns(columns => {
    columns.AddFor(m => m.DateRetour)
        .Format("yyyy-MM-dd")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month)).AllowEditing(false);
    columns.AddFor(m => m.CodeIntervenant)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Sorties").LoadAction("IntervenantLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            .AllowClearing(true));
    columns.AddFor(m => m.CodeFournisseur)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("Fournisseurs").LoadAction("FournisseurLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true));
    columns.AddFor(m => m.NumBonEntree);
    columns.AddFor(m => m.NumBonLivrason);
    columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b =>
        {
        b.Add().Name(GridColumnButtonName.Edit);
        b.Add().Name(GridColumnButtonName.Delete);
        b.Add()
            .Hint("Imprimer")
            .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerBonRetour");
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
.Template(new TemplateName("BonRetourDetails")))
.AllowColumnReordering(true)
.AllowColumnResizing(true)
.OnCellPrepared("receptionCell_prepared")
.Selection(s => s.Mode(SelectionMode.Multiple))
.Editing(editing =>
{
    editing.AllowUpdating(true);
    editing.AllowDeleting(true);
    editing.AllowAdding(true);
    editing.Mode(GridEditMode.Form);
})
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 109 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
 using (Html.DevExtreme().NamedTemplate("BonRetourDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Détails")
                .Template(new TemplateName("DétailsGrid"))
                .Option("DétailsGrid", new { id = new JS("data.NumBonRetour") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
 using (Html.DevExtreme().NamedTemplate("DétailsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkBonRetourArticles>()
            .DataSource(ds => ds.Mvc()
            .Controller("BonRetour")
            .LoadAction("GetBonRetourDetails")
            .InsertAction("PostBonRetourDetails")
            .UpdateAction("PutBonRetourDetails")
            .DeleteAction("DeleteBonRetourDetails")
            .Key("Id")
            .LoadParams(new
            {
                id = new JS("DétailsGrid.id")
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
        columns.AddFor(m => m.CodeArticle)
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
#line 153 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
                             Write(Html.Partial("DxDropDownBoxArticlesBonAffectation"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
        columns.AddFor(m => m.Qte);
        columns.AddFor(m => m.PrixUnitaire);
        columns.AddFor(m => m.MotifRetour);
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
       editing.AllowUpdating(true);
       editing.AllowDeleting(true);
       editing.AllowAdding(true);
       editing.Mode(GridEditMode.Form);
   })
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 178 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
 
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
    function onSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;
        dropDownBoxInstance.option(""value"", keys);
        console.log(dropDownBoxInstance);
    }
    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#Retour"").dxDataGrid(""instance"");
        var demandesTravailDS ");
            WriteLiteral(@"= demandesTravailGrid.getDataSource();
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
    function CollpaseAll(e) {
        e.component.collapseAll(-1);
    }

    function receptionCell_prepared(e) {
        if (e.rowType === ""data"" && e.column.command === ""edit"") {
            var isEditing = e.row.isEditing, $links = e.cellElement.find("".dx-link"");
            $links.text("""");
            i");
            WriteLiteral(@"f (isEditing) {
                $links.filter("".dx-link-save"").addClass(""dx-icon-save"");
                $links.filter("".dx-link-cancel"").addClass(""dx-icon-revert"");
            } else {
                $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
                $links.filter("".dx-link-delete"").addClass(""dx-icon-trash"");
            }
        }
    }
    var imprimerBonRetour = function (e) {
        var num = e.row.data.NumBonRetour;
        window.open(' ");
#nullable restore
#line 240 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\BonRetour.cshtml"
                 Write(Url.Action("BonRetourViewer", "MagasinManager"));

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
