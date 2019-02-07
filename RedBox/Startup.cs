using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedBox.Startup))]
namespace RedBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
