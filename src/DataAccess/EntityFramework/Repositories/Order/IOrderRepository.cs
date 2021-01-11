using FollowersPark.DataAccess.EntityFramework.Repositories.Base;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Order
{
    public interface IOrderRepository : IRepositoryBase<Tables.Order>
    {
        bool IsActive(string userId);
    }
}