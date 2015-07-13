using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(a2m.Startup))]
namespace a2m
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
