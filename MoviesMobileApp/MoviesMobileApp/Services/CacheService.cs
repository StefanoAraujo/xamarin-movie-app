using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesMobileApp.Models;
using MoviesMobileApp.Database;
using MoviesMobileApp.Extensions;

[assembly: Xamarin.Forms.Dependency(typeof(MoviesMobileApp.Services.CacheService))]
namespace MoviesMobileApp.Services
{ 
    class CacheService : ICacheService<IMovieItem>
    {
        private MovieDatabase _movieDb;

        public CacheService()
        {
            _movieDb = new MovieDatabase();
        }

        /// <summary>
        /// Count of saved items in cache
        /// </summary>
        public int ItemsCount
        {
            get
            {
                return _movieDb.ItemsCount();
            }
        }

        /// <summary>
        /// Insert or replace items to cache
        /// </summary>
        /// <param name="Items"></param>
        /// <returns></returns>
        public Task InsertOrReplaceItemsAsync(IEnumerable<IMovieItem> Items)
        {
            return Task.Factory.StartNew(() => 
            {
                try
                {
                    foreach (var item in Items)
                    {
                        _movieDb.InsertOrReplace(item.ToMovieDbItem());
                    }
                }
                catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Cache Exception:" + e.Message);
                }
               
            });
        }

        /// <summary>
        /// Get items from cache
        /// </summary>
        /// <param name="pageOffset">offset of items -> not page number</param>
        /// <param name="count">count of wanted items</param>
        /// <returns>collection of items from cache</returns>
        public Task<IEnumerable<IMovieItem>> GetItemsAtAsync(int pageOffset, int count)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    return _movieDb.GetItemsAt(pageOffset, count).Cast<IMovieItem>();
                }
                catch
                {
                    return new List<IMovieItem>();
                }
            });
        }

        /// <summary>
        /// Get items from cache
        /// </summary>
        /// <param name="pageOffset">offset of items -> not page number</param>
        /// <param name="count">count of wanted items</param>
        /// <returns>collection of items from cache</returns>
        public Task<IMovieItem> GetItemAtAsync(int index)
        {
            return Task.Factory.StartNew(() =>
            {
                return _movieDb.GetItemAt(index) as IMovieItem;
            });
        }

        /// <summary>
        /// Compute loaded pages in cache
        /// </summary>
        /// <param name="pageCount">number of items per page</param>
        /// <returns>loaded pages in cache</returns>
        public int LoadedPages(int pageCount)
        {
            return ItemsCount / pageCount;
        }
    }
}
