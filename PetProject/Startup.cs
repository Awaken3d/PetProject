using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetProject.Startup))]
namespace PetProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
