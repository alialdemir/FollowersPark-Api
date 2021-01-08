using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.Pricing;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Pricing
{
    public interface IPricingRepository : IRepositoryBase<Tables.Pricing>
    {
        IPagedList<PricingModel> GetPricing(Pageable pageable);
    }
}