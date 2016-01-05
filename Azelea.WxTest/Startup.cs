using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Azelea.WxTest.Startup))]
namespace Azelea.WxTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}