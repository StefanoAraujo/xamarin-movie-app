using MoviesMobileApp.Models;
using MoviesMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MoviesMobileApp.Extensions;

[assembly: Xamarin.Forms.Dependency(typeof(MoviesMobileApp.Services.NavigationService))]
namespace MoviesMobileApp.Services
{
    /// <summary>
    /// Responsible for navigation in application
    /// </summary>
    public class NavigationService : INavigationService
    {
        private INavigation _navigation
        {
            get { return App.Navigation; }
        }

        private ICacheService<IMovieItem> _cacheService;
        
        public NavigationService()
        {
            _cacheService = DependencyService.Get<ICacheService<IMovieItem>>();
        }

        /*
        public NavigationService(INavigation navigation)
        {
            _navigation = navigation;
        }
        */

        public Task NavigateBack()
        {
           return _navigation.PopAsync();
        }

        public async Task NavigateToDetail(int index)
        {
            var item = await _cacheService.GetItemAtAsync(index);
            await _navigation.PushAsync(new MovieDetailPage() { BindingContext = item.ToMovieDetailViewModel() });
        }

        public void OpenUri(Uri uri)
        {
            Device.OpenUri(uri);
        }
    }
}
