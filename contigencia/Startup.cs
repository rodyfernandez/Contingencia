using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(contigencia.Startup))]
namespace contigencia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
