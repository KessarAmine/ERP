#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44c7ad703ec502ce529b6951a7cd5ff81bc32784"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44c7ad703ec502ce529b6951a7cd5ff81bc32784", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/Entree.cshtml")]
    public class Areas_MagasinSuperviseur_Views_MagasinSuperviseur_Entree : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44c7ad703ec502ce529b6951a7cd5ff81bc327844917", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
      
        ViewData["Title"] = "Entrées";
        Layout = "~/Views/Shared/_LayoutMagasinSuperviseur.cshtml";
    

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44c7ad703ec502ce529b6951a7cd5ff81bc327846200", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 18 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
           .Hint("Fournisseurs")
           .Icon("group")
           .OnClick("addFournisseur"))
           .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
           .Location(ToolbarItemLocation.Before);
    }
    )
);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 49 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
        columns.AddFor(m => m.NumBon).Caption("N° BE").AllowEditing(false);
        columns.AddFor(m => m.DateEntree)
            .Format("dd-MM-yyyy")
            .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month))
            .DataType(GridColumnDataType.DateTime);

        columns.AddFor(m => m.CodeIntervenant)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Sorties").LoadAction("IntervenantLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            .AllowClearing(true));
        columns.AddFor(m => m.CodeFournisseur).Caption("Frounisseur")
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Fournisseurs").LoadAction("FournisseurLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text"));
        columns.AddFor(m => m.TypeAchat)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Entrees").LoadAction("TypeAchatLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            .AllowClearing(true)).Visible(false);
        columns.AddFor(m => m.TypeDevise)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Entrees").LoadAction("TypeDeviseLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            .AllowClearing(true)).Visible(false);
        columns.AddFor(m => m.TauxChange).Visible(false);

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
.Scrolling(scrolling => scrolling
.ScrollByContent(true)
.ShowScrollbar(ShowScrollbarMode.Always)
.Mode(GridScrollingMode.Infinite))
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
#line 138 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("BonEntreeDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 140 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
#line 152 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("DétailsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 156 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
.Mode(GridScrollingMode.Infinite))
.RemoteOperations(true)
.NoDataText("Aucune donnée à afficher")
.CacheEnabled(true)
.WordWrapEnabled(true)
.SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
.Columns(columns => {
columns.AddFor(m => m.CodePdr).Caption("Code Article").AllowEditing(false);
columns.AddFor(m => m.CodePdr).Caption("Article")
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
#line 188 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
columns.AddFor(m => m.CoutUnitaire).AllowEditing(false);
columns.AddFor(m => m.Montant).AllowEditing(false);
columns.AddFor(m => m.ArticleNonGere).AllowEditing(false);
columns.AddFor(m => m.CodeInvesstisment).Caption("Invest?").Visible(false);
columns.AddFor(m => m.CodeFrais).Visible(false)
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
#line 202 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
                     Write(Html.Partial("DxDropDownBoxFraisApproches"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
columns.AddFor(m => m.ValeurFrais).Visible(false);
columns.AddFor(m => m.MontantDevise).Caption("% Devise Frais").Visible(false);
columns.AddFor(m => m.NumFacture).Visible(false);
columns.Add()
.Type(GridCommandColumnType.Buttons)
.Width(110)
.Buttons(b =>
{
    b.Add().Name(GridColumnButtonName.Edit);
    b.Add().Name(GridColumnButtonName.Delete);
});
})
.Summary(s => s.TotalItems(items =>
{
items.Add()
    .SummaryType(SummaryType.Count)
    .Column("Code Article")
    .ShowInColumn("Code Article")
    .DisplayFormat("Count : {0}");
items.Add()
    .SummaryType(SummaryType.Sum)
    .Column("QteRecu")
    .ShowInColumn("QteRecu")
    .DisplayFormat("Total : {0} Dzd");
items.Add()
    .SummaryType(SummaryType.Sum)
    .Column("PrixUnitaire")
    .ShowInColumn("PrixUnitaire")
    .DisplayFormat("Total : {0} Dzd");
items.Add()
    .SummaryType(SummaryType.Sum)
    .Column("CoutUnitaire")
    .ShowInColumn("CoutUnitaire")
    .DisplayFormat("Total : {0} Dzd");
items.Add()
    .SummaryType(SummaryType.Sum)
    .Column("Montant")
    .ShowInColumn("Montant")
    .DisplayFormat("Total : {0} Dzd");
}))
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
#line 261 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 263 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("FraisApprocheGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 265 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
#line 295 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
                         Write(Html.Partial("DxDropDownBoxFraisApproches"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
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
.Summary(s => s.TotalItems(items =>
{
    items.Add()
        .SummaryType(SummaryType.Count)
        .Column("CodeFrais")
        .ShowInColumn("CodeFrais")
        .DisplayFormat("Count : {0}");
    items.Add()
        .SummaryType(SummaryType.Sum)
        .Column("ValeurFrais")
        .ShowInColumn("ValeurFrais")
        .DisplayFormat("Total : {0} Dzd");
}))

.Scrolling(scrolling => scrolling
.ScrollByContent(true)
.ShowScrollbar(ShowScrollbarMode.Always)
.Mode(GridScrollingMode.Infinite))
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
#line 344 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 346 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("BonAffectationGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 348 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkAffectations>()
    .DataSource(ds => ds.Mvc()
    .Controller("StkAffectations")
    .LoadAction("GetBonAffectationBonEntree")
    .InsertAction("PostBonAffectation")
    .UpdateAction("PutBonAffectation")
    .DeleteAction("DeleteBonAffectation")
    .LoadParams(new
    {
        NumBonEntree = new JS("BonAffectationGrid.id")
    }
    )
    .Key("NumBonAffectation")
    )
    .RemoteOperations(true)
    .NoDataText("Aucune donnée à afficher")
    .CacheEnabled(true)
    .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
    .Columns(columns => {
        columns.AddFor(m => m.DateAffectation).Caption("Date Affectation")
        .Format("dd-MM-yyyy")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
        columns.AddFor(m => m.DateEntree).Caption("Date Entrée")
        .Format("dd-MM-yyyy")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
        columns.AddFor(m => m.CodeIntervenant)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("Sorties").LoadAction("IntervenantLookup").Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            .AllowClearing(true));
        columns.AddFor(m => m.ServiceReceveur)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("Sorties").LoadAction("CentreFraisLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true));
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
#line 418 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 420 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("BonAffectationDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 422 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
#line 430 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 432 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesBonAffectationGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 434 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkAffectationsArticles>()
    .DataSource(ds => ds.Mvc()
    .Controller("StkAffectations")
    .InsertAction("PostBonAffectationArticles")
    .UpdateAction("PutBonAffectationArticles")
    .DeleteAction("DeleteBonAffectationArticles")
    .LoadAction("GetBonAffectationArticles")
    .Key("Id")
    .LoadParams(new
    {
        numBonAffectation = new JS("BonAffectationDetailsGrid.id")
    }
    )
    )
    .RemoteOperations(true)
    .NoDataText("Aucune donnée à afficher")
    .CacheEnabled(true)
    .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
    .Columns(columns => {
        columns.AddFor(m => m.CodePdr).Caption("Code Article").AllowEditing(false);
        columns.AddFor(m => m.CodePdr).Caption("Article")
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
#line 461 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
                             Write(Html.Partial("DxDropDownBoxArticlesBonAffectation"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
        columns.AddFor(m => m.Qte);
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
#line 490 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 492 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
 using (Html.DevExtreme().NamedTemplate("FournisseursGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 494 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproFournisseurs>()
        .Width("100%")
        .Height("100%")
        .DataSource(ds => ds.Mvc()
        .Controller("Fournisseurs")
        .LoadAction("GetFournisseurs")
        .InsertAction("PostFournisseurs")
        .UpdateAction("PutFournisseurs")
        .DeleteAction("DeleteFournisseurs")
        .Key("NumeroFournisseur"))
        .RemoteOperations(true)
        .NoDataText("Aucune donnée à afficher")
        .CacheEnabled(true)
        .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
        .Scrolling(scrolling => scrolling
        .ScrollByContent(true)
        .ShowScrollbar(ShowScrollbarMode.Always)
        .Mode(GridScrollingMode.Infinite))
        .Columns(columns => {
        columns.AddFor(m => m.NumeroFournisseur).AllowEditing(false);
        columns.AddFor(m => m.SocieteFournisseur);
        columns.AddFor(m => m.Adresse);
        columns.AddFor(m => m.Fonction);
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
            editing.AllowDeleting(false);
            editing.AllowAdding(true);
            editing.Mode(GridEditMode.Row);
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 533 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
         

}

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 537 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
Write(Html.DevExtreme().Popup()
.FullScreen(true)
.ID("AddFournisseur-popup")
.ShowTitle(true)
.Title("Liste Frounisseurs")
.Visible(false)
.DragEnabled(false)
.CloseOnOutsideClick(true)
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
    var demandesTravailGrid = $(""#BonEntree"").dxDataGrid(""instance"");
    var demandesTravailDS = demandesTravailGrid.getDataSource();
    demandesTravailGrid.beginCustomLoading(""Chargem");
                WriteLiteral(@"ent en cours..."");
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
            $links.filter("".dx-link-save"").addClass(""dx-icon-save"");
            $links.filter("".dx-link-cancel"").addClass(""dx-icon-revert"");
        } else {
            $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
");
                WriteLiteral("            $links.filter(\".dx-link-delete\").addClass(\"dx-icon-trash\");\r\n        }\r\n    }\r\n}\r\nfunction CollpaseAll(e) {\r\n    e.component.collapseAll(-1);\r\n}\r\nvar imprimerBoneEntree = function (e) {\r\n    var num = e.row.data.NumBon;\r\n    window.open(\' ");
#nullable restore
#line 605 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
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
function addFournisseur(e) {
    var popup = $(""#AddFournisseur-popup"").dxPopup(""instance"");
    popup.option(""contentTemplate"", $(""#FournisseursGrid""));
        popup.show();
    }
function onSelectionChanged(e, dropDownBoxInstance) {
    var keys = e.selectedRowKeys;
    dropDownBoxInstance.option(""value"", keys);
}
function onCloseBtnClick(args, dropDownBoxInstance) {
    dropDownBoxInstance.close();
}
var imprimerBonAffectation = function (e) {
    var num = e.row.data.NumBonAffectation;
    window.open(' ");
#nullable restore
#line 629 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\Entree.cshtml"
             Write(Url.Action("BonAffectationViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n}\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n");
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
