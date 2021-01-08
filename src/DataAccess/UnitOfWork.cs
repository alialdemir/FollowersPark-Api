using FollowersPark.DataAccess.EntityFramework.Repositories.Base;
using FollowersPark.DataAccess.Tables.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;

namespace FollowersPark.DataAccess
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        #region Private Variables

        private readonly ILoggerFactory _loggerFactory;
        private readonly IServiceProvider _serviceProvider;
        private Hashtable _repositories;

        #endregion Private Variables

        #region Constructors

        public UnitOfWork(IServiceProvider serviceProvider,
                          ILoggerFactory loggerFactory)
        {
            _serviceProvider = serviceProvider;
            _loggerFactory = loggerFactory;
        }

        #endregion Constructors

        #region Methods

        public int Commit<TEntity, TRepository>() where TEntity : class, IEntity, new()
                    where TRepository : IRepositoryBase<TEntity>
        {
            var repository = Repository<TEntity, TRepository>();

            int returnValue = 0;

            using (var dbContextTransaction = repository.DbContext.Database.BeginTransaction())
            {
                try
                {
                    returnValue = repository.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    _loggerFactory
                        .CreateLogger(repository.GetType().Name)
                        .LogError("Save Changes", ex);

                    returnValue = 0;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }

        public TRepository Repository<TEntity, TRepository>() where TEntity : class, IEntity, new()
                    where TRepository : IRepositoryBase<TEntity>
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TRepository);

            if (_repositories.ContainsKey(type.Name))
            {
                return (TRepository)_repositories[type.Name];
            }

            var repository = _serviceProvider.GetService(type);

            _repositories.Add(type.Name, repository);

            return (TRepository)_repositories[type.Name];
        }

        #endregion Methods

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            foreach (IDisposable repository in _repositories.Values)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion Dispose
    }
}