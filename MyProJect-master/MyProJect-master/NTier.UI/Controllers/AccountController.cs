using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using NTier.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NTier.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserService _appUserService;
        public AccountController()
        {
            _appUserService = new AppUserService();
        }


        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserService.FindByUserName(HttpContext.User.Identity.Name);
               if (user == null)
                    return RedirectToAction("Login", "Account", new { area = "" });
               else if (user.Role == Role.Admin)
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                else if (user.Role == Role.Member)
                    return RedirectToAction("Index", "Category", new { area = "Member" });
              

            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                if (_appUserService.CheckCredentials(data.UserName, data.Password))
                {
                    AppUser currentUser = _appUserService.FindByUserName(data.UserName);
                    string cookie = currentUser.UserName;

                    FormsAuthentication.SetAuthCookie(cookie, true);
                    
                    if (currentUser.Role == Role.Admin)
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    else if (currentUser.Role == Role.Member)
                        return RedirectToAction("Index", "Category", new { area = "Member" });
                }
            }
            ViewBag.Message = "Kullanıcı Adı veya Parola Yanlış!";

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult MemberAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberAdd(AppUser appUser)
        {
            _appUserService.Add(appUser);
            return RedirectToAction("Login", "Home");
        }
    }
}