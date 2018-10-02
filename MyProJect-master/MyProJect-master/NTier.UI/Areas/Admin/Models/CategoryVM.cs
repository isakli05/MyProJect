using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTier.UI.Areas.Admin.Models
{
    public class CategoryVM
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}