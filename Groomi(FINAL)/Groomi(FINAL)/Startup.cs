using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Groomi_FINAL_.Startup))]
namespace Groomi_FINAL_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
