using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Extensions;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.Pricing;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Pricing
{
    public class PricingRepository : RepositoryBase<Tables.Pricing>, IPricingRepository
    {
        private readonly IMapper _mapper;

        public PricingRepository(IDbContextFactory dbContextFactory,
                                 IMapper mapper) : base(dbContextFactory)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Fiyat listesi
        /// </summary>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Fiyat listesi</returns>
        public IPagedList<PricingModel> GetPricing(Pageable pageable)
        {
            return Query()
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.PricingId)
                    .Select(model => _mapper.Map<PricingModel>(model))
                    .ToPagedList(pageable);
        }
    }
}