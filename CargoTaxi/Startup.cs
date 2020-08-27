using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CargoTaxi.Startup))]
namespace CargoTaxi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
