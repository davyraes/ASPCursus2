using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Bierenapplication.Startup))]
namespace MVC_Bierenapplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
