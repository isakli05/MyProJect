using NTier.Core.Core.Entity;
using NTier.Model.Model.Entites;
using System;
using System.Collections.Generic;

namespace NTier.Model.Model.Entities
{
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3
    }


    public class AppUser : CoreEntity
    {
        public AppUser()
        {
            Orders = new List<Order>();
            Comments = new List<UComment>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<UComment> Comments { get; set; }


    }
}
