using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ejercicio1.Startup))]
namespace ejercicio1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
