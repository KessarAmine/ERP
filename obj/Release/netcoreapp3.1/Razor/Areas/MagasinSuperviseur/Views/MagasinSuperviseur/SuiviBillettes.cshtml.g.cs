#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4314745f8d32c576c866c59e214a7c216b16eb2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinSuperviseur_Views_MagasinSuperviseur_SuiviBillettes), @"mvc.1.0.view", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/SuiviBillettes.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4314745f8d32c576c866c59e214a7c216b16eb2c", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/SuiviBillettes.cshtml")]
    public class Areas_MagasinSuperviseur_Views_MagasinSuperviseur_SuiviBillettes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
  
    ViewData["Title"] = "Magasin-Suivi Billettes";
    Layout = "~/Views/Shared/_LayoutMagasinSuperviseur.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().Toolbar()
    .Items(items =>
    {
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
#line 29 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Height("100%")
        .Items(items =>
        {
            items.Add()
                .Title("Reception")
                .Template(new TemplateName("ReceptionGrid"));
            items.Add()
                .Title("Transfert")
                .Template(new TemplateName("TransfertGrid"));
            items.Add()
                .Title("Récap")
                .Template(new TemplateName("RécapGrid"));
        })
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 45 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 using (Html.DevExtreme().NamedTemplate("ReceptionGrid"))
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
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
#nullable restore
#line 63 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkReceptionBillette>()
    .ID("ReceptionGrid")
    .DataSource(ds => ds.Mvc()
        .Controller("Bilettes")
        .LoadAction("GetReceptionBillettes")
        .InsertAction("PostReceptionBillette")
        .UpdateAction("PutReceptionBillette")
        .DeleteAction("DeleteReceptionBillette")
        .Key("NumReception")
        .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
    )
    .Scrolling(scrolling => scrolling
    .ScrollByContent(true)
    .ShowScrollbar(ShowScrollbarMode.Always))
    .Height("90%")
    .OnRowExpanding("CollpaseAll")
    .OnRowExpanded("refreshButton_click")
    .RemoteOperations(true)
    .Columns(columns => {

        columns.AddFor(m => m.DateReception).Format("yyyy-MM-dd")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
        columns.AddFor(m => m.BilleteRecue);
        columns.AddFor(m => m.Navire);
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
    WriteLiteral("imprimerReceptionBillette");
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
        editing.Mode(GridEditMode.Form);
    })
    .MasterDetail(md => md
    .Enabled(true)
    .Template(new TemplateName("ReceptionGridDetails"))
    )
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
#line 119 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 using (Html.DevExtreme().NamedTemplate("ReceptionGridDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Détails")
                .Template(new TemplateName("ReceptionGridDetailsGrid"))
                .Option("ReceptionGridDetailsGrid", new { id = new JS("data.NumReception") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 131 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 using (Html.DevExtreme().NamedTemplate("ReceptionGridDetailsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 135 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkReceptionBilletteDetails>()
    .DataSource(ds => ds.Mvc()
        .Controller("Bilettes")
        .LoadAction("GetReceptionBillettesDetails")
        .InsertAction("PostReceptionBilletteDetails")
        .UpdateAction("PutReceptionBilletteDetails")
        .DeleteAction("DeleteReceptionBilletteDetails")
        .Key("Id")
        .LoadParams(new
        {
            id = new JS("ReceptionGridDetailsGrid.id")
        })
    )
    .Columns(columns => {

        columns.AddFor(m => m.NumBon);
        columns.AddFor(m => m.NumImRemorque);
        columns.AddFor(m => m.NumImTracteur);
        columns.AddFor(m => m.NbrFdx);
        columns.AddFor(m => m.NbrPieces);
        columns.AddFor(m => m.NetPoidTh);

        columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b =>
        {
            b.Add().Name(GridColumnButtonName.Edit).Icon("edit");
            b.Add().Name(GridColumnButtonName.Delete).Icon("trash");
        });
    })
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
   .Selection(s => s.Mode(SelectionMode.Multiple))
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 180 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 183 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 using (Html.DevExtreme().NamedTemplate("TransfertGrid"))
{

#line default
#line hidden
#nullable disable
#nullable restore
#line 184 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().Toolbar()
    .Items(items =>
    {
        items.Add()
           .Widget(w => w
           .Button()
           .Icon("refresh")
           .OnClick("refreshButton_click2")
       )
       .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
       .Location(ToolbarItemLocation.Before);

    }
    )
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 199 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkRapportTransfertBillette>()
        .ID("TransfertGrid")
    .DataSource(ds => ds.Mvc()
        .Controller("Bilettes")
        .LoadAction("GetTransfertBillettes")
        .InsertAction("PostTransfertBillette")
        .UpdateAction("PutTransfertBillette")
        .DeleteAction("DeleteTransfertBillette")
        .Key("NumRapportTransfert")
        .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
    )
.OnRowExpanding("CollpaseAll")
.OnRowExpanded("refreshButton_click")
    .Scrolling(scrolling => scrolling
    .ScrollByContent(true)
    .ShowScrollbar(ShowScrollbarMode.Always))
    .Height("90%")
    .RemoteOperations(true)
    .Columns(columns => {

        columns.AddFor(m => m.DateTransfert).Format("d/M/yyyy")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
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
    WriteLiteral("imprimerTransfertBillette");
    PopWriter();
}
))
            .Icon("print");
        });

    })
   .ColumnChooser(cc => cc.Enabled(true).AllowSearch(true))
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
    .MasterDetail(md => md
    .Enabled(true)
    .Template(new TemplateName("TransfertGridDetails"))
    )
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 255 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 257 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 using (Html.DevExtreme().NamedTemplate("TransfertGridDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 259 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Détails")
                .Template(new TemplateName("TransfertGridDetailsGrid"))
                .Option("TransfertGridDetailsGrid", new { id = new JS("data.NumRapportTransfert") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 267 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 269 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 using (Html.DevExtreme().NamedTemplate("TransfertGridDetailsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 271 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkRapportTransfertBillettesDetails>()
    .DataSource(ds => ds.Mvc()
        .Controller("Bilettes")
        .LoadAction("GetTransfertBillettesDetails")
        .InsertAction("PostTransfertBilletteDetails")
        .UpdateAction("PutTransfertBilletteDetails")
        .DeleteAction("DeleteTransfertBilletteDetails")
        .Key("Id")
        .LoadParams(new
        {
            id = new JS("TransfertGridDetailsGrid.id")
        })
    )
    .Columns(columns => {
        columns.AddFor(m => m.HeureTransfert).Format("yyyy-MM-dd HH:mm")
        .DataType(GridColumnDataType.DateTime)
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
        columns.AddFor(m => m.Billette);
        columns.AddFor(m => m.NbrFdx);
        columns.AddFor(m => m.NbrPieces);
        columns.AddFor(m => m.Observation);
        columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b =>
        {
            b.Add().Name(GridColumnButtonName.Edit);
            b.Add().Name(GridColumnButtonName.Delete);
        });
    })
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
   .Selection(s => s.Mode(SelectionMode.Multiple))
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 315 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 318 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 using (Html.DevExtreme().NamedTemplate("RécapGrid"))
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 321 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().Toolbar()
    .Items(items =>
    {
        items.Add()
           .Widget(w => w
           .Button()
           .Icon("refresh")
           .OnClick("refreshButton_click3")
       )
       .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
       .Location(ToolbarItemLocation.Before);
        items.Add()
        .Widget(w => w.Button()
            .Icon("fas fa-clipboard-list")
            .OnClick("imprimerRecapeBillette")
            .Hint("Imprimier Récape"))

        .LocateInMenu(ToolbarItemLocateInMenuMode.Auto)
        .Location(ToolbarItemLocation.Before);
    }
    )
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 343 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
Write(Html.DevExtreme().DataGrid < DevKbfSteel.Areas.MagasinManager.Models.RecapBillettesModel>()
    .ID("RécapGrid")
    .DataSource(ds => ds.Mvc()
        .Controller("Bilettes")
        .LoadAction("GetRecapBillettes")
        .Key("Date")
        .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
    )
    .Scrolling(scrolling => scrolling
    .ScrollByContent(true)
    .ShowScrollbar(ShowScrollbarMode.Always))
    .Height("90%")
    .RemoteOperations(true)
    .Columns(columns => {

        columns.AddFor(m => m.Date).Format("yyyy-MM-dd")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
        columns.AddFor(m => m.Navire);
        columns.AddFor(m => m.NbrFdx);
        columns.AddFor(m => m.NbrPieces);
        columns.AddFor(m => m.NbrRotations);
        columns.AddFor(m => m.Tonnage);
        columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b =>
        {
            b.Add()
            .Hint("Imprimer")
            .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerRecapeBillette");
    PopWriter();
}
))
            .Icon("print");
        });
    })
    .Editing(editing =>
    {
        editing.AllowUpdating(false);
        editing.AllowDeleting(false);
        editing.AllowAdding(false);
        editing.Mode(GridEditMode.Form);
    })
    .Summary(s => s.TotalItems(items =>
    {
        items.AddFor(m => m.NbrFdx)
            .SummaryType(SummaryType.Sum)
            .ShowInColumn("NbrFdx")
            .DisplayFormat("Total : {0}");
        items.AddFor(m => m.Tonnage)
            .SummaryType(SummaryType.Sum)
            .ShowInColumn("Tonnage")
            .DisplayFormat("Total : {0}");
        items.AddFor(m => m.NbrRotations)
            .SummaryType(SummaryType.Sum)
            .ShowInColumn("NbrRotations")
            .DisplayFormat("Total : {0}");
        items.AddFor(m => m.NbrPieces)
            .SummaryType(SummaryType.Sum)
            .ShowInColumn("NbrPieces")
            .DisplayFormat("Total : {0}");
    }))
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
#line 410 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
 
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>

    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#ReceptionGrid"").dxDataGrid(""instance"");
        var demandesTravailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();
        demandesTravailGrid.endCustomLoading();
    }
    function refreshButton_click2() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#TransfertGrid"").dxDataGrid(""instance"");
        var demandesTravailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();
        demandesTravailGrid.endCustomLoading();
    }
    function CollpaseAll(e) {
        e.component.collapseAll(-1);
    }

    function refres");
            WriteLiteral(@"hButton_click3() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#RécapGrid"").dxDataGrid(""instance"");
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
#line 448 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
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
    console.log(e.rowType.data)
    if (e.rowType === ""data"" && e.column.command === ""edit"") {
        var isEditing = e.row.isEditing, $links = e.cellElement.find("".dx-link"");
        $links.text("""");
        if (isEditing) {
            $links.filter("".dx-link-save"").addClass(""dx-icon-save"");
            $links.filter("".dx-link-cancel"").addClass(""dx-icon-revert"");
        } else {
            $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
            $links.filter("".dx-link-delete""");
            WriteLiteral(").addClass(\"dx-icon-trash\");\r\n        }\r\n    }\r\n    }\r\n    var imprimerReceptionBillette = function (e) {\r\n        var num = e.row.data.NumReception;\r\n        window.open(\' ");
#nullable restore
#line 479 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
                 Write(Url.Action("ReceptionBilletteViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n        }\r\n    var imprimerTransfertBillette = function (e) {\r\n        var num = e.row.data.NumRapportTransfert;\r\n        window.open(\' ");
#nullable restore
#line 483 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
                 Write(Url.Action("TransfertBilletteViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?id='+num, '_blank').focus();
        }
    var imprimerRecapeBillette = function (e) {
    var Datedebut = $(""#FilterDateDebut"").dxDateBox(""instance"").option(""text"");
    var Datefin = $(""#FilterDateFin"").dxDateBox(""instance"").option(""text"");
    window.open(' ");
#nullable restore
#line 488 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\SuiviBillettes.cshtml"
             Write(Url.Action("RecapeBilletteViewer", "MagasinSuperviseur"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?Datedebut=\' + Datedebut + \'&Datefin=\' + Datefin,\'_blank\').focus();\r\n    }\r\n</script>\r\n");
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