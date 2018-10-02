using NTier.Core.Core.Entity;
using NTier.Core.Core.Entity.Enum;
using NTier.Map.Map.Options;
using NTier.Model.Model.Entities;
using NTier.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NTier.DAL.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=DESKTOP-ISA\SQLEXPRESS;Database=MyProject_MVC;Integrated Security=true";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public override int SaveChanges()
        {

            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.UtcNow;
           
            string ip = RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.Status = Status.Active;
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedDate = date;
                        entity.CreatedIp = ip;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedDate = date;
                        entity.ModifiedIp = ip;
                    }
                }
            }
            return base.SaveChanges();  
        }
    }

    
}
