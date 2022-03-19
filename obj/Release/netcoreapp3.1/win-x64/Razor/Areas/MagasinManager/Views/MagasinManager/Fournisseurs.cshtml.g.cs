#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd1895bc96c61b6ceff0b4f0aadc038a1008f8c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinManager_Views_MagasinManager_Fournisseurs), @"mvc.1.0.view", @"/Areas/MagasinManager/Views/MagasinManager/Fournisseurs.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
using DevKbfSteel.Areas.MagasinManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd1895bc96c61b6ceff0b4f0aadc038a1008f8c3", @"/Areas/MagasinManager/Views/MagasinManager/Fournisseurs.cshtml")]
    public class Areas_MagasinManager_Views_MagasinManager_Fournisseurs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
  
    ViewData["Title"] = "Magasin-Liste Fournisseurs";
    Layout = "~/Views/Shared/_LayoutMagasinManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinManager\Views\MagasinManager\Fournisseurs.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ApproFournisseurs>()
.ID("Fournissuers")
.DataSource(ds => ds.Mvc()
.Controller("Fournisseurs")
.LoadAction("GetFournisseurs")
.InsertAction("PostFournisseurs")
.UpdateAction("PutFournisseurs")
.DeleteAction("DeleteFournisseurs")
.Key("NumeroFournisseur")
)
.RemoteOperations(true)
.NoDataText("Aucune donnée à afficher")
.CacheEnabled(true)
.SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
.Columns(columns => {
    columns.AddFor(m => m.SocieteFournisseur).Caption("Nom");
    columns.AddFor(m => m.Adresse);
    columns.AddFor(m => m.Fonction);
    columns.AddFor(m => m.Telephone);
    columns.AddFor(m => m.Gmail);
    columns.AddFor(m => m.Contact);
    columns.AddFor(m => m.Nrc).Visible(false);
    columns.AddFor(m => m.Mf).Visible(false);
    columns.AddFor(m => m.Art);
    columns.AddFor(m => m.CodePostal).Visible(false);
    columns.AddFor(m => m.Fax).Visible(false);
    columns.AddFor(m => m.Pays).Visible(false);
    columns.AddFor(m => m.Ville).Visible(false);
})
.ColumnChooser(cc => cc
.Enabled(true)
.AllowSearch(true))
.Height("95%")
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
.OnRowExpanding("CollpaseAll")
.OnRowExpanded("refreshButton_click")
);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function refreshButton_click() {
        DevExpress.ui.notify(""Rafraichissement en cours!"");
        var demandesTravailGrid = $(""#Fournissuers"").dxDataGrid(""instance"");
        var demandesTravailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();
        demandesTravailGrid.endCustomLoading();
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
                $links.filter("".dx-link-delete"").add");
            WriteLiteral("Class(\"dx-icon-trash\");\r\n            }\r\n        }\r\n    }\r\n    function CollpaseAll(e) {\r\n        e.component.collapseAll(-1);\r\n    }\r\n\r\n</script>");
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
