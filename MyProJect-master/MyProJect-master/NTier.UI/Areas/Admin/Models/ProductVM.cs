using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTier.UI.Areas.Admin.Models
{
    public class ProductVM
    {
        public Guid ID { get; set; }
        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public Guid CategoryID { get; set; }
        public Enum Status { get; set; }
    }
}