using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(HappyLifeManagement.Startup))]

namespace HappyLifeManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
