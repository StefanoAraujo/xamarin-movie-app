using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesMobileApp.Models;
using System.Diagnostics;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (MoviesMobileApp.Services.MoviesService))]
namespace MoviesMobileApp.Services
{
    /// <summary>
    /// Movie data service with internal cache
    /// </summary>
    class MoviesService : IDataService<IMovieItem>
    {
        private IRemoteService<IMovieItem> _remoteDataService;
        private ICacheService<IMovieItem> _cacheService;

        public MoviesService()
        {
            _remoteDataService = DependencyService.Get<IRemoteService<IMovieItem>>();
            _cacheService = DependencyService.Get<ICacheService<IMovieItem>>();
        }

        public MoviesService(IRemoteService<IMovieItem> remoteDataService, ICacheService<IMovieItem> cacheService)
        {
            _remoteDataService = remoteDataService;
            _cacheService = cacheService; 
        }

        /// <summary>
        /// Try request data from remote, if fails load data from cache
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<List<IMovieItem>> GetItemsAtAsync(int page)
        {
            try
            {
                var movieItems = await RequestDataAndSaveToCache(page);
                return movieItems;
            }
            catch
            {
                var pageCnt = GetCountOfItemsOnPage();
                return (await _cacheService.GetItemsAtAsync((page - 1) * pageCnt, pageCnt)).ToList();
            }
        }

        /// <summary>
        /// Request Data And Save them To Cache
        /// </summary>
        /// <param name="page">page number in remote repository</param>
        /// <returns>List of movie data items</returns>
        private async Task<List<IMovieItem>> RequestDataAndSaveToCache(int page)
        {
            var newItems = await _remoteDataService.GetItemsAtAsync(page);
            await _cacheService.InsertOrReplaceItemsAsync(newItems);
            return newItems;
        }

        public int GetCountOfItemsOnPage()
        {
            return _remoteDataService.GetCountOfItemsOnPage();
        }
    }
}
