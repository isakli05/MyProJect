using NTier.Core.Core.Map;
using NTier.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Map.Map.Options
{
  public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");
            Property(od => od.UnitPrice).IsOptional();
            Property(od => od.Quantity).IsOptional();

            HasRequired(od => od.Product)
             .WithMany(od => od.OrderDetails)
             .HasForeignKey(od => od.ProductID)
             .WillCascadeOnDelete(false);
        }
    }
}
