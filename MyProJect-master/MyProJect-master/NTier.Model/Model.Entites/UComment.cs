using NTier.Core.Core.Entity;
using NTier.Model.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Model.Entites
{
   public class UComment:CoreEntity
    {
        public string Comment { get; set; }

        public Guid UserID { get; set; }
        public virtual AppUser User { get; set; }

        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

    }
}
