using NTier.Model.Model.Entities;
using NTier.Service.Service.Base;
using System;
using System.Collections.Generic;

namespace NTier.Service.Service.Option
{
    public class OrderDetailService : BaseService<OrderDetail>
    {
        public List<OrderDetail> GetDetailsByOrderID(Guid id) => GetDefault(od => od.OrderID == id);

    }
}
