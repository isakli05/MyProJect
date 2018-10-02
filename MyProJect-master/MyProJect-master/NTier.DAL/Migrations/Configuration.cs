namespace NTier.DAL.Migrations
{
    using NTier.Model.Model.Entities;
    using NTier.Utility;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Principal;

    internal sealed class Configuration : DbMigrationsConfiguration<NTier.DAL.DAL.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NTier.DAL.DAL.Context.ProjectContext context)
        {
            AppUser user = new AppUser()
            {
                Name = "isa",
                LastName = "kaya",
                UserName = "admin",
                Password = "123",
                Role = Role.Admin,
                Status = Core.Core.Entity.Enum.Status.Active,
                Address = "2475 Langtown Road,Wapakoneta,OH,Ohio",
                Email = "isakaya709@gmail.com",
                PhoneNumber = "567-356-2846",
                CreatedADUserName = WindowsIdentity.GetCurrent().Name,
                CreatedDate = DateTime.UtcNow,
                CreatedComputerName = Environment.MachineName,
                CreatedIp = RemoteIP.IpAddress
            };

            context.Users.AddOrUpdate(user);
            base.Seed(context);
        }
    }
}
