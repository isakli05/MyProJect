using NTier.Model.Model.Entities;
using NTier.Core.Core.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Map.Map.Options
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");

            Property(user => user.ImagePath).IsOptional();
            Property(user => user.Email).IsOptional();
            Property(user => user.Role).IsOptional();
            Property(user => user.PhoneNumber).IsOptional();

            Property(user => user.Address).HasMaxLength(255).IsOptional();
            Property(user => user.Birthdate).HasColumnType("datetime2").IsOptional();

            Property(user => user.UserName).HasMaxLength(90).IsRequired();
            Property(user => user.Password).HasMaxLength(90).IsRequired();

            Property(user => user.Name).HasMaxLength(90).IsOptional();
            Property(user => user.LastName).HasMaxLength(90).IsOptional();


            HasMany(user => user.Comments)
                   .WithRequired(comment => comment.User)
                   .HasForeignKey(comment => comment.UserID)
                   .WillCascadeOnDelete(false);
        }
    }
}
