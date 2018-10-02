using NTier.Core.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Core.Map
{
    public class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            Property(core => core.ID).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnOrder(1);
            Property(core => core.Status).HasColumnName("Status").IsOptional();

            Property(core => core.CreatedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.CreatedADUserName).IsOptional();
            Property(core => core.CreatedBy).IsOptional();
            Property(core => core.CreatedComputerName).IsOptional();
            Property(core => core.CreatedIp).IsOptional();

            Property(core => core.ModifiedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.ModifiedADUserName).IsOptional();
            Property(core => core.ModifiedBy).IsOptional();
            Property(core => core.ModifiedComputerName).IsOptional();
            Property(core => core.ModifiedIp).IsOptional();
        }
    }
}
