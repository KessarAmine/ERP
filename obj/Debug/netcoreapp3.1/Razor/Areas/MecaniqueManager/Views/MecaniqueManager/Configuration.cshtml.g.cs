#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa551f6bc3f4d7b35401cbeaa1a8e68b5d3e968d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MecaniqueManager_Views_MecaniqueManager_Configuration), @"mvc.1.0.view", @"/Areas/MecaniqueManager/Views/MecaniqueManager/Configuration.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa551f6bc3f4d7b35401cbeaa1a8e68b5d3e968d", @"/Areas/MecaniqueManager/Views/MecaniqueManager/Configuration.cshtml")]
    public class Areas_MecaniqueManager_Views_MecaniqueManager_Configuration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
  
    ViewData["Title"] = "Mécanique-Configuration";
    Layout = "~/Views/Shared/_LayoutMecaniqueManager.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
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
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.ConfigMecanique>()
.DataSource(ds => ds.Mvc()
 .Controller("ConfigMecaniqueManager")
 .LoadAction("Get")
 .InsertAction("Post")
 .UpdateAction("Put")
 .DeleteAction("Delete")
 .Key("Id")
 )
.Scrolling(scrolling => scrolling
.ScrollByContent(true)
.ShowScrollbar(ShowScrollbarMode.Always)
.Mode(GridScrollingMode.Virtual))
.Height("95%")
.RemoteOperations(true)
.ID("RhContratsDesEmployesGrid")
.NoDataText("Aucune donnée à afficher")
.CacheEnabled(true)
.SearchPanel(sp => sp.Placeholder("Rechercher").Visible(true))
.Columns(columns => {
columns.AddFor(m => m.LimiteDemandeFourniture);

        columns.Add()
        .Type(GridCommandColumnType.Buttons)
        .Width(110)
        .Buttons(b => {
            b.Add().Name(GridColumnButtonName.Edit);
            b.Add().Name(GridColumnButtonName.Delete);
        });
    })
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
        var demandesTravailGrid = $(""#RhContratsDesEmployesGrid"").dxDataGrid(""instance"");
   ");
            WriteLiteral(@"     var demandesTravailDS = demandesTravailGrid.getDataSource();
        demandesTravailGrid.beginCustomLoading(""Chargement en cours..."");
        demandesTravailDS.reload();
        demandesTravailGrid.refresh();
        demandesTravailGrid.endCustomLoading();
    }

    function addButton_click() {
        DevExpress.ui.notify(""Ajouter une demande!"");
        window.location.href = '");
#nullable restore
#line 110 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\Configuration.cshtml"
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
                $links.filter("".dx-link-dele");
            WriteLiteral(@"te"").addClass(""dx-icon-trash"");
            }
        }
        if (e.rowType === ""data"") {
            var dangerColor = ""#f54542"";
            if (e.column.dataField == ""DateFinAmbouche"") {
                var Today = new Date();
                var str = e.value;
                var aday = new Date();
                aday = str;
                console.log(aday);
                console.log(aday.getMonth() + 1);
                var month = Today.getMonth() + 1;
                if (month >= 12) {
                    month = 0;
                }
                console.log(month);
                if ((aday.getMonth() + 1 - month ) <= 2) {
                    $(e.cellElement).get(0).style.backgroundColor = dangerColor;
                }
            }
        }
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
