using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Laboratorio9_Eje2.Startup))]
namespace Laboratorio9_Eje2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
