#pragma checksum "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fbdd6fb2ec713794a1654323779c441195e6461"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MecaniqueManager_Views_MecaniqueManager_GestionPersonnels), @"mvc.1.0.view", @"/Areas/MecaniqueManager/Views/MecaniqueManager/GestionPersonnels.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevKbfSteel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevExpress.XtraReports.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevKbfSteel.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevKbfSteel.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevExpress.XtraReports.Parameters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevKbfSteel.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevExpress.AspNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fbdd6fb2ec713794a1654323779c441195e6461", @"/Areas/MecaniqueManager/Views/MecaniqueManager/GestionPersonnels.cshtml")]
    public class Areas_MecaniqueManager_Views_MecaniqueManager_GestionPersonnels : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 9 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
  
    ViewData["Title"] = "Mécanique-Gestion du personnel";
    Layout = "~/Views/Shared/_LayoutMecaniqueManager.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.RhListeDesEmployes>()
    .DataSource(ds => ds.Mvc()
     .Controller("GestionPersonnelsMecanique")
     .LoadAction("Get")
     .UpdateAction("Put")
     .Key("Id")
     )

    .OnRowExpanding(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n        function(e) {\r\n        \te.component.collapseAll(-1);\r\n        }\r\n    ");
    PopWriter();
}
))
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
        columns.AddFor(m => m.Nom);
        columns.AddFor(m => m.Prenom);
        columns.AddFor(m => m.CodeSpecialité).Caption("Specialité")
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("GestionPersonnelsMecanique").LoadAction("SpecieliteLookup").Key("Value"))
        .AllowClearing(true)
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );
        columns.AddFor(m => m.CodeEquipe)
        .Lookup(lookup => lookup
        .DataSource(ds => ds.WebApi().Controller("GestionPersonnelsMecanique").LoadAction("EquipeLookup").Key("Value"))
        .AllowClearing(true)
        .ValueExpr("Value")
        .DisplayExpr("Text")
        );
        columns.AddFor(m => m.TelProfesionnel);
        columns.Add()
            .Type(GridCommandColumnType.Buttons)
            .Width(110)
            .Buttons(b => {
                b.Add().Name(GridColumnButtonName.Edit);
                b.Add()
                    .Hint("Imprimer suivi personnel")
                    .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerSuiviPerso");
    PopWriter();
}
))
                           .Icon("print");
                b.Add()
                    .Hint("Informations")
                    .Icon("fas fa-info")
                    .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral(@"
                        function showPopUpApp(e) {
                            var popup = $(""#Informations-popup"").dxPopup(""instance"");
                            popup.option(""contentTemplate"", $(""#Informations-template""));

                            var Nom = document.getElementsByName(""Nom"");
                            Object.entries(Nom).forEach(nm => {
                            nm.value = e.row.data.Nom;
                            });

                            console.log(popup);

                            popup.show();
                        }
                     ");
    PopWriter();
}
));
            });
    })
    .ColumnChooser(cc => cc.Enabled(true).AllowSearch(true))

    .Editing(editing =>
    {
        editing.AllowUpdating(true);
        editing.Mode(GridEditMode.Popup)
        .Popup(p => p.Title("Editer Employé")
        .ShowTitle(true)
        .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
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
    .Template(new TemplateName("SuiviPersonnel"))
    )
    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 106 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
 using (Html.DevExtreme().NamedTemplate("SuiviPersonnel"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 108 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
Write(Html.DevExtreme().TabPanel()
        .Items(items =>
        {
            items.Add()
                .Title("Suivi des interventions")
                .Template(new TemplateName("SuiviInterventionGrid"))
                .Option("SuiviInterventionGridData", new { id = new JS("data.Id") });
            items.Add()
                .Title("Suivi des entretiens")
                .Template(new TemplateName("SuiviEntretiensGrid"))
                .Option("SuiviInterventionGridData", new { id = new JS("data.Id") });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
         
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 122 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
 using (Html.DevExtreme().NamedTemplate("SuiviInterventionGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 124 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Models.SuiviInterventionPersonnelRh>()
        .ShowBorders(true)
        .Export(e => e.Enabled(true).AllowExportSelectedData(true))
        .FilterRow(f => f.Visible(true))
        .HeaderFilter(headerfilter => headerfilter.Visible(true))
        .GroupPanel(p => p.Visible(true))
        .AllowColumnReordering(true)
        .AllowColumnResizing(true)
        .OnCellPrepared("receptionCell_prepared")
        .Selection(s => s.Mode(SelectionMode.Multiple))
        .Columns(columns =>
        {
            columns.AddFor(m => m.NumIntervention);
            columns.AddFor(m => m.DateIntervention).Format("yyyy-MM-dd")
            .DataType(GridColumnDataType.DateTime)
            .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
            columns.AddFor(m => m.DureeInervention);
            columns.AddFor(m => m.Remunération).Visible(false);
            columns.AddFor(m => m.CodeMachine).Caption("Machine")
            .Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("GestionPersonnelsMecanique").LoadAction("MachinesLookup").Key("Value"))
                .ValueExpr("Value")
                .DisplayExpr("Text")
                .AllowClearing(true)
                );
            columns.AddFor(m => m.CodeEquipement).Caption("Equipement")
            .Lookup(lookup => lookup
                .DataSource(ds => ds.WebApi().Controller("GestionPersonnelsMecanique").LoadAction("EquipementsLookup").Key("Value"))
                .ValueExpr("Value")
                .DisplayExpr("Text")
                .AllowClearing(true)
                );
        columns.Add()
                .Caption("Valorisation")
                .CalculateCellValue(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n                function(data) {\r\n                    return [(data.Remunération * data.DureeInervention)/60];\r\n                }\r\n                ");
    PopWriter();
}
)).AllowEditing(false);
                })
        .Summary(s => s.TotalItems(items =>
                {
                    items.Add()
                        .SummaryType(SummaryType.Count)
                        .Column("NumIntervention")
                        .ShowInColumn("NumIntervention")
                        .DisplayFormat("Count : {0}");
                    items.Add()
                        .SummaryType(SummaryType.Sum)
                        .Column("DureeInervention")
                        .ShowInColumn("DureeInervention")
                        .DisplayFormat("Total : {0} Mns");
                    items.Add()
                        .SummaryType(SummaryType.Sum)
                        .Column("Valorisation")
                        .ShowInColumn("Valorisation")
                        .DisplayFormat("Total : {0} DZD");
                    items.Add()
                        .SummaryType(SummaryType.Avg)
                        .Column("DureeInervention")
                        .ShowInColumn("CodeMachine")
                        .ValueFormat("#,##0.00")
                        .DisplayFormat("En moyenne : {0} Mns");
                }))
        .DataSource(ds => ds.Mvc()
            .Controller("SuiviEntretienPersonnels")
            .LoadAction("GetSuiviPersonnel")
            .LoadParams(new
            {
                id = new JS("SuiviInterventionGridData.id")
            }
            )
        )
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 197 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 199 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
 using (Html.DevExtreme().NamedTemplate("SuiviEntretiensGrid"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 201 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
Write(Html.DevExtreme().DataGrid<DevKbfSteel.Entities.SuiviEntretienPersonnels>()
        .ShowBorders(true)
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
            editing.Mode(GridEditMode.Popup)
            .Popup(p => p.Title("Editer Demande")
            .ShowTitle(true)
            .Position(pos => pos.My(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).At(HorizontalAlignment.Center, VerticalAlignment.Top).Of(new JS("window"))));
        })

        .Columns(columns =>
        {
            columns.AddFor(m => m.DateIncidant).Format("yyyy-MM-dd")
            .DataType(GridColumnDataType.DateTime)
            .HeaderFilter(headerfilter => headerfilter.GroupInterval(HeaderFilterGroupInterval.Month));
            columns.AddFor(m => m.Poste);
            columns.AddFor(m => m.Sujet);
            columns.AddFor(m => m.Lieu);
            columns.AddFor(m => m.Explication);
            columns.AddFor(m => m.Observation).Caption("Observation/Décision");
            columns.Add()
                .Type(GridCommandColumnType.Buttons)
                .Width(110)
                .Buttons(b =>
                {
                    b.Add().Name(GridColumnButtonName.Edit);
                    b.Add().Name(GridColumnButtonName.Delete);
                    b.Add()
                    .Hint("Imprimer suivi personnel")
                    .OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("imprimerSuiviPerso");
    PopWriter();
}
))
                           .Icon("print");
                });
        })
        .DataSource(ds => ds.Mvc()
            .Controller("SuiviEntretienPersonnels")
            .LoadAction("GetSuiviEntretiens")
            .InsertAction("PostEntretien")
            .UpdateAction("PutEntretien")
            .DeleteAction("DeleteEntretien")
            .Key("IdEntretien")
            .LoadParams(new
            {
                id = new JS("SuiviInterventionGridData.id")
            }
            )
        )
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 258 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
     
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 260 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
Write(Html.DevExtreme().Popup()
        .ID("Informations-popup")
        .ShowTitle(true)
        .Title("Détails du personnel")
        .Visible(false)
        .DragEnabled(false)
        .CloseOnOutsideClick(true)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 268 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
 using (Html.DevExtreme().NamedTemplate("Informations-template"))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 270 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
     using (Html.BeginForm("Get", "MethodeManager", FormMethod.Get))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 272 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
    Write(Html.DevExtreme().Form<DevKbfSteel.Entities.RhListeDesEmployes>()
        .ShowValidationSummary(true)
        .Items(items =>
        {
            items.AddGroup()
                    .ColCount(2)
                    .Caption("Informations Personnel")
                    .Items(groupItems =>
                    {
                        groupItems.AddGroup().Items(secondGroupItems => {
                            secondGroupItems.AddSimpleFor(m => m.Nom);
                            secondGroupItems.AddSimpleFor(m => m.TelProfesionnel);
                            secondGroupItems.AddSimpleFor(m => m.CodeSpecialité).Editor(e => e.Lookup()
                            .DataSource(ds => ds.WebApi().Controller("GestionPersonnelsMecanique").LoadAction("SpecieliteLookup").Key("Value"))
                            .ValueExpr("Value")
                            .DisplayExpr("Text")
                            );
                        });
                        groupItems.AddGroup().Items(secondGroupItems =>
                        {
                            secondGroupItems.AddSimpleFor(m => m.Prenom);
                            secondGroupItems.AddSimpleFor(m => m.Adresse);
                            secondGroupItems.AddSimpleFor(m => m.CodeEquipe).Editor(e => e.Lookup()
                            .DataSource(ds => ds.WebApi().Controller("GestionPersonnelsMecanique").LoadAction("EquipeLookup").Key("Value"))
                            .ValueExpr("Value")
                            .DisplayExpr("Text")
                            );
                        });
                    });
        })
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 302 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
         
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 304 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
Write(Html.DevExtreme().TabPanel()
    .Items(items =>
    {
        items.Add()
            .Title("Suivi des interventions")
            .Template(new TemplateName("SuiviInterventionGrid"))
            ;
        items.Add()
            .Title("Suivi des entretiens")
            .Template(new TemplateName("SuiviEntretiensGrid"))
            ;
    })
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 316 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script>

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
    var imprimerSuiviPerso = function (e) {
        var num = e.row.data.Id;
        window.open( ' ");
#nullable restore
#line 337 "C:\Users\HP\source\repos\DevKbfSteel\DevKbfSteel\Areas\MecaniqueManager\Views\MecaniqueManager\GestionPersonnels.cshtml"
                  Write(Url.Action("FicheSuiviPersonnelViewer", "MecaniqueManager"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?id=\'+num, \'_blank\').focus();\r\n    }\r\n\r\n</script>");
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
