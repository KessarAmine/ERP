#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11fb471290e0bb88e3e792480457fe0aa59ce3b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinSuperviseur_Views_MagasinSuperviseur_Entree), @"mvc.1.0.view", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/Entree.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
using DevKbfSteel.Areas.MagasinManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11fb471290e0bb88e3e792480457fe0aa59ce3b4", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/Entree.cshtml")]
    public class Areas_MagasinSuperviseur_Views_MagasinSuperviseur_Entree : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 10 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
  
    ViewData["Title"] = "Magasin-Entrées";
    Layout = "~/Views/Shared/_LayoutMagasinSuperviseur.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
#line 38 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkBonEntree>()
        .ID("BonEntree")
        .DataSource(ds => ds.Mvc()
        .Controller("Entrees")
        .LoadAction("Get")
        .InsertAction("Post")
        .UpdateAction("Put")
        .DeleteAction("Delete")
        .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
        .Key("NumBon")
        )
        .RemoteOperations(true)
        .NoDataText("Aucune donnée à afficher")
        .CacheEnabled(true)
        .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
        .Columns(columns => {
            columns.AddFor(m => m.DateEntree)
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
            .AllowClearing(true))
            .EditCellTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral(" ");
#nullable restore
#line 69 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
                                 Write(Html.Partial("DxDropDownBoxFournisseur"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));

            columns.AddFor(m => m.TypeSource)
                .Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("Entrees").LoadAction("TypeSourceLookup").Key("Value"))
                .ValueExpr("Value")
                .DisplayExpr("Text")
                .AllowClearing(true));
            columns.AddFor(m => m.NumSource);
            columns.AddFor(m => m.DateDa)
             .Format("yyyy-MM-dd")
             .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
            columns.AddFor(m => m.Nda);
            columns.AddFor(m => m.TypeAchat)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Entrees").LoadAction("TypeAchatLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            .AllowClearing(true));
            columns.AddFor(m => m.TypeDevise)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Entrees").LoadAction("TypeDeviseLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            .AllowClearing(true));
            columns.AddFor(m => m.TauxChange);

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
    WriteLiteral("imprimerBoneEntree");
    PopWriter();
}
))
                .Icon("print");
            });
        })
.OnRowExpanding("CollpaseAll")
.OnRowExpanded("refreshButton_click")
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
.Template(new TemplateName("BonEntreeDetails")))
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
#line 134 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("BonEntreeDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Détails")
                .Template(new TemplateName("DétailsGrid"))
                .Option("DétailsGrid", new { id = new JS("data.NumBon") });
            items.Add()
                .Title("Frais d'pproches")
                .Template(new TemplateName("FraisApprocheGrid"))
                .Option("FraisApprocheGrid", new { id = new JS("data.NumBon") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 148 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("DétailsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 152 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkBonEntreeArticles>()
            .DataSource(ds => ds.Mvc()
            .Controller("Entrees")
            .LoadAction("GetDetails")
            .InsertAction("PostDetail")
            .UpdateAction("PutDetail")
            .DeleteAction("DeleteDetail")
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
#line 182 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
                             Write(Html.Partial("DxDropDownPdrEntree"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
        columns.AddFor(m => m.QteRecu);
        columns.AddFor(m => m.PrixUnitaire);
        columns.AddFor(m => m.Montant).AllowEditing(false);
        columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b =>
        {
            b.Add().Name(GridColumnButtonName.Edit);
            b.Add().Name(GridColumnButtonName.Delete);
        });
    })
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
#line 213 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 215 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("FraisApprocheGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 217 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkEntreeFraisApproches>()
            .DataSource(ds => ds.Mvc()
            .Controller("FraisApproches")
            .LoadAction("GetFraisEntree")
            .InsertAction("PostFraisEntree")
            .UpdateAction("PutFraisEentree")
            .DeleteAction("DeleteFraisEntree")
            .Key("Id")
            .LoadParams(new
            {
                id = new JS("FraisApprocheGrid.id")
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
        columns.AddFor(m => m.CodeFrais)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("FraisApproches").LoadAction("FraisLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        )
        .EditCellTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral(" ");
#nullable restore
#line 247 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
                             Write(Html.Partial("DxDropDownBoxFraisApproches"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
        columns.AddFor(m => m.CodeArticle);
        columns.AddFor(m => m.NumFacture);
        columns.AddFor(m => m.MontantDevise);
        columns.AddFor(m => m.ValeurFrais);
        columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b =>
        {
            b.Add().Name(GridColumnButtonName.Edit);
            b.Add().Name(GridColumnButtonName.Delete);
        });
    })
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
#line 279 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
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
        var demandesTravailGrid = $(""#BonEntree"").dxDataGrid(""instance"");
        var demandesTravail");
            WriteLiteral(@"DS = demandesTravailGrid.getDataSource();
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
            var isEditing = e.row.isEditing, $links = e.cellElement.find("".dx-link"");
            $links.text("""");
            if (isEditing) {
                $links.filter("".dx-link-save"").addClass(""d");
            WriteLiteral(@"x-icon-save"");
                $links.filter("".dx-link-cancel"").addClass(""dx-icon-revert"");
            } else {
                $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
                $links.filter("".dx-link-delete"").addClass(""dx-icon-trash"");
            }
        }
    }
    function CollpaseAll(e) {
        e.component.collapseAll(-1);
    }
    var imprimerBoneEntree = function (e) {
        var num = e.row.data.NumBon;
        window.open(' ");
#nullable restore
#line 340 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
                 Write(Url.Action("BonEntreeViewer", "MagasinSuperviseur"));

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
