using Microsoft.EntityFrameworkCore;
using System;

namespace FollowersPark.DataAccess
{
    public class DbContextFactory : Disposable, IDbContextFactory
    {
        private DbContext _dbContext;

        public DbContextFactory(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public DbContext Init()
        {
            return _dbContext;
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null)
                return;

            _dbContext.Dispose();
            _dbContext = null;

            base.Dispose(disposing);
        }
    }
}