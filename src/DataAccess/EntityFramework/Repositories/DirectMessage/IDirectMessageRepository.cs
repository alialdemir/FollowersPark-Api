using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Models.DirectMessage;
using FollowersPark.Models.PagedList;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.DirectMessage
{
    public interface IDirectMessageRepository : IRepositoryBase<Tables.DirectMessage>
    {
        IPagedList<DirectMessageModel> GetDirectMessageByUserId(string userId, Pageable pageable);
    }
}