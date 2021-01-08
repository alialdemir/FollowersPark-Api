using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Models.BlockList;
using FollowersPark.Models.PagedList;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.BlockList
{
    public interface IBlockListRepository : IRepositoryBase<Tables.BlockList>
    {
        IPagedList<BlockListModel> GetBlockListByUserId(string userId, Pageable pageable);
    }
}