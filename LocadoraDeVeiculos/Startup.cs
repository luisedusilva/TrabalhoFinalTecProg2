using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocadoraDeVeiculos.Startup))]
namespace LocadoraDeVeiculos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
