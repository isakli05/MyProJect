using NTier.Model.Model.Entities;
using NTier.Service.Service.Option;
using NTier.UI.Areas.Admin.Models;
using NTier.UI.Attributes;
using NTier.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.UI.Areas.Admin.Controllers
{
    [Role("Admin")]
     public class AppUserController : Controller
    {
        AppUserService _appuserService;
        public AppUserController()
        {
            _appuserService = new AppUserService();
        }

        public ActionResult List() => View(_appuserService.GetActive());

        public ActionResult Add() => View();


        [HttpPost]
        public RedirectToRouteResult Add(AppUser data, HttpPostedFileBase Image)
        {
            //Eğer böyle bir kullanıcı adı varsa tekrar kaydetme.
            if (_appuserService.Any(user => user.UserName == data.UserName)) return RedirectToAction("List", "AppUser", new { area = "Admin" });

            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                //Eğer bir hata aldıysak varsayılan bir fotoğraf oluşturup atıyoruz.
                data.ImagePath = "/Uploads/anon.png";
            }

            _appuserService.Add(data);

            return RedirectToAction("List", "AppUser", new { area = "Admin" });
        }

        public RedirectToRouteResult Delete(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "AppUser", new { area = "Admin" });

            _appuserService.Remove((Guid)id);

            return RedirectToAction("List", "AppUser", new { area = "Admin" });
        }

        [HttpGet]
        public ActionResult Update(Guid? id)
        {
            if (id == null) return RedirectToAction("List", "AppUser", new { area = "Admin" });

            AppUser data = _appuserService.GetById((Guid)id);
            AppUserVM model = new AppUserVM()
            {
                ID = data.ID,
                Name = data.Name,
                LastName = data.LastName,
                ImagePath = data.ImagePath,
                UserName = data.UserName,
                Password = data.Password,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                Role = data.Role
            };

            return View(model);
        }


        [HttpPost]
        public RedirectToRouteResult Update(AppUserVM data, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid) return RedirectToAction("List", "AppUser", new { area = "Admin" });

            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);

            AppUser user = _appuserService.GetById(data.ID);


            if (data.ImagePath != "0" && data.ImagePath != "1" && data.ImagePath != "2")
            {
                user.ImagePath = data.ImagePath;
            }

            user.Name = data.Name;
            user.LastName = data.LastName;
            user.PhoneNumber = data.PhoneNumber;
            user.Role = data.Role;
            user.Email = data.Email;
            user.UserName = data.UserName;
            user.Password = data.Password;

            _appuserService.Update(user);

            return RedirectToAction("List", "AppUser", new { area = "Admin" });
        }
    }
}