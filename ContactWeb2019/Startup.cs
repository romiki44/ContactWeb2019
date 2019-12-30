using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactWeb2019.Startup))]
namespace ContactWeb2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
