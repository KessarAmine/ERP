#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0038435d0f31b0fd3fc8efae97eec9b0dd0c6500"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MecaniqueManager_Views_MecaniqueManager_DxDropDownBoxArticlesFourniture), @"mvc.1.0.view", @"/Areas/MecaniqueManager/Views/MecaniqueManager/DxDropDownBoxArticlesFourniture.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0038435d0f31b0fd3fc8efae97eec9b0dd0c6500", @"/Areas/MecaniqueManager/Views/MecaniqueManager/DxDropDownBoxArticlesFourniture.cshtml")]
    public class Areas_MecaniqueManager_Views_MecaniqueManager_DxDropDownBoxArticlesFourniture : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 26 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
Write(Html.DevExtreme().DropDownBox()
                .ValueExpr("CodePdr")
                .DisplayExpr("DesignationPdr")
                .DataSource(d => d.Mvc()
                .Controller("ApproFournituresArticles")
                .LoadAction("GetPdr")
                .LoadMode(DataSourceLoadMode.Raw)
                .Key("CodePdr"))
                .Placeholder("Select a value...")
                .ShowClearButton(true)
                .OnValueChanged(@"function(args) { gridBox_valueChanged(args, setValue); }")
                .ContentTemplate(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    ");
#nullable restore
#line 38 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
                Write(Html.DevExtreme().DataGrid()
                        .ID("embedded-datagridMultipleIdEmployee")
                        .DataSource(new JS(@"component.getDataSource()"))
                        .Columns(columns =>
                        {
                            columns.Add().DataField("CodePdr");
                            columns.Add().DataField("DesignationPdr");
                            columns.Add().DataField("CodeUniteMesure").Lookup(lookup => lookup
                            .DataSource(ds => ds.WebApi().Controller("ApproDemandesFournitures").LoadAction("CodeUniteMesureLookup").Key("Value"))
                            .ValueExpr("Value")
                            .DisplayExpr("Text")
                            .AllowClearing(true)
                            );
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
#line 61 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\DxDropDownBoxArticlesFourniture.cshtml"
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
