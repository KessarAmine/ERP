#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f77801bd37449044a2b43fa7726dbbaae9b8e4ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UsinageManager_Views_UsinageManager_DxDropDownBoxChangementCharegeT), @"mvc.1.0.view", @"/Areas/UsinageManager/Views/UsinageManager/DxDropDownBoxChangementCharegeT.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f77801bd37449044a2b43fa7726dbbaae9b8e4ec", @"/Areas/UsinageManager/Views/UsinageManager/DxDropDownBoxChangementCharegeT.cshtml")]
    public class Areas_UsinageManager_Views_UsinageManager_DxDropDownBoxChangementCharegeT : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    function gridBox_valueChanged(args, setValueMethod) {
        var $dataGrid = $(""#embedded-datagridMultipleIdEmployeeChangeChargeT"");
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
</script>
");
#nullable restore
#line 26 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
Write(Html.DevExtreme().DropDownBox()
                .ValueExpr("Id")
                .DisplayExpr("Nom")
                .DataSource(d => d.Mvc()
                .Controller("GestionPersonnelsUsinage")
                .LoadAction("GetUsinage")
                .LoadMode(DataSourceLoadMode.Raw)
                .Key("Id"))
                .Placeholder("Select a value...")
                .ShowClearButton(true)
                .OnValueChanged(@"function(args) { gridBox_valueChanged(args, setValue); }")
                .ContentTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    ");
#nullable restore
#line 38 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
                Write(Html.DevExtreme().DataGrid()
                        .ID("embedded-datagridMultipleIdEmployeeChangeChargeT")
                        .DataSource(new JS(@"component.getDataSource()"))
                        .Columns(columns =>
                        {
                            columns.Add().DataField("Nom");
                            columns.Add().DataField("Prenom");
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
#line 55 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\UsinageManager\Views\UsinageManager\DxDropDownBoxChangementCharegeT.cshtml"
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
