#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83a16508cb8ef2790f5808cd2badeafcf5821586"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MethodeManager_Views_MethodeManager_CheckList), @"mvc.1.0.view", @"/Areas/MethodeManager/Views/MethodeManager/CheckList.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83a16508cb8ef2790f5808cd2badeafcf5821586", @"/Areas/MethodeManager/Views/MethodeManager/CheckList.cshtml")]
    public class Areas_MethodeManager_Views_MethodeManager_CheckList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
  
    ViewData["Title"] = "Méthode-CheckList control maintenance";
    Layout = "~/Views/Shared/_LayoutMethodeManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
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
#line 37 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.MaintPointControlMaster>()
 .DataSource(ds => ds.Mvc()
     .Controller("MaintPointControlMasters")
     .LoadAction("GetSuivi")
     .UpdateAction("Put")
     .DeleteAction("Delete")
     .InsertAction("PostCheckList")
     .Key("NumCheckList")
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
     columns.AddFor(m => m.CodeService)
                .Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("MaintPointControlMasters").LoadAction("StructureLookup").Key("Value"))
                .AllowClearing(true)
                .ValueExpr("Value")
                .DisplayExpr("Text"));
     columns.AddFor(m => m.Date)
             .DataType(GridColumnDataType.DateTime)
             .Format("yyyy-MM-dd HH:mm")
             .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.AddFor(m => m.DateDebut)
             .DataType(GridColumnDataType.DateTime)
             .Format("yyyy-MM-dd HH:mm")
             .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.AddFor(m => m.DateFin)
             .DataType(GridColumnDataType.DateTime)
             .Format("yyyy-MM-dd HH:mm")
             .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b => {
        b.Add().Name(GridColumnButtonName.Edit);
        b.Add().Name(GridColumnButtonName.Delete);
        b.Add()
                .Hint("Imprimer demande service")
                .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerCheckList");
    PopWriter();
}
))
                .Icon("print");
        });
 })
