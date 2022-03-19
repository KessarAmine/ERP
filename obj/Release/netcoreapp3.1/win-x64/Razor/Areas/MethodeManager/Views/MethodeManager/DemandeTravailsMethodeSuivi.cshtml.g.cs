#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a1f30b5d6aca66220122f18fd04ecc4647b46a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MethodeManager_Views_MethodeManager_DemandeTravailsMethodeSuivi), @"mvc.1.0.view", @"/Areas/MethodeManager/Views/MethodeManager/DemandeTravailsMethodeSuivi.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a1f30b5d6aca66220122f18fd04ecc4647b46a7", @"/Areas/MethodeManager/Views/MethodeManager/DemandeTravailsMethodeSuivi.cshtml")]
    public class Areas_MethodeManager_Views_MethodeManager_DemandeTravailsMethodeSuivi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
  
    ViewData["Title"] = "Méthode-Suivi Demandes Travail";
    Layout = "~/Views/Shared/_LayoutMethodeManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
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
            .Widget(w => w.DateBox().Type(DateBoxType.Date).ApplyButtonText("Appliquer").Value(new DateTime(DateTime.Now.Year,DateTime.Now.Month,1)).DisplayFormat("yyyy-MM-dd").ID("FilterDateDebut"))
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
#line 37 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.DemandeTravail>()
 .DataSource(ds => ds.Mvc()
     .Controller("DemandeTravailsMethode")
     .LoadAction("GetSuivi")
     .InsertAction("Post")
     .UpdateAction("Put")
     .DeleteAction("Delete")
     .Key("NumDt")
     .LoadParams(new { dateDebut = new JS("dateDebutBox_value"), dateFin = new JS("dateFinBox_value") })
 )
     .ColumnChooser(cc => cc.Enabled(true).AllowSearch(true))

 .RemoteOperations(true)
 .ID("demandesTravailGrid")
 .NoDataText("Aucune donnée à afficher")
 .CacheEnabled(true)
 .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
 .Columns(columns => {

     columns.AddFor(m => m.NumDt);

     columns.AddFor(m => m.DateDt)
     .Format("yyyy-MM-dd")
     .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
     columns.AddFor(m => m.TravailDemandee);
     columns.AddFor(m => m.Note).Visible(false);
     columns.AddFor(m => m.Journee).Visible(false);
     columns.AddFor(m => m.Semaine).Visible(false);
     columns.AddFor(m => m.RefMachine).Visible(false).Caption("Installation")
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMethode").LoadAction("MachinesLookup").Key("Value"))
        .AllowClearing(true)
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );
     columns.AddFor(m => m.CodeArret).Visible(false).Caption("Arrêt")
     .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMethode").LoadAction("ArreteProductionLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );
     columns.AddFor(m => m.CodeStructure).Caption("Demandeur")
    .Lookup(lookup => lookup
       .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMethode").LoadAction("StructureLookup").Key("Value"))
       .ValueExpr("Value")
       .DisplayExpr("Text")
       .AllowClearing(true)
       );
     columns.AddFor(m => m.CodeReceveur).Caption("Receveur")
     .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMethode").LoadAction("StructureLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
    );


     columns.AddFor(m => m.CodeStatut).Caption("Statut")
     .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMethode").LoadAction("StatutLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
    );
     columns.AddFor(m => m.CodeUrgence).Visible(false).Caption("Urgence")
     .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("DemandeTravailsMethode").LoadAction("UrgenceTravailleLookup").Key("Value"))
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
    WriteLiteral("imprimerDemandeTravail");
    PopWriter();
}
))
                   .Icon("print");
        });

 })
