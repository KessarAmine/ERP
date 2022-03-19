#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d533229ef687c31ca389526dfff9759b853ac512"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ElectriqueManager_Views_ElectriqueManager_DossierMachines), @"mvc.1.0.view", @"/Areas/ElectriqueManager/Views/ElectriqueManager/DossierMachines.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d533229ef687c31ca389526dfff9759b853ac512", @"/Areas/ElectriqueManager/Views/ElectriqueManager/DossierMachines.cshtml")]
    public class Areas_ElectriqueManager_Views_ElectriqueManager_DossierMachines : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
  
    ViewData["Title"] = "Electrique-Dossier Machine";
    Layout = "~/Views/Shared/_LayoutElectriqueManager.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Height("100%")
        .Items(items =>
        {
            items.Add()
                .Title("Installations")
                .Template(new TemplateName("InstallationsnTemplate"));

            items.Add()
                .Title("Equipements")
                .Template(new TemplateName("EquipementsTemplate"));
            items.Add()
                .Title("Hierarchie des zones")
                .Template(new TemplateName("HierarchieTemplate"));
        })
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 29 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
 using (Html.DevExtreme().NamedTemplate("InstallationsnTemplate"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.Machines>()
        .Height("95%")
        .RemoteOperations(true)
        .Scrolling(scrolling => scrolling
        .ScrollByContent(true)
        .ShowScrollbar(ShowScrollbarMode.Always)
        .Mode(GridScrollingMode.Virtual))
        .LoadPanel(l => l.Enabled(true))
        .Columns(columns =>
        {
            columns.AddFor(m => m.NomMachine);
            columns.AddFor(m => m.SeuilAlerteAnoamlie);
            columns.AddFor(m => m.NumGroupe).Caption("Groupe Machine")
            .Lookup(lookup => lookup
               .DataSource(ds => ds.Mvc().Controller("Machines").LoadAction("GroupeMachinesLookup").Key("Value"))
               .AllowClearing(true)
               .ValueExpr("Value")
               .DisplayExpr("Text")
            );

            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b =>
                {
                    b.Add().Name(GridColumnButtonName.Edit);
                    b.Add().Name(GridColumnButtonName.Delete);
                    b.Add()
                        .Hint("Fiche de suivi equipement")
                        .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("FicheSuiviEquipement");
    PopWriter();
}
))
                        .Icon("print");
                    b.Add()
                        .Hint("Fiche de Plannification equipement")
                        .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("FichePlannificationEquipement");
    PopWriter();
}
))
                        .Icon("print");
                });
        })
         .DataSource(ds => ds.Mvc()
             .Controller("Machines")
             .LoadAction("Get")
             .Key("NumMachine")
            )
               .MasterDetail(md => md
               .Enabled(true)
               .Template(new TemplateName("MachineDetails"))
            )
         .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
         .NoDataText("Aucune donnée à afficher")
         .FilterRow(f => f.Visible(true))
        .HeaderFilter(headerfilter => headerfilter.Visible(true))
        .GroupPanel(p => p.Visible(true))
        .AllowColumnReordering(true)
        .AllowColumnResizing(true)
         .Editing(editing =>
         {
             editing.AllowUpdating(false);
             editing.AllowDeleting(false);
             editing.AllowAdding(false);
             editing.Mode(GridEditMode.Popup)
              .Popup(p => p.Title("Editer Machine")
              .ShowTitle(true)
              .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
         })

    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
 using (Html.DevExtreme().NamedTemplate("EquipementsTemplate"))
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.Equipements>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(true))
        .Height("95%")
        .Scrolling(scrolling => scrolling.Mode(GridScrollingMode.Virtual))
        .Columns(columns =>
        {
            columns.AddFor(m => m.Nom);
            columns.AddFor(m => m.Designation);
            columns.AddFor(m => m.ValeurUnitaire);
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
             .Controller("Equipements")
             .LoadAction("Get")
             .Key("NumEquipement")
            )
          .SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
         .NoDataText("Aucune donnée à afficher")
         .FilterRow(f => f.Visible(true))
        .HeaderFilter(headerfilter => headerfilter.Visible(true))
        .GroupPanel(p => p.Visible(true))
        .AllowColumnReordering(true)
        .AllowColumnResizing(true)
         .Editing(editing =>
         {
             editing.AllowUpdating(false);
             editing.AllowDeleting(false);
             editing.AllowAdding(false);
             editing.Mode(GridEditMode.Popup)
              .Popup(p => p.Title("Editer Equipement")
              .ShowTitle(true)
              .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
         })

    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 142 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 144 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
 using (Html.DevExtreme().NamedTemplate("MachineDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 146 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Details de la machine")
                .Template(new TemplateName("EquipementsGrid"))
                .Option("masterGridData", new { id = new JS("data.NumMachine")
                }
                );
            items.Add()
                .Title("Fiche de Suivi")
                .Template(new TemplateName("SuiviMachineGrid"))
                .Option("masterGridData", new { ids = new JS("data.NumMachine") }
                );
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 161 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 163 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
 using (Html.DevExtreme().NamedTemplate("EquipementsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 165 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.MachineEquioement>()
    .ShowBorders(true)
    .Columns(columns =>
    {
        columns.AddFor(m => m.NumEquipement).Lookup(lookup => lookup
               .DataSource(ds => ds.Mvc().Controller("Machines").LoadAction("EquipementsLookup").Key("Value"))
               .AllowClearing(true)
               .ValueExpr("Value")
               .DisplayExpr("Text")
            );
        columns.AddFor(m => m.NumEquipement).Lookup(lookup => lookup
               .DataSource(ds => ds.Mvc().Controller("Machines").LoadAction("ReferenceLookup").Key("Value"))
               .AllowClearing(true)
               .ValueExpr("Value")
               .DisplayExpr("Text")
            ).AllowEditing(false);

        columns.AddFor(m => m.NumComposition).Caption("Composition").GroupIndex(0)
        .Lookup(lookup => lookup
            .DataSource(ds => ds.Mvc().Controller("Machines").LoadAction("CompositionsLookup").Key("Value"))
            .AllowClearing(true)
            .ValueExpr("Value")
            .DisplayExpr("Text"));
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
        .Summary(s => s.TotalItems(items =>
        {
            items.AddFor(m => m.NumEquipement)
                .SummaryType(SummaryType.Count)
                .ShowInColumn("NumEquipement")
                .DisplayFormat("Nombre d'équipements: {0}") ;
            items.AddFor(m => m.Qte)
                .SummaryType(SummaryType.Sum)
                .ShowInColumn("Qte")
                .DisplayFormat("Total : {0}") ;
        }))

         .DataSource(ds => ds.WebApi()
             .Controller("MachineEquioements")
             .LoadAction("Get")
             .Key("Id")
             .LoadParams(new
             {
                 id = new JS("masterGridData.id")
             }
             )
             )
         .Editing(editing =>
         {
             editing.AllowUpdating(false);
             editing.AllowDeleting(false);
             editing.AllowAdding(false);
             editing.Mode(GridEditMode.Popup)
              .Popup(p => p.Title("Editer Equipement de la machine")
              .ShowTitle(true)
              .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
         })
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 231 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 233 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
 using (Html.DevExtreme().NamedTemplate("SuiviMachineGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 235 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Models.FicheSuiviMachine>()
    .ShowBorders(true)
    .LoadPanel(l => l.Enabled(false))
   .FilterRow(f => f.Visible(true))
   .HeaderFilter(headerfilter => headerfilter.Visible(true))
    .Columns(columns =>
    {
        columns.AddFor(m => m.Datentervention).Format("yyyy-MM-dd")
        .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month)).Caption("Date");
        columns.AddFor(m => m.NumOt).Caption("N° OT");
        columns.AddFor(m => m.NumDt).Caption("N° DT");
        columns.AddFor(m => m.TypeMaintenance).Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("OrdreTravails").LoadAction("TypeMaintenanceLookup").Key("Value"))
        .ValueExpr("Value")
        .DisplayExpr("Text")
        .AllowClearing(true)
        );
        columns.AddFor(m => m.ActionDetaile).Caption("Action détailée");
    })
    .DataSource(ds => ds.Mvc()
        .Controller("MachineEquioements")
        .LoadAction("GetSuiviNew")
        .LoadParams(new
        {
            id = new JS("masterGridData.ids")
        }
        )
    )
    .GroupPanel(p => p.Visible(true))
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 264 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 266 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
 using (Html.DevExtreme().NamedTemplate("HierarchieTemplate"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 268 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
Write(Html.DevExtreme().ScrollView()
        .ID("scrollview")
        .Direction(ScrollDirection.Both)
        .ScrollByContent(true)
        .ScrollByThumb(true)
        .ShowScrollbar(ShowScrollbarMode.OnScroll)
        .BounceEnabled(true)
        .Content(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        ");
#nullable restore
#line 276 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
    Write(Html.Partial("MachineZones"));

#line default
#line hidden
#nullable disable
    WriteLiteral("\r\n        ");
    PopWriter();
}
))
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 278 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    function FicheSuiviEquipement(e) {\r\n        var CodeMachineReport = e.row.data.NumMachine;\r\n        window.open(\' ");
#nullable restore
#line 284 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
                 Write(Url.Action("SuiviEquipementViewer", "ElectriqueManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?CodeMachineReport=\' + CodeMachineReport, \'_blank\').focus();\r\n\r\n    }\r\n    function FichePlannificationEquipement(e) {\r\n        var CodeMachineReport = e.row.data.NumMachine;\r\n        window.open(\' ");
#nullable restore
#line 289 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\ElectriqueManager\Views\ElectriqueManager\DossierMachines.cshtml"
                 Write(Url.Action("PlanningEquipementViewer", "ElectriqueManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?CodeMachineReport=\' + CodeMachineReport, \'_blank\').focus();\r\n    }\r\n</script>");
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
