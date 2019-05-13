using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebSalt.Startup))]

namespace WebSalt
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
