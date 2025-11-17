using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laboratorio9_Eje3.Startup))]
namespace Laboratorio9_Eje3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
