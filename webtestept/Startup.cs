using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webtestept.Startup))]
namespace webtestept
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
