#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ef3773e93e3a94bb04186a1050f2a45282a7c6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MethodeManager_Views_MethodeManager_Analytics), @"mvc.1.0.view", @"/Areas/MethodeManager/Views/MethodeManager/Analytics.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ef3773e93e3a94bb04186a1050f2a45282a7c6b", @"/Areas/MethodeManager/Views/MethodeManager/Analytics.cshtml")]
    public class Areas_MethodeManager_Views_MethodeManager_Analytics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
  
    ViewData["Title"] = "Méthodes-Analytics";
    Layout = "~/Views/Shared/_LayoutMethodeManager.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Height("100%")
        .Items(items =>
        {
            items.Add()
                .Title("Loi de Paréto")
                .Template(new TemplateName("Pareto"));
            items.Add()
                .Title("Loi d'Ichigawa")
                .Template(new TemplateName("Ichigawa"));
        })
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
 using (Html.DevExtreme().NamedTemplate("Pareto"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Height("100%")
        .Items(items =>
        {
            items.Add()
                .Title("Arrets Correctif")
                .Template(new TemplateName("ArretsCorrectif"));
            items.Add()
                .Title("Arrets Préventifs")
                .Template(new TemplateName("ArretsPréventifs"));
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
         

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 43 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArretsCorrectif"))
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Models.AnalyticsTravauxMachines>()
 .DataSource(ds => ds.Mvc()
     .Controller("Dashboard")
     .LoadAction("GetMachinesTravauxAnalytics")
     .Key("NomMachine")
     .LoadParams(new { Codemaintenance = 0}))
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
         columns.AddFor(m => m.NomMachine).Caption("Machine");
         columns.AddFor(m => m.DureeInterventionsCorrectif).Caption("Temps arret Correctif");
         columns.AddFor(m => m.PourcentageDureeInterventionsCorrectif).Caption("% d'arret Correctif");
         columns.AddFor(m => m.PourcentageCumuleDureeInterventionsCorrectif).Caption("% Cumulé d'arret Correctif");
     })
    .Sorting(sorting => sorting.Mode(GridSortingMode.Single))
    .Summary(s => s.TotalItems(items =>
    {
        items.AddFor(m => m.DureeInterventionsCorrectif)
            .SummaryType(SummaryType.Sum)
            .ShowInColumn("DureeInterventionsCorrectif")
            .DisplayFormat("Total: {0}");
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
#line 86 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
Write(Html.DevExtreme().Popup()
.ID("Add-popup")
.ShowTitle(true)
.Title("Ajouter une demande Service")
.Visible(false)
.DragEnabled(false)
.CloseOnOutsideClick(true)
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArretsPréventifs"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Models.AnalyticsTravauxMachines>()
 .DataSource(ds => ds.Mvc()
     .Controller("Dashboard")
     .LoadAction("GetMachinesTravauxAnalytics")
     .Key("NomMachine")
     .LoadParams(new { Codemaintenance = 1}))
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
         columns.AddFor(m => m.NomMachine).Caption("Machine");
         columns.AddFor(m => m.DureeInterventionsPréventif).Caption("Temps arret Préventif");
         columns.AddFor(m => m.PourcentageDureeInterventionsPréventif).Caption("% d'arret Préventif");
         columns.AddFor(m => m.PourcentageCumuleDureeInterventionsPréventif).Caption("% Cumulé d'arret Préventif");
     })
    .Sorting(sorting => sorting.Mode(GridSortingMode.Single))
    .Summary(s => s.TotalItems(items =>
    {
        items.AddFor(m => m.DureeInterventionsPréventif)
            .SummaryType(SummaryType.Sum)
            .ShowInColumn("DureeInterventionsPréventif")
            .DisplayFormat("Total : {0} Mns");
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
#line 137 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
Write(Html.DevExtreme().Popup()
.ID("Add-popup")
.ShowTitle(true)
.Title("Ajouter une demande Service")
.Visible(false)
.DragEnabled(false)
.CloseOnOutsideClick(true)
);

#line default
#line hidden
#nullable disable
#nullable restore
#line 144 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MethodeManager\Views\MethodeManager\Analytics.cshtml"
 
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
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

</script>
");
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
