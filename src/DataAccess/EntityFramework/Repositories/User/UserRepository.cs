using FollowersPark.DataAccess.EntityFramework.Repositories.Base;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.User
{
    public class UserRepository : RepositoryBase<Tables.User>, IUserRepository
    {
        public UserRepository(IDbContextFactory dbFactory) : base(dbFactory)
        {
        }
    }
}