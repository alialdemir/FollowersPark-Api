using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.DataAccess.Tables.Entity;
using System;

namespace FollowersPark.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit<TEntity, TRepository>() where TEntity : class, IEntity, new()
                    where TRepository : IRepositoryBase<TEntity>;

        TRepository Repository<TEntity, TRepository>() where TEntity : class, IEntity, new()
                    where TRepository : IRepositoryBase<TEntity>;
    }
}