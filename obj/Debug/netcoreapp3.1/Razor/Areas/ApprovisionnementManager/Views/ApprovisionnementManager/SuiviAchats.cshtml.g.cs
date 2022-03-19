#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86f6cab9f0e00a1cbb663f9088acf97166404a9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ApprovisionnementManager_Views_ApprovisionnementManager_SuiviAchats), @"mvc.1.0.view", @"/Areas/ApprovisionnementManager/Views/ApprovisionnementManager/SuiviAchats.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86f6cab9f0e00a1cbb663f9088acf97166404a9d", @"/Areas/ApprovisionnementManager/Views/ApprovisionnementManager/SuiviAchats.cshtml")]
    public class Areas_ApprovisionnementManager_Views_ApprovisionnementManager_SuiviAchats : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
  
    ViewData["Title"] = "Bons de Production";
    Layout = "~/Views/Shared/_LayoutApprovisionnementManager.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
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
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("dd/MM/yyyy").ID("FilterDateDebut"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before);

        items.Add()
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(DateTime.Now.Date).DisplayFormat("dd/MM/yyyy").ID("FilterDateFin"))
            .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
            .Location(ToolbarItemLocation.Before)
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
#line 40 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproDemandeAchats>()
        .ID("DemandesAchats")
        .DataSource(ds => ds.Mvc()
        .Controller("ApproDemandeAchats")
        .LoadAction("Get")
        .InsertAction("Post")
        .UpdateAction("Put")
        .DeleteAction("Delete")
        .Key("NumDemandeAchat")
        .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })

    )
    .RemoteOperations(true)
    .Columns(columns => {

        columns.AddFor(m => m.NumDemandeAchat);
        columns.AddFor(m => m.DateDemandeAchat)
        .Format("dd/MM/yyyy HH:mm")
        .DataType(GridColumnDataType.DateTime)
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));


        columns.AddFor(m => m.CodeServiceDemandeur)
        .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi()
            .Controller("ApproDemandeAchats")
            .LoadAction("ApproServicesDemandeursLookup")
            .Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")
            
        );

    })
    .RemoteOperations(true)
    .MasterDetail(md => md
    .Enabled(true)
    .Template(new TemplateName("SuiviDemande"))
    )

    .Export(e => e.Enabled(true).AllowExportSelectedData(true))
    .FilterRow(f => f.Visible(true))
    .HeaderFilter(headerfilter => headerfilter.Visible(true))
    .GroupPanel(p => p.Visible(true))
    .AllowColumnReordering(true)
    .AllowColumnResizing(true)
    .OnCellPrepared("receptionCell_prepared")
    .NoDataText("Aucune donnée à afficher")
    .CacheEnabled(true)
    .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
    .RemoteOperations(true)
    .Selection(s => s.Mode(SelectionMode.Multiple))
    .Editing(editing =>
    {
        editing.AllowUpdating(true);
        editing.AllowDeleting(true);
        editing.AllowAdding(true);
        editing.Mode(GridEditMode.Popup)
        .Popup(p => p.Title("Editer Demande")
        .ShowTitle(true)
        .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
    })
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 105 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
 using (Html.DevExtreme().NamedTemplate("SuiviDemande"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 107 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Articles Demandes")
                .Template(new TemplateName("ArticlesGrid"))
                .Option("Articles", new { id = new JS("data.NumDemandeAchat") });
            items.Add()
                .Title("Bons Entrees")
                .Template(new TemplateName("BonsGrid"))
                .Option("Bons", new { id = new JS("data.NumDemandeAchat") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
         
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 123 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 125 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproArticlesDemandes>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(false))
        .Columns(columns =>
        {
            columns.AddFor(m => m.NumeroDemande).Caption("#Demande");
            columns.AddFor(m => m.CodeArticle).Caption("Desgination Article");
            columns.AddFor(m => m.Qte);
            columns.AddFor(m => m.QteLivrees).Caption("QTE Livree");
            columns.AddFor(m => m.QteReste).Caption("QTE Reste")
            .CalculateCellValue(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    function(data) {\r\n                        return [data.Qte - data.QteLivrees];\r\n                    }\r\n                ");
    PopWriter();
}
));
            ;

            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b =>
                {
                    b.Add().Name(GridColumnButtonName.Edit);
                    b.Add().Name(GridColumnButtonName.Delete);
                });
        })
         .DataSource(ds => ds.Mvc()
             .Controller("ApproDemandeAchats")
             .LoadAction("GetArticles")
             .InsertAction("PostArticles")
             .DeleteAction("DeleteArticles")
             .UpdateAction("PutArticles")
             .Key("Id")
             .LoadParams(new
             {
                 id = new JS("Articles.id")
             }
             )
            )
        .Export(e => e.Enabled(true).AllowExportSelectedData(true))
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(headerfilter => headerfilter.Visible(true))
        .GroupPanel(p => p.Visible(true))
        .AllowColumnReordering(true)
        .AllowColumnResizing(true)
        .OnCellPrepared("receptionCell_prepared")
        .NoDataText("Aucune donnée à afficher")
        .CacheEnabled(true)
        .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
        .RemoteOperations(true)
        .Selection(s => s.Mode(SelectionMode.Multiple))
        .Editing(editing =>
        {
            editing.AllowUpdating(true);
            editing.AllowDeleting(true);
            editing.AllowAdding(true);
            editing.Mode(GridEditMode.Popup)
            .Popup(p => p.Title("Editer Demande")
            .ShowTitle(true)
            .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
        })
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 186 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 189 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
 using (Html.DevExtreme().NamedTemplate("BonsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 191 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproBonsEntrees>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(false))
        .Columns(columns =>
        {
            columns.AddFor(m => m.NumBon).Caption("#Bon");
            columns.AddFor(m => m.DateEntree).Caption("Date Entree")
            .Format("dd/MM/yyyy HH:mm")
            .DataType(GridColumnDataType.DateTime)
            .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b =>
                {
                    b.Add().Name(GridColumnButtonName.Edit);
                    b.Add().Name(GridColumnButtonName.Delete);
                });
        })
         .DataSource(ds => ds.Mvc()
             .Controller("ApproDemandeAchats")
             .LoadAction("GetBons")
             .InsertAction("PostBons")
             .DeleteAction("DeleteBons")
             .UpdateAction("PutBons")
             .Key("NumBon")
             .LoadParams(new
             {
                 id = new JS("Bons.id")
             }
             )
            )
        .MasterDetail(md => md
        .Enabled(true)
        .Template(new TemplateName("ArticlesEntrees"))
        )
        .Export(e => e.Enabled(true).AllowExportSelectedData(true))
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(headerfilter => headerfilter.Visible(true))
        .GroupPanel(p => p.Visible(true))
        .AllowColumnReordering(true)
        .AllowColumnResizing(true)
        .OnCellPrepared("receptionCell_prepared")
        .NoDataText("Aucune donnée à afficher")
        .CacheEnabled(true)
        .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
        .RemoteOperations(true)
        .Selection(s => s.Mode(SelectionMode.Multiple))
        .Editing(editing =>
        {
            editing.AllowUpdating(true);
            editing.AllowDeleting(true);
            editing.AllowAdding(true);
            editing.Mode(GridEditMode.Popup)
            .Popup(p => p.Title("Editer Demande")
            .ShowTitle(true)
            .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
        })
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 250 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 255 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesEntrees"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 257 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Articles Entrees")
                .Template(new TemplateName("ArticlesEntreesGrid"))
                .Option("ArticlesEntrees", new { id = new JS("data.NumBon") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 265 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
         
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 269 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesEntreesGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 271 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproArticlesEntres>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(false))
        .Columns(columns =>
        {
            columns.AddFor(m => m.NumBon).Caption("#Bon");
            columns.AddFor(m => m.DesignationArticle).Caption("Designation Article")
            .Lookup(lookup => lookup
            .DataSource(ds => ds.Mvc()
            .Controller("ApproDemandeAchats")
            .LoadAction("DesignationArticlesDeamndeLookup")
            .LoadParams(new
            {
                id = new JS("ArticlesEntrees.id")
            }
            )
            .Key("Value"))
            .ValueExpr("Value")
            .DisplayExpr("Text")

            );
            columns.AddFor(m => m.Qte).Caption("QTE");


            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b =>
                {
                    b.Add().Name(GridColumnButtonName.Edit);
                    b.Add().Name(GridColumnButtonName.Delete);
                });
        })
         .DataSource(ds => ds.Mvc()
             .Controller("ApproDemandeAchats")
             .LoadAction("GetArticlesEntres")
             .InsertAction("PostArticleEntres")
             .DeleteAction("DeleteArticlesEntres")
             .UpdateAction("PutArticlesEntres")
             .Key("Id")
             .LoadParams(new
             {
                 id = new JS("ArticlesEntrees.id")
             }
             )
            )
        .Export(e => e.Enabled(true).AllowExportSelectedData(true))
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(headerfilter => headerfilter.Visible(true))
        .GroupPanel(p => p.Visible(true))
        .AllowColumnReordering(true)
        .AllowColumnResizing(true)
        .OnCellPrepared("receptionCell_prepared")
        .NoDataText("Aucune donnée à afficher")
        .CacheEnabled(true)
        .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
        .RemoteOperations(true)
        .Selection(s => s.Mode(SelectionMode.Multiple))
        .Editing(editing =>
        {
            editing.AllowUpdating(true);
            editing.AllowDeleting(true);
            editing.AllowAdding(true);
            editing.Mode(GridEditMode.Popup)
            .Popup(p => p.Title("Editer Demande")
            .ShowTitle(true)
            .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
        })
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 339 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>

        function refreshButton_click() {
         DevExpress.ui.notify(""Rafraichissement en cours!"");
            var demandesTravailGrid = $(""#DemandesAchats"").dxDataGrid(""instance"");
         var demandesTravailDS = demandesTravailGrid.getDataSource();
         demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
         demandesTravailDS.reload();
         demandesTravailGrid.refresh();
         demandesTravailGrid.endCustomLoading();
        }

        function addButton_click() {
            DevExpress.ui.notify(""Ajouter une demande!"");
            window.location.href = '");
#nullable restore
#line 355 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
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
                    $links.filter("".dx-lin");
            WriteLiteral(@"k-edit"").addClass(""dx-icon-edit"");
                    $links.filter("".dx-link-delete"").addClass(""dx-icon-trash"");
                }
            }
        }

        var imprimerDemandeTravail = function (e) {
            var num = e.row.data.NumDt;

               window.location.href = ' ");
#nullable restore
#line 387 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ApprovisionnementManager\Views\ApprovisionnementManager\SuiviAchats.cshtml"
                                   Write(Url.Action("DemandeTravailViewer"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
         }

        var docViewer;
        function GetDocumentViewer(s, e) {
            docViewer = s;
        }

        function BuildOnClick() {
            var parameterValue = 2;
            docViewer.GetParametersModel()[""NumDt""](parameterValue);
            docViewer.StartBuild();
        }

        function GoToLastPage(s, e) {
            s.GoToPage(e.PageCount - 1);
        }

        function WebDocumentViewerInit(s, e) {
            var parametersModel = s.GetParametersModel();
            if (!parametersModel) { return; }
            var serializeParametersOriginal = parametersModel.serializeParameters;
            parametersModel.serializeParameters = function () {
                var serializedParameters = serializeParametersOriginal.apply(parametersModel);
                var reportParameter = serializedParameters.filter(function (p) { return p.Key === ""MyParameterName"" })[0];
                if (reportParameter) {
                    reportParameter.Value = ""my ");
            WriteLiteral("custom parameter value\";\r\n                }\r\n                return serializedParameters;\r\n            }\r\n        }\r\n</script>");
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