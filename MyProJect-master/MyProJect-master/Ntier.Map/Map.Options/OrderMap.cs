using NTier.Core.Core.Map;
using NTier.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Map.Map.Options
{
    public class OrderMap : CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");

            HasRequired(order => order.AppUser)
                .WithMany(order => order.Orders)
                .HasForeignKey(order => order.AppUserID)
                .WillCascadeOnDelete(false);
        }
    }
}
