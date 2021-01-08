using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Models.Log;
using FollowersPark.Models.PagedList;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Log
{
    public interface ILogRepository : IRepositoryBase<Tables.Log>
    {
        IPagedList<LogModel> GetLogByUserId(string userId, int taskId, Pageable pageable);
    }
}