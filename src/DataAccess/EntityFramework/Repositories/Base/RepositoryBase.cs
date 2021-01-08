using FollowersPark.DataAccess.Tables.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Base
{
    public class RepositoryBase<TEntity> : Disposable, IRepositoryBase<TEntity>
         where TEntity : class, IEntity, new()
    {
        #region Properties and fields

        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        /// <summary>
        /// DbContext sınıfı
        /// </summary>
        public DbContext DbContext { get { return _context ?? (_context = DbContextFactory.Init()); } }

        protected IDbContextFactory DbContextFactory
        {
            get;
            private set;
        }

        protected DbSet<TEntity> DbSet
        {
            get { return _dbSet ?? (_dbSet = DbContext.Set<TEntity>()); }
        }

        #endregion Properties and fields

        #region Constructors

        public RepositoryBase(IDbContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        #endregion Constructors

        #region CRUD operations

        /// <summary>
        /// Silme işlemi
        /// </summary>
        /// <param name="id">Primary id</param>
        public virtual void Delete(int id)
        {
            var deleteEntity = DbContext.Entry(GetById(id));
            if (deleteEntity == null)
                return;

            deleteEntity.Entity.Deleted = true;

            Update(deleteEntity.Entity);
        }

        /// <summary>
        /// Toplu silme işlemi
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Deleted = true;

                Update(entity);
            }
        }

        /// <summary>
        /// Entities içinde arama yapmar
        /// örneğin:  Find(f => f.UserId >0).ToList() OR FirstOrDefault(); vb.
        /// </summary>
        /// <returns>Aranan değerler</returns>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        /// <summary>
        /// Parametreden gelen primary key'e ait tek bir nesne
        /// </summary>
        /// <param name="id">Primary id</param>
        /// <returns>Entity</returns>
        public TEntity GetById(object id)
        {
            var entity = DbSet.Find(id);
            if (entity == null)
                return null;

            return entity;
        }

        /// <summary>
        /// Entity ekleme
        /// </summary>
        /// <param name="entity">Entity modeli</param>
        public virtual TEntity Insert(TEntity entity)
        {
            var addedEntity = DbContext.Entry(entity);
            addedEntity.State = EntityState.Added;

            SaveChanges();

            return entity;
        }

        /// <summary>
        /// Entities ekle
        /// </summary>
        /// <param name="entities">Eklenen Entity</param>
        /// <returns>İşlem başaarılı ise true değilse false</returns>
        public bool Insert(List<TEntity> entities)
        {
            DbContext.AddRange(entities);

            SaveChanges();

            return true;
        }

        /// <summary>
        /// Tüm kayıtları döndürür
        /// </summary>
        /// <returns>Queryable nesnesi</returns>
        public virtual IQueryable<TEntity> Query()
        {
            return DbSet
                .AsNoTracking()
                .AsQueryable()
                .OrderByDescending(x => x.CreatedDate);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns>Değişiklik yapılan satır sayısı</returns>
        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// Entity güncelleme
        /// </summary>
        /// <param name="entity">Entity modeli</param>
        public virtual TEntity Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;

            var updatedEntity = DbContext.Entry(entity);

            updatedEntity.State = EntityState.Modified;

            updatedEntity.Property(x => x.CreatedDate).IsModified = false;

            SaveChanges();

            return entity;
        }

        #endregion CRUD operations
    }
}