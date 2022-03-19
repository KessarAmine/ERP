#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\Home\DashboardMainMethodeManager.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4686c3ce1227bf343fc07e320194a6aeff6f32ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DashboardMainMethodeManager), @"mvc.1.0.view", @"/Views/Home/DashboardMainMethodeManager.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\_ViewImports.cshtml"
using DevKbfSteel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\_ViewImports.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\_ViewImports.cshtml"
using DevKbfSteel.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\_ViewImports.cshtml"
using DevExtreme;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\_ViewImports.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\_ViewImports.cshtml"
using DevExpress;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4686c3ce1227bf343fc07e320194a6aeff6f32ed", @"/Views/Home/DashboardMainMethodeManager.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90fc6e095ae0800b1c3a2c731bf07c8a42e0c4b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DashboardMainMethodeManager : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("        height: 98%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html style=\"height:100%;\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4686c3ce1227bf343fc07e320194a6aeff6f32ed4462", async() => {
                WriteLiteral("\r\n        ");
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\Home\DashboardMainMethodeManager.cshtml"
    Write(Html.DevExtreme().Chart()
    .ID("chart")
    .CommonSeriesSettings(s => s.ArgumentField("NomCage"))
    .Panes(p => {
        p.Add().Name("TopPane");
        p.Add().Name("BottomPane");
    })
    .Series(s => {

        s.Add()
        .Pane("TopPane")
            .Type(SeriesType.Bar)
            .ValueField("NombreInterventionsMecanique")
            .Name("Nombre Interventions Mécanique")
            .Label(l => l
                .Visible(true)
                .CustomizeText(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    function (){\r\n                        return this.valueText;\r\n                    }\r\n                ");
    PopWriter();
}
)));
        s.Add()
        .Pane("TopPane")
            .Type(SeriesType.Bar)
            .ValueField("NombreInterventionsElectrique")
            .Name("Nombre Interventions Electrique")
            .Label(l => l
                .Visible(true)
                .CustomizeText(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    function (){\r\n                        return this.valueText;\r\n                    }\r\n                ");
    PopWriter();
}
)));
        s.Add()
            .Pane("BottomPane")
            .Type(SeriesType.Bar)
            .ValueField("DureeInterventionsMecanique")
            .Name("Duree Interventions Mécanique")
            .Label(l => l
                .Visible(true)
                .CustomizeText(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    function (){\r\n                        return this.valueText;\r\n                    }\r\n                ");
    PopWriter();
}
)));
        s.Add()
            .Pane("BottomPane")
            .Type(SeriesType.Bar)
            .ValueField("DureeInterventionsElectrique")
            .Name("Duree Interventions Electrique")
            .Label(l => l
                .Visible(true)
                .CustomizeText(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                    function (){\r\n                        return this.valueText;\r\n                    }\r\n                ");
    PopWriter();
}
)));
    })
    .ValueAxis(a => {
        a.Add()
            .Pane("BottomPane")
            .Grid(g => g.Visible(true))
            .Title(t => t.Text("Durée(minutes)"));
        a.Add()
            .Pane("TopPane")
            .Grid(g => g.Visible(true))
            .Title(t => t.Text("Comptage"));
    })
    .Legend(l => l
        .VerticalAlignment(VerticalEdge.Bottom)
        .HorizontalAlignment(HorizontalAlignment.Center)
    )
    .Export(e => e.Enabled(true))
    .Title(t => t.Text("Etat des cages (suivi des interventions)"))
    .DataSource(d => d.Mvc()
        .Controller("Dashboard")
        .LoadAction("GetCagesTravauxMethode")
    )
);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        ");
#nullable restore
#line 83 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\Home\DashboardMainMethodeManager.cshtml"
    Write(Html.DevExtreme().PieChart()
    .ID("pie")
    .Size(s => s.Width(700))
    .Palette(VizPalette.DarkMoon)
    .Legend(l => l
    .HorizontalAlignment(HorizontalAlignment.Center)
    .VerticalAlignment(VerticalEdge.Bottom)
    )
    .Series(s => {
    s.Add()
         .ArgumentField("StatutDT")
         .ValueField("CountDt")
         .Label(l => l
             .Visible(true)
             .Connector(c => c
                 .Visible(true)
                 .Width(1)
             )
         .Format(Format.FixedPoint)
             .CustomizeText(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                function (point) {\r\n                    return point.argumentText + \": \" + point.valueText;\r\n                }\r\n            ");
    PopWriter();
}
))
     );
    }
    )
    .Title("Etat des demandes de travails Reçues")
    .Export(e => e.Enabled(true))
    .OnPointClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        function (e) {\r\n            var point = e.target;\r\n            toggleVisibility(point);\r\n        }\r\n    ");
    PopWriter();
}
))
    .OnLegendClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        function (e) {\r\n            var arg = e.target;\r\n            toggleVisibility(this.getAllSeries()[0].getPointsByArg(arg)[0]);\r\n        }\r\n    ");
    PopWriter();
}
))
    .DataSource(d => d.Mvc()
        .Controller("Dashboard")
        .LoadAction("GetStatutDtsMethode")
    )
);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 130 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Views\Home\DashboardMainMethodeManager.cshtml"
    Write(Html.DevExtreme().PieChart()
    .ID("pie2")
    .Size(s => s.Width(700))
    .Palette(VizPalette.DarkMoon)
    .Legend(l => l
    .HorizontalAlignment(HorizontalAlignment.Center)
    .VerticalAlignment(VerticalEdge.Bottom)
    )
    .Series(s => {
    s.Add()
         .ArgumentField("StatutDT")
         .ValueField("CountDt")
         .Label(l => l
             .Visible(true)
             .Connector(c => c
                 .Visible(true)
                 .Width(1)
             )
         .Format(Format.FixedPoint)
             .CustomizeText(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                function (point) {\r\n                    return point.argumentText + \": \" + point.valueText;\r\n                }\r\n            ");
    PopWriter();
}
))
     );
    }
    )
    .Title("Etat des demandes de travails Reçues")
    .Export(e => e.Enabled(true))
    .OnPointClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        function (e) {\r\n            var point = e.target;\r\n            toggleVisibility(point);\r\n        }\r\n    ");
    PopWriter();
}
))
    .OnLegendClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        function (e) {\r\n            var arg = e.target;\r\n            toggleVisibility(this.getAllSeries()[0].getPointsByArg(arg)[0]);\r\n        }\r\n    ");
    PopWriter();
}
))
    .DataSource(d => d.Mvc()
        .Controller("Dashboard")
        .LoadAction("GetStatutDtsMethode")
    )
);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n<script>\r\n    function toggleVisibility(item) {\r\n        if (item.isVisible()) {\r\n            item.hide();\r\n        } else {\r\n            item.show();\r\n        }\r\n    }\r\n</script>\r\n");
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
