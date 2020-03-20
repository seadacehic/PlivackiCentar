using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PlivackiCentarWeb.App_Start.Startup))]

namespace PlivackiCentarWeb.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureServices();
        }
    }
}