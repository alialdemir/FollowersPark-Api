using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using System;
using System.Linq;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Order
{
    public class OrderRepository : RepositoryBase<Tables.Order>, IOrderRepository
    {
        public OrderRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        /// <summary>
        /// Kullanıcının ödenmiş siparişi var mı kontrol eder
        /// </summary>
        /// <param name="userId">Kullanıcı id</param>
        /// <returns>Hesap aktif ise true değilse false</returns>
        public bool IsActive(string userId)
        {
            return Query()
                     .OrderByDescending(x => x.FinishDate)
                     .Any(x => x.UserId == userId && x.FinishDate >= DateTime.UtcNow);
        }
    }
}