using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.User;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.UserList
{
    public interface IUserListRepository : IRepositoryBase<Tables.UserList>
    {
        IPagedList<UserListModel> GetUserListByUserId(string userId, Pageable pageable);
    }
}