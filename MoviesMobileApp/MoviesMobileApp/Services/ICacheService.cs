using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesMobileApp.Models;

namespace MoviesMobileApp.Services
{
    /// <summary>
    /// Cache service interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICacheService<T>
    {
        /// <summary>
        /// Insert or replace items in cache async
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        Task InsertOrReplaceItemsAsync(IEnumerable<T> Items);
         
        /// <summary>
        /// Get items from desired position
        /// </summary>
        /// <param name="pageOffset">Page offset means number of item before start</param>
        /// <param name="count">items on page</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAtAsync(int pageOffset, int count);

        /// <summary>
        /// Get single item from desired position
        /// </summary>
        /// <param name="id">id of item</param>
        /// <returns></returns>
        Task<T> GetItemAtAsync(int id);


        /// <summary>
        /// Total count of cached items
        /// </summary>
        int ItemsCount { get; }

        /// <summary>
        /// Compute number of pages in cache
        /// </summary>
        /// <param name="pageCount">items per page</param>
        /// <returns>total sum of pages</returns>
        int LoadedPages(int pageCount);
    }
}
