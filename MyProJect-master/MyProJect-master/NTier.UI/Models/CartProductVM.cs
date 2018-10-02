using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTier.UI.Models
{
    public class CartProductVM
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}