using FollowersPark.DataAccess.Tables.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FollowersPark.DataAccess.Tables
{
    public class Order : EntityBase
    {
        public int OrderId { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int PricingId { get; set; }
        public virtual Pricing Pricing { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FinishDate { get; set; }

        public byte AccountsLimit { get; set; }
    }
}