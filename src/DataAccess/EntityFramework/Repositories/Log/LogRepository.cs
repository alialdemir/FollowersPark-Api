using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Extensions;
using FollowersPark.Models.Log;
using FollowersPark.Models.PagedList;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Log
{
    public class LogRepository : RepositoryBase<Tables.Log>, ILogRepository
    {
        private readonly IMapper _mapper;

        public LogRepository(IDbContextFactory dbContextFactory,
                             IMapper mapper) : base(dbContextFactory)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Kullanıcı id'ye göre log verilerini verir
        /// </summary>
        /// <param name="userId">Kullanıcı id</param>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Log</returns>
        public IPagedList<LogModel> GetLogByUserId(string userId, int taskId, Pageable pageable)
        {
            return Query()
                    .Where(x => x.UserId == userId && x.TaskId == taskId)
                    .Select(model => _mapper.Map<LogModel>(model))
                    .ToPagedList(pageable);
        }
    }
}