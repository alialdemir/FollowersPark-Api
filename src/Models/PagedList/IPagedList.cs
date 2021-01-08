using System.Collections.Generic;

namespace FollowersPark.Models.PagedList
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T>
    {
        /// <summary>
        /// Items
        /// </summary>
        public IList<T> Items { get; set; }

        /// <summary>
        /// Page index
        /// </summary>
        int PageIndex { get; }

        /// <summary>
        /// Page size
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Total count
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Total pages
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Has previous page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Has next age
        /// </summary>
        bool HasNextPage { get; }
    }
}