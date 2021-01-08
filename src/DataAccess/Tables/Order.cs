using FollowersPark.DataAccess.Tables.Entity;

namespace FollowersPark.DataAccess.Tables
{
    public class Order : EntityBase
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int PricingId { get; set; }
        public virtual Pricing Pricing { get; set; }
    }
}