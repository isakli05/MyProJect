using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Attributes
{
    public class RoleAttribute:AuthorizeAttribute
    {
        private AppUserService _appUserService;
        private string[] _roles;
        public RoleAttribute(params string[] roles)
        {
            _appUserService = new AppUserService();
            _roles = new string[roles.Length];
            Array.Copy(roles, _roles, roles.Length);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            AppUser currentUser = _appUserService.FindByUserName(HttpContext.Current.User.Identity.Name);
            foreach (var item in _roles)
            {

                if (currentUser.Role.ToString().ToLower() == item.ToLower())
                    return true;
            }

            HttpContext.Current.Response.Redirect("~/Error/NFound");
            return false;
        }
    }
}