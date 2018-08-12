using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginMVC.Startup))]
namespace LoginMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
