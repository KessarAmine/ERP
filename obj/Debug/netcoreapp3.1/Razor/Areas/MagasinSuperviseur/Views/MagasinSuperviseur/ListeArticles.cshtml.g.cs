#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dd14f74bba8036b259d7b1700fb43a9695a93b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinSuperviseur_Views_MagasinSuperviseur_ListeArticles), @"mvc.1.0.view", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/ListeArticles.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dd14f74bba8036b259d7b1700fb43a9695a93b8", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/ListeArticles.cshtml")]
    public class Areas_MagasinSuperviseur_Views_MagasinSuperviseur_ListeArticles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
  
    ViewData["Title"] = "Liste PDR";
    Layout = "~/Views/Shared/_LayoutMagasinSuperviseur.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
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
    }
    )
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkPdr>()
         .DataSource(ds => ds.Mvc()
             .Controller("StkPdrs")
             .LoadAction("GetArticles")
             .InsertAction("PostArticles")
             .UpdateAction("PutPDR")
             .DeleteAction("DeletePDR")
             .Key("CodePdr"))
     .ID("ArticlesGrid")
    .OnRowExpanding("CollpaseAll")
    .OnRowExpanded("refreshButton_click")
     .ColumnChooser(cc => cc.Enabled(true).AllowSearch(true))
     .Scrolling(scrolling => scrolling
     .ScrollByContent(true)
     .ShowScrollbar(ShowScrollbarMode.Always)
     .Mode(GridScrollingMode.Virtual))
     .Height("95%")
     .RemoteOperations(true)
     .NoDataText("Aucune donnée à afficher")
     .CacheEnabled(true)
     .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
     .Columns(columns => {
         columns.AddFor(m => m.CodePdr).Caption("Code Article");
         columns.AddFor(m => m.DesignationPdr).Caption("Article");
         columns.AddFor(m => m.ReferenceModele).Visible(false);
         columns.AddFor(m => m.CodeUniteMesurePdr).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("UniteMesureLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );
         columns.AddFor(m => m.CodeFabricant).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("CodeFabricantLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );
         columns.AddFor(m => m.CodeFamillePdr).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("FamilleLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        ).Visible(false);
         columns.AddFor(m => m.CodeSousFamillePdr).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("SousFamilleLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        ).Visible(false);
         columns.AddFor(m => m.CodeGroupe).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("GroupeLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        ).Visible(false);
         columns.AddFor(m => m.Conditionnement).Visible(false);
         columns.AddFor(m => m.TypeValorisation).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("TypeValorisationLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );
         columns.AddFor(m => m.TypeArticle).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("TypeArticleLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        ).Visible(false);
         columns.AddFor(m => m.CompteComptable);
     })
    .Editing(editing =>
    {
        editing.AllowUpdating(true);
        editing.AllowDeleting(true);
        editing.AllowAdding(true);
        editing.Mode(GridEditMode.Form);
    })
   .MasterDetail(md => md
   .Enabled(true)
   .Template(new TemplateName("PdrDetails")))
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
            WriteLiteral("\r\n");
#nullable restore
#line 115 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().Popup()
.ID("Add-popup")
.ShowTitle(true)
.Title("Editer")
.Visible(false)
.DragEnabled(false)
.CloseOnOutsideClick(true)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 123 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 using (Html.DevExtreme().NamedTemplate("PdrDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 125 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Fiche Article")
                .Template(new TemplateName("FicheArticleGrid"))
                .Option("FicheArticleGrid", new { CodePdr = new JS("data.CodePdr"), codeService = XpertHelper.CodeMagasin });
            items.Add()
                .Title("Suivi des mouvements")
                .Template(new TemplateName("SuiviGrid"))
                .Option("SuiviGrid", new { CodePdr = new JS("data.CodePdr")});
            items.Add()
                .Title("Donnees de stockage")
                .Template(new TemplateName("EmplacementGrid"))
                .Option("EmplacementGrid", new { CodePdr = new JS("data.CodePdr")});
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 141 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 using (Html.DevExtreme().NamedTemplate("FicheArticleGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 145 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkFicheArticle>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(true))
        .Columns(columns =>
        {
            columns.AddFor(m => m.Date);
            columns.AddFor(m => m.Emeteur).AllowEditing(false).Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("DemandeTravails").LoadAction("StructureLookup").Key("Value"))
                .ValueExpr("Value")
                .DisplayExpr("Text")
                .AllowClearing(true)
            );
            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b => {
                    b.Add().Name(GridColumnButtonName.Edit).Icon("edit");
                    b.Add().Name(GridColumnButtonName.Delete).Icon("trash");
                    b.Add()
                            .Hint("Imprimer Fiche Article")
                            .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerFicheArticle");
    PopWriter();
}
))
                            .Icon("print");
                });
        })
         .DataSource(ds => ds.Mvc()
             .Controller("StkPdrs")
             .LoadAction("GetFicheArticle")
             .InsertAction("PostFicheArticleMagasin")
             .UpdateAction("PutFicheArticle")
             .DeleteAction("DeleteFicheArticle")
             .Key("NumFicheArticle")
             .LoadParams(new
             {
                 CodePdr = new JS("FicheArticleGrid.CodePdr"),
                 codeService = new JS("FicheArticleGrid.codeService")
             }))
           .MasterDetail(md => md
           .Enabled(true)
           .Template(new TemplateName("FicheArticleDetails")))
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
#line 191 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
             

}

#line default
#line hidden
#nullable disable
#nullable restore
#line 194 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 using (Html.DevExtreme().NamedTemplate("FicheArticleDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 196 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Données de plannification")
                .Template(new TemplateName("StockContrainteGrid"))
                .Option("DonnePlannificationGrid", new { CodeFicheArticle = new JS("data.NumFicheArticle"), codeService = XpertHelper.CodeMagasin });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 204 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 206 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 using (Html.DevExtreme().NamedTemplate("StockContrainteGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 208 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkPdrStockContrainte>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(true))
        .Columns(columns =>
        {
            columns.AddFor(m => m.StockMaximum);
            columns.AddFor(m => m.StockMinimum);
            columns.AddFor(m => m.StockSécurité);
            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b => {
                    b.Add().Name(GridColumnButtonName.Edit).Icon("edit");
                    b.Add().Name(GridColumnButtonName.Delete).Icon("trash");
                });
        })
         .DataSource(ds => ds.Mvc()
             .Controller("StkPdrs")
             .LoadAction("GetContrainteStockage")
             .InsertAction("PostContrainteStockageMagasin")
             .UpdateAction("PutContrainteStockage")
             .DeleteAction("DeleteContrainteStockage")
             .Key("Id")
             .LoadParams(new
             {
                 CodeFicheArticle = new JS("DonnePlannificationGrid.CodeFicheArticle"),
                 codeService = new JS("DonnePlannificationGrid.codeService")
             }))
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
#line 244 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 247 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 using (Html.DevExtreme().NamedTemplate("EmplacementGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 249 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkEmplacement>()
   .ShowBorders(true)
   .LoadPanel(l => l.Enabled(true))
   .Columns(columns =>
   {
       columns.AddFor(m => m.CodeLieu).Caption("Lieu").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("CodelieuLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );
       columns.AddFor(m => m.CodeGisement).Caption("Gisement").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("StkPdrs").LoadAction("CodeGisementLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );
       columns.AddFor(m => m.Qte);
   })
   .DataSource(ds => ds.Mvc()
       .Controller("StkPdrs")
       .LoadAction("GetEmplacementPDRSuperviseur")
       .UpdateAction("PutEmplacementPDR")
       .LoadParams(new
       {
           CodePdr = new JS("EmplacementGrid.CodePdr")
       })
       .Key("NumEmplacement")
       )
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
#nullable restore
#line 293 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 297 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 using (Html.DevExtreme().NamedTemplate("SuiviGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 299 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Areas.MagasinManager.Models.SuiviPdrModel>()
   .ShowBorders(true)
   .LoadPanel(l => l.Enabled(true))
   .Columns(columns =>
   {
       columns.AddFor(m => m.DateMovement).Caption("Date")
        .Format("dd-MM-yyyy")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
       columns.AddFor(m => m.TypeMovement).Caption("Movement");
       columns.AddFor(m => m.NumeroTypeMovement).Caption("N°");
       columns.AddFor(m => m.Quantite);
       columns.AddFor(m => m.Cout);
       columns.AddFor(m => m.Valeur);
       columns.AddFor(m => m.Reste);
       columns.AddFor(m => m.Acteur);
   })
   .DataSource(ds => ds.Mvc()
       .Controller("StkPdrs")
       .LoadAction("GetSuiviArticles")
       .LoadParams(new
       {
           CodePdr = new JS("SuiviGrid.CodePdr")
       }))
   .Editing(editing =>
   {
       editing.AllowUpdating(false);
       editing.AllowDeleting(false);
       editing.AllowAdding(false);
       editing.Mode(GridEditMode.Form);
   })
   .OnToolbarPreparing("toolbar_preparing_Rapport")
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
#nullable restore
#line 338 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
 

}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function receptionCell_prepared(e) {
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
    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#ArticlesGrid"").dxDataGrid(""instance"");
        var demandesTravailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();");
            WriteLiteral(@"
        demandesTravailGrid.endCustomLoading();
    }
    function toolbar_preparing_Rapport(e) {
        e.toolbarOptions.items.unshift({
            location: ""after"",
            widget: ""dxButton"",
            options: {
                icon: ""print"",
                width: 34,
                onClick: function (e) {
                    window.open(' ");
#nullable restore
#line 373 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
                             Write(Url.Action("SuiviArticleViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"', '_blank').focus();
                }
            }
        });
    }
    function CollpaseAll(e) {
        e.component.collapseAll(-1);
    }

    var imprimerFicheArticle = function (e) {
        var num = e.row.data.NumFicheArticle;
        window.open(  ' ");
#nullable restore
#line 384 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\ListeArticles.cshtml"
                   Write(Url.Action("FicheArticleViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n    }\r\n</script>");
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
