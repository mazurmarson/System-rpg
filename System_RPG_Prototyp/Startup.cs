using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(System_RPG_Prototyp.Startup))]
namespace System_RPG_Prototyp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
