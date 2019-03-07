using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuxMandados.Backend.Startup))]
namespace TuxMandados.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
