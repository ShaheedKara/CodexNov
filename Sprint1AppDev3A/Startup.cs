using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sprint1AppDev3A.Startup))]
namespace Sprint1AppDev3A
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
