using System.ComponentModel.DataAnnotations;

namespace FollowersPark.Models.Pricing
{
    public class PricingModel
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
    }
}