using FollowersPark.DataAccess.Tables.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FollowersPark.DataAccess.EntityFramework.Repositories.Base
{
    /// <summary>
    /// Repository arayüzü
    /// </summary>
    /// <typeparam name="T">Generic entity</typeparam>
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class, IEntity, new()
    {
        DbContext DbContext { get; }

        /// <summary>
        /// Entity sil
        /// </summary>
        /// <param name="id">Primary id</param>
        void Delete(int id);

        /// <summary>
        /// Parametreden gelen entity listesini siler
        /// </summary>
        /// <param name="entities">Silinecek entity listesi</param>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="predicate">Sorgu</param>
        /// <returns>Query sonucu</returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Entity ekle
        /// </summary>
        /// <param name="entity">Eklenen Entity</param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Entities ekle
        /// </summary>
        /// <param name="entities">Eklenen Entity</param>
        /// <returns>İşlem başaarılı ise true değilse false</returns>
        bool Insert(List<TEntity> entities);

        IQueryable<TEntity> Query();

        /// <summary>
        /// Save
        /// </summary>
        /// <returns>Değişiklik yapılan satır sayısı</returns>
        int SaveChanges();

        /// <summary>
        /// Entity güncelle
        /// </summary>
        /// <param name="entity">Güncellenen Entity</param>
        TEntity Update(TEntity entity);
    }
}