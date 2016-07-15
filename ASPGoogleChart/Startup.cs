using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPGoogleChart.Startup))]
namespace ASPGoogleChart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
