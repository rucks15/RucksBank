using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBankUI.Startup))]
namespace MyBankUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
