using System;
using DevKbfSteel.Areas.Identity.Data;
using DevKbfSteel.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DevKbfSteel.Areas.Identity.IdentityHostingStartup))]
namespace DevKbfSteel.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContextContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextContextConnection")));
                // set true if we want to confirm the email thus we connect
                services.AddDefaultIdentity<DevKbfSteelUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }
                )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContextContext>();
            });
        }
    }
}