.Scrolling(scrolling => scrolling
.ScrollByContent(true)
.ShowScrollbar(ShowScrollbarMode.Always)
.Mode(GridScrollingMode.Virtual))
.Height("95%")
.MasterDetail(md => md
.Enabled(true)
.Template(new TemplateName("RapportInterventionDetails"))
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 141 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("RapportInterventionDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 143 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Ordre de travail")
                .Template(new TemplateName("OrdreTravailGrid"))
                .Option("masterGridData", new {idDt = new JS("data.NumDt"),idNumMachine = new JS("data.CodeMachine")});
            items.Add()
                .Title("Rapport Intervention")
                .Template(new TemplateName("RapportInterventionGrid"))
                .Option("masterGridData", new {id = new JS("data.NumDt")});
        })
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 157 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("RapportInterventionGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 159 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.RapportIntervention>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(false))
        .Columns(columns =>
        {
            columns.AddFor(m => m.DateIntervention).Format("yyyy-MM-dd")
            .DataType(GridColumnDataType.DateTime)
            .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
            columns.AddFor(m => m.DebutIntervention).Format("yyyy-MM-dd HH:mm")
            .DataType(GridColumnDataType.DateTime)
            .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
            columns.AddFor(m => m.DureeIntervention);
            columns.AddFor(m => m.CompteRendu);
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
        .Export(e => e.Enabled(true).AllowExportSelectedData(true))
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(headerfilter => headerfilter.Visible(true))
        .GroupPanel(p => p.Visible(true))
        .AllowColumnReordering(true)
        .AllowColumnResizing(true)
        .OnCellPrepared("receptionCell_prepared")
        .Selection(s => s.Mode(SelectionMode.Multiple))
        .MasterDetail(md => md
        .Enabled(true)
        .Template(new TemplateName("IntervenatsDetails"))
        )
        .DataSource(ds => ds.Mvc()
            .Controller("RapportInterventionsMethode")
            .LoadAction("GetDt")
            .Key("NumIntervention")
            .LoadParams(new { id = new JS("masterGridData.id")}))
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 199 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 201 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("OrdreTravailGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 203 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.OrdreTravail>()
    .DataSource(ds => ds.Mvc()
    .Controller("OrdresTravailMethode")
    .LoadAction("GetSentInDt")
    .Key("NumOt")
    .LoadParams(new
    {
        idDt = new JS("masterGridData.idDt"),
        idNumMachine = new JS("masterGridData.idNumMachine")
    }
    )
    )
    .RemoteOperations(true)
    .NoDataText("Aucune donnée à afficher")
    .CacheEnabled(true)
    .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
    .Columns(columns => {
    columns.AddFor(m => m.DateOt)
    .Format("yyyy-MM-dd")
    .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

    columns.AddFor(m => m.HeureInstallation).Format("HH:mm")
    .DataType(GridColumnDataType.DateTime)
    .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));

    columns.AddFor(m => m.CodeMaintenance).Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("OrdresTravailMethode").LoadAction("TypeMaintenanceLookup").Key("Value"))
    .ValueExpr("Value")
    .DisplayExpr("Text")
    .AllowClearing(true)
    );
    columns.AddFor(m => m.NumEquipement).Caption("Equipement")
    .Lookup(lookup => lookup
    .DataSource(ds => ds.WebApi().Controller("OrdresTravailMethode").LoadAction("EquipementsLookup").Key("Value"))
    .AllowClearing(true)
    .ValueExpr("Value")
    .DisplayExpr("Text")
    );
    columns.Add()
    .Type(GridCommandColumnType.Buttons)
    .Width(110)
    .Buttons(b => {
    b.Add().Name(GridColumnButtonName.Edit);
    b.Add().Name(GridColumnButtonName.Delete);
    b.Add()
        .Hint("Imprimer Ordre")
        .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerOrdreTravail");
    PopWriter();
}
))
                           .Icon("print");
    });


    })
    .MasterDetail(md => md
    .Enabled(true)
    .Template(new TemplateName("OrdreTravailDetails"))
    )
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
#nullable restore
#line 268 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 

}

