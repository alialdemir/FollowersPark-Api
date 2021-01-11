using FollowersPark.DataAccess.EntityFramework.Repositories.Base;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.InstagramAccount
{
    public class InstagramAccountRepository : RepositoryBase<Tables.InstagramAccount>, IInstagramAccountRepository
    {
        public InstagramAccountRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}