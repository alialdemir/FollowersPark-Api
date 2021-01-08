using FollowersPark.Models.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FollowersPark.Extensions
{
    public static class PagedListExtension
    {
        /// <summary>
        /// IQueryable tipindeki query'leri apiden dönüş yapabilecek türde(ServiceModel) dönüştürür
        /// </summary>
        /// <typeparam name="TSource">Generic model type</typeparam>
        /// <param name="source">query</param>
        /// <param name="pageable">Paging</param>
        /// <returns>ServiceModel<TSource> service result</returns>
        public static IPagedList<TSource> ToPagedList<TSource>(this IQueryable<TSource> source, Pageable pageable)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (pageable == null)
                throw new ArgumentNullException(nameof(pageable));

            int count = source.Count();

            IList<TSource> items = null;
            if (HasNextPage(count, pageable))
            {
                items = source
                            .Skip(pageable.Offset)
                            .Take(pageable.PageSize.Value)
                            .ToList();
            }

            return new PagedList<TSource>(items, pageable.PageNumber.Value, pageable.PageSize.Value, count);
        }

        private static bool HasNextPage(long count, Pageable pageable)
        {
            if (pageable.PageNumber <= 0 || pageable.PageSize <= 0)
                return false;

            return !((pageable.PageNumber - 1) > count / pageable.PageSize);
        }
    }
}