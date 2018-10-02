using NTier.Model.Model.Entities;
using NTier.Service.Service.Base;
using System.Collections.Generic;
using System.Linq;
using NTier.Core.Core.Entity.Enum;

namespace NTier.Service.Service.Option
{
    public class OrderService:BaseService<Order>
    {
        public int PendingOrderCount() => GetDefault(x => x.isConfirmed == false && (x.Status == Status.Active || x.Status == Status.Updated)).Count;

        public List<Order> ListPendingOrders() => GetDefault(x => x.isConfirmed == false && (x.Status == Status.Active || x.Status == Status.Updated)).OrderByDescending(x=>x.CreatedDate).ToList();
        
    }
}
