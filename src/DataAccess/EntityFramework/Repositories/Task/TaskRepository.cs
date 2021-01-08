using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Extensions;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.Task;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Task
{
    public class TaskRepository : RepositoryBase<Tables.Task>, ITaskRepository
    {
        private readonly IMapper _mapper;

        public TaskRepository(IDbContextFactory dbContextFactory,
                              IMapper mapper) : base(dbContextFactory)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Kullanıcı id'ye ait taskları getirir
        /// </summary>
        /// <param name="userId">Kullanıcı id</param>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Task</returns>
        public IPagedList<TaskModel> GetTaskUserId(string userId, Pageable pageable)
        {
            return Query()
                    .Where(task => task.UserId == userId)
                    .Include(x => x.DirectMessage)
                    .OrderByDescending(x => x.Status)
                    .Select(task => _mapper.Map<TaskModel>(task))
                    .ToPagedList(pageable);
        }
    }
}