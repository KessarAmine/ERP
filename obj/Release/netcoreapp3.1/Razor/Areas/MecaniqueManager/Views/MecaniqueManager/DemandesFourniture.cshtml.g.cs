#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a90f51fa1fff4e764b27a893e7a941787fefde68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MecaniqueManager_Views_MecaniqueManager_DemandesFourniture), @"mvc.1.0.view", @"/Areas/MecaniqueManager/Views/MecaniqueManager/DemandesFourniture.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a90f51fa1fff4e764b27a893e7a941787fefde68", @"/Areas/MecaniqueManager/Views/MecaniqueManager/DemandesFourniture.cshtml")]
    public class Areas_MecaniqueManager_Views_MecaniqueManager_DemandesFourniture : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
  
    ViewData["Title"] = "Mécanique-Demandes Fournitures";
    Layout = "~/Views/Shared/_LayoutMecaniqueManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
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
#line 38 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproDemandesFourniture>()
 .DataSource(ds => ds.Mvc()
     .Controller("ApproDemandesFournitures")
     .LoadAction("GetFourniture")
     .UpdateAction("Put")
     .DeleteAction("Delete")
     .Key("NumeroDemande")
     .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value"), structure = XpertHelper.CodeMecanqiue }))

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

     columns.AddFor(m => m.DateDemande)
     .Format("yyyy-MM-dd HH:mm")
     .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

     columns.AddFor(m => m.DateBesoin)
     .Format("yyyy-MM-dd HH:mm")
     .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

     columns.AddFor(m => m.Status).AllowEditing(false).Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("ApproDemandesFournitures").LoadAction("StatusLookup").Key("Value"))
    .AllowClearing(true)
    .ValueExpr("Value")
    .DisplayExpr("Text")
    );
     columns.AddFor(m => m.Obeservations);

     columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b => {
        b.Add().Name(GridColumnButtonName.Edit);
        b.Add().Name(GridColumnButtonName.Delete);
        b.Add()
                .Hint("Imprimer demande fourniture")
                .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerDemandeFourniture");
    PopWriter();
}
))
                .Icon("print");
        });
 })
