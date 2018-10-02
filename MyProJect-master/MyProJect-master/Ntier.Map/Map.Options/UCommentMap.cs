using NTier.Core.Core.Map;
using NTier.Model.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Map.Map.Options
{
    public class UCommentMap:CoreMap<UComment>
    {
        public UCommentMap()
        {
            ToTable("dbo.Comment");
            Property(comment => comment.Comment).IsOptional();


           // HasRequired(comment => comment.Product)
           // .WithMany(comment => comment.Comments)
           // .HasForeignKey(comment => comment.ProductID)
           // .WillCascadeOnDelete(false);

           // HasRequired(comment => comment.User)
           //.WithMany(comment => comment.Comments)
           //.HasForeignKey(comment => comment.ProductID)
           //.WillCascadeOnDelete(false);

        }
    }
}
