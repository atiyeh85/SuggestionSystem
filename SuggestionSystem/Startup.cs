using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuggestionSystem.Startup))]
namespace SuggestionSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