.MasterDetail(md => md
    .Enabled(true)
    .Template(new TemplateName("DemandeFournitureDetails")))
   .Editing(editing =>
   {
       editing.AllowUpdating(true);
       editing.AllowDeleting(true);
       editing.AllowAdding(false);
       editing.Mode(GridEditMode.Popup)
        .Popup(p => p.Title("Editer Demande")
        .ShowTitle(true)
        .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
   })
   .Export(e => e.Enabled(true).AllowExportSelectedData(true))
   .FilterRow(f => f.Visible(true))
   .HeaderFilter(headerfilter => headerfilter.Visible(true))
   .GroupPanel(p => p.Visible(true))
   .AllowColumnReordering(true)
   .AllowColumnResizing(true)
   .OnToolbarPreparing("toolbar_preparing")
   .OnCellPrepared("receptionCell_prepared")
   .Selection(s => s.Mode(SelectionMode.Multiple))
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 116 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
Write(Html.DevExtreme().Popup()
.ID("Add-popup")
.ShowTitle(true)
.Title("Ajouter une demande fourniture")
.Visible(false)
.DragEnabled(false)
.CloseOnOutsideClick(true)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 124 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
Write(Html.DevExtreme().Popup()
.ID("AddArticle-popup")
.ShowTitle(true)
.Title("Ajouter un Article")
.Visible(false)
.DragEnabled(false)
.CloseOnOutsideClick(true)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 132 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
 using (Html.DevExtreme().NamedTemplate("EditerArticle"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 134 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
     using (Html.BeginForm("Post_Article_Detail_With_Form_Mecanique", "ApproDemandesFournitures", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
    Write(Html.DevExtreme().Form<AjouterArticleFournitureModel>()
        .ShowValidationSummary(true)
        .Items(items =>
        {
            items.AddGroup()
            .ColCount(2)
                    .Items(groupItems =>
                    {
                        groupItems.AddGroup().Items(secondGroupItems => {
                            secondGroupItems.AddSimpleFor(m => m.CodeArticle).Editor(e => e.DropDownBox()
                            .ValueExpr("CodePdr")
                            .DisplayExpr("DesignationPdr")
                            .DataSource(d => d.Mvc()
                            .Controller("ApproFournituresArticles")
                            .LoadAction("GetPdr")
                            .LoadMode(DataSourceLoadMode.Raw)
                            .Key("CodePdr"))
                            .Placeholder("Select a value...")
                            .ShowClearButton(true)
                            .OnValueChanged(@"function(args) { gridBox_valueChanged(args, setValue); }")
                            .ContentTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                                ");
#nullable restore
#line 157 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
                            Write(Html.DevExtreme().DataGrid()
                                        .ID("embedded-datagridMultipleIdEmployee")
                                        .DataSource(new JS(@"component.getDataSource()"))
                                        .Columns(columns =>
                                        {
                                            columns.Add().DataField("CodePdr");
                                            columns.Add().DataField("DesignationPdr");
                                            columns.Add().DataField("CodeUniteMesure").Lookup(lookup => lookup
                                            .DataSource(ds => ds.WebApi().Controller("ApproDemandesFournitures").LoadAction("CodeUniteMesureLookup").Key("Value"))
                                            .ValueExpr("Value")
                                            .DisplayExpr("Text")
                                            .AllowClearing(true)
                                            );
                                        })
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
    WriteLiteral("\r\n                                ");
#nullable restore
#line 180 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
                            Write(Html.DevExtreme().Button()
                                         .ElementAttr(new { style = "margin-top:10px;float:right" })
                                         .Text("Close")
                                         .OnClick(@"function(args) { onCloseBtnClick(args, component); }"));

#line default
#line hidden
#nullable disable
    WriteLiteral("\r\n                            ");
    PopWriter();
}
)));
                        }).ColSpan(2);
                        groupItems.AddGroup().Items(secondGroupItems =>
                        {
                            secondGroupItems.AddSimpleFor(m => m.ArticleNonGere);
                        }).ColSpan(1);
                        groupItems.AddGroup().Items(secondGroupItems =>
                        {
                            secondGroupItems.AddSimpleFor(m => m.Qte);
                        }).ColSpan(1);
                    });
            items.AddButton()
            .HorizontalAlignment(HorizontalAlignment.Right)
            .ButtonOptions(b => b.Text("Enregistrer")
                .Type(ButtonType.Success)
                .UseSubmitBehavior(true)
            );
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 202 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 203 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 205 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
 using (Html.DevExtreme().NamedTemplate("EditerDemande"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 207 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
     using (Html.BeginForm("Post_Demande_From_With_Form_Mecanique", "ApproDemandesFournitures", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 209 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
    Write(Html.DevExtreme().Form<DemandeFournitureModel>()
        .ShowValidationSummary(true)
        .Items(items =>
        {
            items.AddGroup()
                    .ColCount(2)
                    .Items(groupItems =>
                    {
                        groupItems.AddGroup().Items(secondGroupItems => {
                            secondGroupItems.AddSimpleFor(m => m.DateDemande).Editor(e => e.DateBox()
                            .DateSerializationFormat("yyyy-MM-dd HH:mm")
                            .Type(DateBoxType.DateTime));
                            secondGroupItems.AddSimpleFor(m => m.DateBesoin).Editor(e => e.DateBox()
                            .DateSerializationFormat("yyyy-MM-dd HH:mm")
                            .Type(DateBoxType.DateTime));
                        });
                        groupItems.AddGroup().Items(secondGroupItems =>
                        {
                            secondGroupItems.AddSimpleFor(m => m.Obeservations);
                        }).ColSpan(2);
                    });
            items.AddButton()
            .HorizontalAlignment(HorizontalAlignment.Right)
            .ButtonOptions(b => b.Text("Enregistrer")
                .Type(ButtonType.Success)
                .UseSubmitBehavior(true)
            );
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 238 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
    Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Articles")
                .Template(new TemplateName("ArticlesGrid"));
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 245 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
         

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 247 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 249 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 251 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.TempApproArticlesDemandes>()
            .DataSource(ds => ds.Mvc()
            .Controller("TempApproArticlesDemandes")
            .LoadAction("Get")
            .InsertAction("Post")
            .UpdateAction("Put")
            .DeleteAction("Delete")
            .Key("Id"))
            .RemoteOperations(true)
            .NoDataText("Aucune donnée à afficher")
            .CacheEnabled(true)
            .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
            .Columns(columns => {
                columns.AddFor(m => m.CodeArticle).Caption("PDR")
                .Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("TempApproArticlesDemandes").LoadAction("PdrLookup").Key("Value"))
                .AllowClearing(true)
                .ValueExpr("Value")
                .DisplayExpr("Text")
                );
                columns.AddFor(m => m.ArticleNonGere);
                columns.AddFor(m => m.Qte);
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
                editing.AllowAdding(true);
                editing.Mode(GridEditMode.Row);
            })
            );

#line default
#line hidden
#nullable disable
#nullable restore
#line 289 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
             
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 291 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
 using (Html.DevExtreme().NamedTemplate("DemandeFournitureDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 293 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Articles demandés")
                .Template(new TemplateName("ArticlesDemandesGrid"))
                .Option("ArticlesDemandesGrid", new { id = new JS("data.NumeroDemande") });

        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 302 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 304 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesDemandesGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 306 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproFournituresArticles>()
            .DataSource(ds => ds.Mvc()
            .Controller("ApproDemandesFournitures")
            .LoadAction("GetFournitureArticles")
            .DeleteAction("DeleteArticle")
            .UpdateAction("PutArticle")
            .Key("Id")
            .LoadParams(new
            {
                id = new JS("ArticlesDemandesGrid.id")
            }
            )
            )
            .RemoteOperations(true)
            .NoDataText("Aucune donnée à afficher")
            .CacheEnabled(true)
            .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
            .Columns(columns => {
                columns.AddFor(m => m.CodeArticle);
                columns.AddFor(m => m.DesignationArticle)
                .EditCellTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral(" ");
#nullable restore
#line 326 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
                                     Write(Html.Partial("DxDropDownBoxArticlesFourniture"));

#line default
#line hidden
#nullable disable
    WriteLiteral(" ");
    PopWriter();
}
));
                columns.AddFor(m => m.CodeUniteMesure).Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("ApproDemandesFournitures").LoadAction("CodeUniteMesureLookup").Key("Value"))
                .ValueExpr("Value")
                .DisplayExpr("Text")
                .AllowClearing(true)
                );
                columns.AddFor(m => m.QteDemande);
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
   .OnToolbarPreparing("toolbar_preparingArticlesGrid")
   .Selection(s => s.Mode(SelectionMode.Multiple))
   .Editing(editing =>
   {
       editing.AllowUpdating(false);
       editing.AllowDeleting(true);
       editing.AllowAdding(false);
       editing.Mode(GridEditMode.Row);
   })
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 354 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
 
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
        var demandesTravailGrid = $(""#demandesTravailGrid"").dxDataGrid(""instance"");
        var dem");
            WriteLiteral(@"andesTravailDS = demandesTravailGrid.getDataSource();
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
                $links.filter("".dx-link-save"")");
            WriteLiteral(@".addClass(""dx-icon-save"");
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
#line 413 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DemandesFourniture.cshtml"
                 Write(Url.Action("DemandeFournitureViewer", "MecaniqueManager"));

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
    function toolbar_preparing(e) {
        var dataGrid = e.component;

        e.toolbarOptions.items.unshift({
            location: ""after"",
            widget: ""dxButton"",
            options: {
                icon: ""plus"",
                width: 34,
                onClick: function (e) {
                    var popup = $(""#Add-popup"").dxPopup(""instance"");
              ");
            WriteLiteral(@"      popup.option(""contentTemplate"", $(""#EditerDemande""));
                    popup.show();
                }
            }
        });
    }
    function toolbar_preparingArticlesGrid(e) {
        var dataGrid = e.component;
        e.toolbarOptions.items.unshift({
            location: ""after"",
            widget: ""dxButton"",
            options: {
                icon: ""plus"",
                width: 34,
                onClick: function (e) {
                    var popup = $(""#AddArticle-popup"").dxPopup(""instance"");
                    popup.option(""contentTemplate"", $(""#EditerArticle""));
                    popup.show();
                }
            }
        });
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