#line default
#line hidden
#nullable disable
#nullable restore
#line 271 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("OrdreTravailDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 273 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Traveaux")
                .Template(new TemplateName("TachesGrid"))
                .Option("TachesGrid", new { id = new JS("data.NumOt")});
            items.Add()
                .Title("Outillage")
                .Template(new TemplateName("OutillageGrid"))
                .Option("OutillageGrid", new { id = new JS("data.NumOt") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 285 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 287 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("IntervenatsDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 289 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Les intervenants")
                .Template(new TemplateName("IntervenantsGrid"))
                .Option("RapportGridData", new { id = new JS("data.NumIntervention") });

        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 298 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 300 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("IntervenantsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 302 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.AssOtIntervenants>()
            .DataSource(ds => ds.Mvc()
            .Controller("AssOtIntervenants")
            .LoadAction("Get")
            .Key("Id")
            .LoadParams(new
            {
                id = new JS("RapportGridData.id")
            }
            )
            )
            .RemoteOperations(true)
            .NoDataText("Aucune donnée à afficher")
            .CacheEnabled(true)
            .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
            .Columns(columns => {

            columns.AddFor(m => m.CodeIntervenant)
            .Lookup(lookup => lookup
            .DataSource(ds => ds.WebApi().Controller("GestionPersonnelsMethode").LoadAction("NomLookupIntervenant").Key("Value"))
            .AllowClearing(true)
            .ValueExpr("Value")
            .DisplayExpr("Text"))
            .AllowGrouping(true);
                columns.AddFor(m => m.CodeMachine).Caption("Machine").Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("AssOtIntervenants").LoadAction("MachinesLookup").Key("Value"))
                .ValueExpr("Value")
                .DisplayExpr("Text")
                .AllowClearing(true)
                 );
                columns.AddFor(m => m.CodeEquipement).Caption("Equipement").Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("AssOtIntervenants").LoadAction("EquipementsLookup").Key("Value"))
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
                });


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
#line 356 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 

}

#line default
#line hidden
#nullable disable
#nullable restore
#line 359 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("TachesGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 361 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.AssOtTraveaux>()
            .DataSource(ds => ds.Mvc()
            .Controller("AssOtTraveaux")
            .LoadAction("Get")
            .Key("Id")
            .LoadParams(new
            {
                id = new JS("TachesGrid.id")
            }
            )
            )
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
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 409 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 411 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 using (Html.DevExtreme().NamedTemplate("OutillageGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 413 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.AssOtOutils>()
    .DataSource(ds => ds.Mvc()
    .Controller("AssOtOutils")
    .LoadAction("Get")
    .Key("Id")
    .LoadParams(new {id = new JS("OutillageGrid.id")}))
    .RemoteOperations(true)
    .NoDataText("Aucune donnée à afficher")
    .CacheEnabled(true)
    .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
    .Columns(columns => {
        columns.AddFor(m => m.CodeOutils).Caption("PDR").Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("AssOtOutils").LoadAction("OutilsLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
            );
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
#line 439 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
 
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#demandesTravailGrid"").dxDataGrid(""instance"");
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
#line 454 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
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
                $links.filter("".dx-link-edit"").addClass(""dx-icon-edit"");
                $links.filter("".dx-link-delete"").addCl");
            WriteLiteral("ass(\"dx-icon-trash\");\r\n            }\r\n        }\r\n    }\r\n    var imprimerDemandeTravail = function (e) {\r\n    var num = e.row.data.NumDt;\r\n    window.open( \' ");
#nullable restore
#line 481 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
              Write(Url.Action("DemandeTravailViewer", "MethodeManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n    }\r\n    var imprimerOrdreTravail = function (e) {\r\n    var num = e.row.data.NumOt;\r\n    window.open( \' ");
#nullable restore
#line 485 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\DemandeTravailsMethodeSuivi.cshtml"
              Write(Url.Action("OrdreTravailViewer", "MethodeManager"));

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
