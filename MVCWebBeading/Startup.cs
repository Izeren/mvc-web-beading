using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWebBeading.Startup))]
namespace MVCWebBeading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
