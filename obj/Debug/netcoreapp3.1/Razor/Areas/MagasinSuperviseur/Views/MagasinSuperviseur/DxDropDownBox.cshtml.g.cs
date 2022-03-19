#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdd784a141637e1b97cbf39f9c4388766f4ff78d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MagasinSuperviseur_Views_MagasinSuperviseur_DxDropDownBox), @"mvc.1.0.view", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/DxDropDownBox.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdd784a141637e1b97cbf39f9c4388766f4ff78d", @"/Areas/MagasinSuperviseur/Views/MagasinSuperviseur/DxDropDownBox.cshtml")]
    public class Areas_MagasinSuperviseur_Views_MagasinSuperviseur_DxDropDownBox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    function gridBox_valueChanged(args, setValueMethod) {
        var $dataGrid = $(""#embedded-datagridMultipleIdEmployee"");
        if ($dataGrid.length) {
            var dataGrid = $dataGrid.dxDataGrid(""instance"");
            dataGrid.selectRows(args.value, false);
        }
        setValueMethod(args.value);
    }
</script>
");
#nullable restore
#line 19 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
Write(Html.DevExtreme().DropDownBox()
                .ValueExpr("Id")
                .DisplayExpr("Nom")
                .DataSource(d => d.Mvc()
                .Controller("RhListeDesEmployes")
                .LoadAction("Get")
                .InsertAction("Post")
                .UpdateAction("Put")
                .LoadMode(DataSourceLoadMode.Raw)
                .Key("Id"))
                .Placeholder("Selectionner l'employé...")
                .ShowClearButton(true)
                .OnValueChanged(@"function(args) { gridBox_valueChanged(args, setValue); }")
                .ContentTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    ");
#nullable restore
#line 33 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
                Write(Html.DevExtreme().DataGrid()
                        .ID("embedded-datagridMultipleIdEmployee")
                        .DataSource(new JS(@"component.getDataSource()"))
                        .Columns(columns =>
                        {
                            columns.Add().DataField("Nom");
                            columns.Add().DataField("Prenom");
                            columns.Add().DataField("Departement")
                            .Lookup(lookup => lookup
                            .DataSource(ds => ds.WebApi().Controller("RhListeDesEmployes").LoadAction("DepartementsLookup").Key("Value"))
                            .AllowClearing(true)
                            .ValueExpr("Value")
                            .DisplayExpr("Text")
                            );
                        })
                        .Editing(editing =>
                           {
                               editing.AllowUpdating(false);
                               editing.AllowDeleting(false);
                               editing.AllowAdding(false);
                               editing.Mode(GridEditMode.Row);
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
    WriteLiteral("\r\n                    ");
#nullable restore
#line 64 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MagasinSuperviseur\Views\MagasinSuperviseur\DxDropDownBox.cshtml"
                Write(Html.DevExtreme().Button()
                         .ElementAttr(new { style = "margin-top:10px;float:right" })
                         .Text("Close")
                         .OnClick(@"function(args) { onCloseBtnClick(args, component); }"));

#line default
#line hidden
#nullable disable
    WriteLiteral("\r\n                ");
    PopWriter();
}
))
);

#line default
#line hidden
#nullable disable
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
