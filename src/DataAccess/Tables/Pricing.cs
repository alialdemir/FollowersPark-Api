using FollowersPark.DataAccess.Tables.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class Pricing : EntityBase
    {
        public int PricingId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string SubTitle { get; set; }

        public decimal Price { get; set; }

        [MaxLength(3)]
        public string Currency { get; set; }

        public bool IsBestSeller { get; set; }

        public bool IsActive { get; set; } = true;
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}