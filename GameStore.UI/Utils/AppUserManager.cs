using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameStore.UI.Utils
{
    public class AppUserManager:UserManager<IdentityUser>
    {
        public AppUserManager(IUserStore<IdentityUser> stor):base(stor)
        {

        }
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options,IOwinContext owin)
        {
            var dbcontext = owin.Get<DbContext>();
            var manager = new AppUserManager(new UserStore<IdentityUser>(dbcontext));
            manager.UserValidator = new UserValidator<IdentityUser>(manager) {
                RequireUniqueEmail = true,
                AllowOnlyAlphanumericUserNames=true
            };
            manager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequireLowercase = true,
                RequiredLength = 5,
                RequireNonLetterOrDigit=true,
                RequireUppercase=true
            };

            return manager;
        }
    }
}