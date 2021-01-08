using AutoMapper;
using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.Extensions;
using FollowersPark.Models.DirectMessage;
using FollowersPark.Models.PagedList;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.DirectMessage
{
    public class DirectMessageRepository : RepositoryBase<Tables.DirectMessage>, IDirectMessageRepository
    {
        private readonly IMapper _mapper;

        public DirectMessageRepository(IDbContextFactory dbFactory,
                                       IMapper mapper) : base(dbFactory)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Kullanıcıya ait mesaj listesi
        /// </summary>
        /// <param name="userId">Kullanıcı id</param>
        /// <param name="pageable">Sayfalama</param>
        /// <returns>Mesaj listesi</returns>
        public IPagedList<DirectMessageModel> GetDirectMessageByUserId(string userId, Pageable pageable)
        {
            return Query()
                    .Where(x => x.UserId == userId)
                    .Select(model => _mapper.Map<DirectMessageModel>(model))
                    .ToPagedList(pageable);
        }
    }
}