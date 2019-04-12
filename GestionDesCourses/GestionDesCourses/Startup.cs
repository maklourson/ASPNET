using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionDesCourses.Startup))]
namespace GestionDesCourses
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
