using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Server.Data;

[assembly: HostingStartup(typeof(PetShop.Server.Areas.Identity.IdentityHostingStartup))]
namespace PetShop.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<PetShopServerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PetShopServerContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PetShopServerContext>();
            });
        }
    }
}



