using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.Task;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Task
{
    public interface ITaskRepository : IRepositoryBase<Tables.Task>
    {
        IPagedList<TaskModel> GetTaskUserId(string userId, Pageable pageable);
    }
}