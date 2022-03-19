#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f65da3d394cb4e4d288593adbec11a92d140dfa4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinManager_Views_MagasinManager_Lieux), @"mvc.1.0.view", @"/Areas/MagasinManager/Views/MagasinManager/Lieux.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f65da3d394cb4e4d288593adbec11a92d140dfa4", @"/Areas/MagasinManager/Views/MagasinManager/Lieux.cshtml")]
    public class Areas_MagasinManager_Views_MagasinManager_Lieux : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
  
    ViewData["Title"] = "Magasin-Liste PDR";
    Layout = "~/Views/Shared/_LayoutMagasinManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
Write(Html.DevExtreme().TabPanel()
.Height("100%")
.Items(items =>
{
    items.Add()
        .Title("Lieux")
        .Template(new TemplateName("LieuxGrid"));
    items.Add()
        .Title("Gisements")
        .Template(new TemplateName("GisementsGrid"));
})
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
 using (Html.DevExtreme().NamedTemplate("LieuxGrid"))
{


#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkLieu>()
 .DataSource(ds => ds.Mvc()
     .Controller("LieuxStockage")
     .LoadAction("GetLieux")
     .InsertAction("PostLieux")
     .UpdateAction("PutLieux")
     .DeleteAction("DeleteLieux")
     .Key("CodeLieu"))
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
         columns.AddFor(m => m.DesignationLieu);
     })
    .Editing(editing =>
    {
        editing.AllowUpdating(true);
        editing.AllowDeleting(true);
        editing.AllowAdding(true);
        editing.Mode(GridEditMode.Row);
    })
   .ID("LieuxGrid")
   .MasterDetail(md => md
   .Enabled(true)
   .Template(new TemplateName("LieuDetails")))
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
#line 68 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
 
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
 using (Html.DevExtreme().NamedTemplate("LieuDetails"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Liste Articles")
                .Template(new TemplateName("ArticlesGrid"))
                .Option("ArticlesGrid", new { CodeLieu = new JS("data.CodeLieu") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
 using (Html.DevExtreme().NamedTemplate("ArticlesGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Areas.MagasinManager.Models.LieuPdrModel>()
        .ShowBorders(true)
        .LoadPanel(l => l.Enabled(true))
        .Columns(columns =>
        {
            columns.AddFor(m => m.CodePdr);
            columns.AddFor(m => m.DesignationPdr);
            columns.AddFor(m => m.ReferenceModele);
            columns.AddFor(m => m.Quantite);
        })
         .DataSource(ds => ds.Mvc()
             .Controller("LieuxStockage")
             .LoadAction("GetArticlesLieux")
             .Key("CodePdr")
             .LoadParams(new
             {
                 CodeLieu = new JS("ArticlesGrid.CodeLieu")
             }))
           .Editing(editing =>
           {
               editing.AllowUpdating(false);
               editing.AllowDeleting(false);
               editing.AllowAdding(false);
               editing.Mode(GridEditMode.Form);
           })
            );

#line default
#line hidden
#nullable disable
#nullable restore
#line 109 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
             

}

#line default
#line hidden
#nullable disable
#nullable restore
#line 112 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
 using (Html.DevExtreme().NamedTemplate("GisementsGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.StkGismentPdr>()
 .DataSource(ds => ds.Mvc()
     .Controller("LieuxStockage")
     .LoadAction("GetGisement")
     .InsertAction("PostGisement")
     .UpdateAction("PutGisement")
     .DeleteAction("DeleteGisement")
     .Key("CodeGisment"))
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
         columns.AddFor(m => m.DesignationGisment);
     })
    .Editing(editing =>
    {
        editing.AllowUpdating(true);
        editing.AllowDeleting(true);
        editing.AllowAdding(true);
        editing.Mode(GridEditMode.Row);
    })
    .ID("GiseGrid")
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
#line 151 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
 
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
    var imprimerFicheArticle = function (e) {
        var num = e.row.data.NumFicheArticle;
        window.open(  ' ");
#nullable restore
#line 169 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Lieux.cshtml"
                   Write(Url.Action("FicheArticleViewer", "MagasinManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n    }\r\n    function CollpaseAll(e) {\r\n        e.component.collapseAll(-1);\r\n    }\r\n</script>\r\n");
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
