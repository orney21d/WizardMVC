using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WizardMVC.Startup))]
namespace WizardMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
