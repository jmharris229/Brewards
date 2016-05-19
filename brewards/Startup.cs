using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(brewards.Startup))]
namespace brewards
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
