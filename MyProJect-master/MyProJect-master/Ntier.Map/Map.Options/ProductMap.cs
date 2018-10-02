using NTier.Core.Core.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTier.Model.Model.Entities;

namespace NTier.Map.Map.Options
{
   public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(product => product.Name).HasMaxLength(90).IsOptional();
            Property(product => product.Price).IsOptional();
            Property(product => product.Quantity).IsOptional();
            Property(product => product.UnitsInStock).IsOptional();
            Property(product => product.ImagePath).IsOptional();

            HasMany(product => product.Comments)
                .WithRequired(comment => comment.Product)
                .HasForeignKey(comment => comment.ProductID)
                .WillCascadeOnDelete(false);
        }
    }
}
