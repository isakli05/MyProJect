using NTier.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTier.UI.Areas.Admin.Models
{
    public class AppUserVM
    {
        [Required]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola Giriniz")]
        public string Password { get; set; }

        public Role Role { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Hatalı E-Posta Formatı!")]
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}