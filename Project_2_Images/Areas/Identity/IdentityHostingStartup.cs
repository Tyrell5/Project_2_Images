using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_2_Images.Areas.Identity.Data;
using Project_2_Images.Data;

[assembly: HostingStartup(typeof(Project_2_Images.Areas.Identity.IdentityHostingStartup))]
namespace Project_2_Images.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AythDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AythDbContextConnection")));

                services.AddDefaultIdentity<Project_2_ImagesUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AythDbContext>();
            });
        }
    }
}