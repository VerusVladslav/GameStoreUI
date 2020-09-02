using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using System.Web.Security;
using GameStore.DAL;
using System.Data.Entity;

[assembly: OwinStartup(typeof(GameStore.UI.Startup))]

namespace GameStore.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<DbContext>(() => new ApplicationContext());
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

            //  //  LoginPath = new PathString("Acount/Login")
            //});
        }
    }
}
