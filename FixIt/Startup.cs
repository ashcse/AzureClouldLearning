using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FixIt.Startup))]
namespace FixIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
