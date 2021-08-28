using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MSH.Web.Areas.Identity.IdentityHostingStartup))]
namespace MSH.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}