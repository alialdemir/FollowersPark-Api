using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Extensions;
using FollowersPark.Models.PagedList;
using FollowersPark.Models.User;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.UserList
{
    public class UserListRepository : RepositoryBase<Tables.UserList>, IUserListRepository
    {
        private readonly IMapper _mapper;

        public UserListRepository(IDbContextFactory dbFactory,
                                  IMapper mapper) : base(dbFactory)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Kullanıcı id'sine ait kullanıcı isim listesi
        /// </summary>
        /// <param name="userId">Kullanıcı id</param>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Kullanıcı isim listesi</returns>
        public IPagedList<UserListModel> GetUserListByUserId(string userId, Pageable pageable)
        {
            return Query()
                    .Where(x => x.UserId == userId)
                    .Select(model => _mapper.Map<UserListModel>(model))
                    .ToPagedList(pageable);
        }
    }
}