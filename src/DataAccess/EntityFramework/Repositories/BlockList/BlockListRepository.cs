using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Extensions;
using FollowersPark.Models.BlockList;
using FollowersPark.Models.PagedList;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.BlockList
{
    public class BlockListRepository : RepositoryBase<Tables.BlockList>, IBlockListRepository
    {
        private readonly IMapper _mapper;

        public BlockListRepository(IDbContextFactory dbFactory,
                                   IMapper mapper) : base(dbFactory)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Kullanıcı id'sine ait engellenenler listesi
        /// </summary>
        /// <param name="userId">Kullanıcı id</param>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Engellenenler listesi</returns>
        public IPagedList<BlockListModel> GetBlockListByUserId(string userId, Pageable pageable)
        {
            return Query()
                    .Where(x => x.UserId == userId)
                    .Select(model => _mapper.Map<BlockListModel>(model))
                    .ToPagedList(pageable);
        }
    }
}