.MasterDetail(md => md
    .Enabled(true)
    .Template(new TemplateName("CheckListDetails")))
   .Editing(editing =>
   {
       editing.AllowUpdating(true);
       editing.AllowDeleting(true);
       editing.AllowAdding(true);
       editing.Mode(GridEditMode.Row);
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
            WriteLiteral("\r\n");
#nullable restore
#line 107 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
 using (Html.DevExtreme().NamedTemplate("CheckListDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 109 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Visites")
                .Template(new TemplateName("CheckListDetailsGrid"))
                .Option("CheckListDetailsGrid", new { NumCheckList = new JS("data.NumCheckList") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
 using (Html.DevExtreme().NamedTemplate("CheckListDetailsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.MaintPointControleDetail>()
            .DataSource(ds => ds.Mvc()
            .Controller("MaintPointControlMasters")
            .LoadAction("GetDetails")
            .UpdateAction("PutDetail")
            .Key("Id")
            .LoadParams(new
            {
                NumCheckList = new JS("CheckListDetailsGrid.NumCheckList")
            }
            )
            )
            .RemoteOperations(true)
            .NoDataText("Aucune donnée à afficher")
            .CacheEnabled(true)
            .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
            .Columns(columns => {
                columns.AddFor(m => m.CodeMachine).Caption("Designation")
                .Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("MaintPointControlMasters").LoadAction("DesignationLookup").Key("Value"))
                .AllowClearing(true)
                .ValueExpr("Value")
                .DisplayExpr("Text"))
                .EditCellTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                ");
#nullable restore
#line 145 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
           Write(Html.Partial("DxDropDownBoxMachine"));

#line default
#line hidden
#nullable disable
    WriteLiteral("\r\n                ");
    PopWriter();
}
)).AllowGrouping(true);

                columns.AddFor(m => m.Dimanche);
                columns.AddFor(m => m.Lundi);
                columns.AddFor(m => m.Mardi);
                columns.AddFor(m => m.Mercredi);
                columns.AddFor(m => m.Jeudi);
                columns.AddFor(m => m.Vendredi);
                columns.AddFor(m => m.Samedi);
                columns.AddFor(m => m.Observation);
                columns.Add()
                    .Type(GridCommandColumnType.Buttons)
                    .Width(110)
                    .Buttons(b => {
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
        editing.AllowDeleting(false);
        editing.AllowAdding(false);
    })
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 181 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 183 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
Write(Html.DevExtreme().Popup()
.ID("AddOt-popup")
.ShowTitle(true)
.Title("Ajouter un Ordre de travail")
.Visible(false)
.DragEnabled(false)
.CloseOnOutsideClick(true)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 191 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
 using (Html.DevExtreme().NamedTemplate("EditerOrdre"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 193 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
     using (Html.BeginForm("Post_Ot_From_Ot_Sent_With_Form_Methodes", "AssOtTraveaux", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 195 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
    Write(Html.DevExtreme().Form<EditerOrdreTravailModel>()
        .ShowValidationSummary(true)
        .Items(items =>
        {
            items.AddGroup()
                    .ColCount(2)
                    .Items(groupItems =>
                    {
                        groupItems.AddGroup().Items(secondGroupItems =>
                        {
                            secondGroupItems.AddSimpleFor(m => m.CodeReceveur).Editor(e => e.Lookup()
                            .DataSource(ds => ds.WebApi().Controller("OrdreTravails").LoadAction("StructureLookup").Key("Value"))
                            .ValueExpr("Value")
                            .DisplayExpr("Text")
                            .ShowClearButton(true)
                            );
                        }).ColSpan(2);
                        groupItems.AddGroup().Items(secondGroupItems => {
                            secondGroupItems.AddSimpleFor(m => m.CodeMaintenance).Editor(e => e.Lookup()
                            .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("TypeMaintenanceErrorLookup").Key("Value"))
                            .ValueExpr("Value")
                            .DisplayExpr("Text")
                            .ShowClearButton(true)
                            );
                            secondGroupItems.AddSimpleFor(m => m.DateOt).Editor(e => e.DateBox()
                            .DateSerializationFormat("yyyy-MM-dd")
                            .Type(DateBoxType.DateTime));
                        });
                        groupItems.AddGroup().Items(secondGroupItems =>
                        {
                            secondGroupItems.AddSimpleFor(m => m.NumEquipement).Editor(e => e.Lookup()
                            .DataSource(ds => ds.WebApi().Controller("OrdreTravails").LoadAction("EquipementsLookup").Key("Value"))
                            .ValueExpr("Value")
                            .DisplayExpr("Text")
                            .ShowClearButton(true)
                            );

                            secondGroupItems.AddSimpleFor(m => m.HeureInstallation).Editor(e => e.DateBox()
                            .DateSerializationFormat("yyyy-MM-dd HH:mm")
                            .Type(DateBoxType.DateTime));
                        });

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
#line 246 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
    Write(Html.DevExtreme().TabPanel()
        .ID("TravauxTab")
        .Items(items =>
        {
            items.Add()
                .Title("Travaux")
                .Template(new TemplateName("TachesOtAddGrid"));
            items.Add()
                .Title("Outillage")
                .Template(new TemplateName("OutillageGrid"));
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 257 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
         

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 259 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 261 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
 using (Html.DevExtreme().NamedTemplate("TachesOtAddGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 263 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.TempAssOtTravaux>()
            .DataSource(ds => ds.Mvc()
            .Controller("TempAssOtTravaux")
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
            columns.AddFor(m => m.CodeEquipement).Caption("Equipement")
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("EquipementsLookup").Key("Value"))
            .AllowClearing(true)
            .ValueExpr("Value")
            .DisplayExpr("Text")
            );
            columns.AddFor(m => m.CodeMachine).Caption("Machine")
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("MachinesLookup").Key("Value"))
            .AllowClearing(true)
            .ValueExpr("Value")
            .DisplayExpr("Text")
            );
            columns.AddFor(m => m.Qte);
            columns.AddFor(m => m.TypeTraveaux).Caption("Travail")
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("AssOtTraveaux").LoadAction("TypeTraveauxLookup").Key("Value"))
            .AllowClearing(true)
            .ValueExpr("Value")
            .DisplayExpr("Text")
            );
            columns.AddFor(m => m.Autres);
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
#line 315 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
             
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
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
        if (e.rowType === ""data"" && e.column.command");
            WriteLiteral(@" === ""edit"") {
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
    var imprimerCheckList= function (e) {
        var NumCheckList = e.row.data.NumCheckList;
        window.open(' ");
#nullable restore
#line 352 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\CheckList.cshtml"
                 Write(Url.Action("CheckListViewer", "MethodeManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?NumCheckList=\' + NumCheckList, \'_blank\').focus();\r\n    }\r\n    var ShowOt = function (e) {\r\n        var popup = $(\"#AddOt-popup\").dxPopup(\"instance\");\r\n        popup.option(\"contentTemplate\", $(\"#EditerOrdre\"));\r\n        popup.show();\r\n    }\r\n</script>");
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
