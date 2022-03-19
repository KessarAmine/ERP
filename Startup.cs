using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DevExpress.AspNetCore;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using DevExpress.AspNetCore.Reporting;
using DevKbfSteel.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using DevKbfSteel.Data;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.SignalR;
using DevKbfSteel.Hubs;
using Microsoft.AspNetCore.Http.Connections;
using DevExpress.XtraReports.Security;
using Microsoft.AspNetCore.HttpOverrides;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;


namespace DevKbfSteel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddDevExpressControls();
            // Add framework services.
            services
                .AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddDbContext<KBFsteelContext>(ServiceLifetime.Scoped);
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            // Register reporting services in an application's dependency injection container.
            // Add MVC services.
            services
                .AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                .AddDefaultDashboardController(configurator => {
                    configurator.SetDataSourceStorage(new DataSourceInMemoryStorage());
                });
            services.ConfigureReportingServices(configurator => {
                configurator.ConfigureWebDocumentViewer(viewerConfigurator => {
                    viewerConfigurator.UseCachedReportSourceBuilder();
                });
            });
            services.AddRazorPages();
            services.AddSignalR();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath = new PathString("/node_modules"),
                EnableDirectoryBrowsing = true
            });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });
            app.UseDevExpressControls();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "ElectriqueManagerArea",
                    areaName: "ElectriqueManager",
                    pattern: "ElectriqueManager/{controller=ElectriqueManager}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "SodureManagerrArea",
                    areaName: "SodureManager",
                    pattern: "SodureManager/{controller=SodureManager}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "ExploitationManagerArea",
                    areaName: "ExploitationManager",
                    pattern: "ExploitationManager/{controller=ExploitationManager}/{action=DemandeTravailsExploitationRecieved}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "MaintenanceManagerArea",
                    areaName: "MaintenanceManager",
                    pattern: "MaintenanceManager/{controller=MaintenanceManager}/{action=DemandeTravailsMaintenanceRecieved}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "MecaniqueManagerArea",
                    areaName: "MecaniqueManager",
                    pattern: "MecaniqueManager/{controller=MecaniqueManager}/{action=DemandeTravailsMecaniqueManagerRecieved}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "MethodeManagerArea",
                    areaName: "MethodeManager",
                    pattern: "MethodeManager/{controller=MethodeManager}/{action=DemandeTravailsMethodeRecieved}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "UsinageManagerArea",
                    areaName: "UsinageManager",
                    pattern: "UsinageManager/{controller=UsinageManager}/{action=DemandeTravailsUsinageRecieved}/{id?}");

                endpoints.MapAreaControllerRoute(
                  name: "ApprovisionnementManagerArea",
                  areaName: "ApprovisionnementManager",
                  pattern: "ApprovisionnementManager/{controller=ApprovisionnementManager}/{action=DemandeAchatsRecieved}/{id?}");

                endpoints.MapAreaControllerRoute(
                  name: "RhManagerArea",
                  areaName: "RhManager",
                  pattern: "RhManager/{controller=RhManager}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                  name: "MagasinManagerArea",
                  areaName: "MagasinManager",
                  pattern: "MagasinManager/{controller=MagasinManager}/{action=index}/{id?}");
                endpoints.MapAreaControllerRoute(
                  name: "MagasinAgentArea",
                  areaName: "MagasinAgent",
                  pattern: "MagasinAgent/{controller=MagasinAgent}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                  name: "GestionnaireMagasinArea",
                  areaName: "GestionnaireMagasin",
                  pattern: "GestionnaireMagasin/{controller=GestionnaireMagasin}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                  name: "MagasinSuperviseurArea",
                  areaName: "MagasinSuperviseur",
                  pattern: "MagasinSuperviseur/{controller=MagasinSuperviseur}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                  name: "QualiteManagerArea",
                  areaName: "QualiteManager",
                  pattern: "QualiteManager/{controller=QualiteManager}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=DemandeTravailViewer}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MethodeManager}/{action=Index}/{id?}");
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboards");
                endpoints.MapRazorPages();
                endpoints.MapHub<NotificationHub>("/ NotificationHub", options =>
                {
                    options.Transports =
                        HttpTransportType.WebSockets |
                        HttpTransportType.LongPolling;
                });

            });
        }
    }
}