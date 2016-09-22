using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MoviesMobileApp.Extensions;
using MoviesMobileApp.Services;
using MoviesMobileApp.Models;

namespace MoviesMobileApp.ViewModels
{
    /// <summary>
    /// View model with list of movies
    /// </summary>
    public class MoviesViewModel : INotifyPropertyChanged
    {
        #region Binding Propeertis
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MovieItemViewModel> MovieItems { get; protected set; } = new ObservableCollection<MovieItemViewModel>();
        //public VirtualizedList<IMovieItem> MovieItems { get; set; }
        private bool _isLoadig; 
        public bool IsLoading { get { return _isLoadig; } protected set { _isLoadig = value; OnPropertyChanged("IsLoading"); } }
        #endregion

        #region Commands
        private ICommand _loadNextPageCommand;
        public ICommand LoadNextPageCommand
        {
            get
            {
                return _loadNextPageCommand = _loadNextPageCommand ?? 
                    new Command<MovieItemViewModel>(async (item) => await ExecuteLoadNextPageCommand(), CanExecuteLoadNextPageCommand);
            }
        }

        private ICommand _showDetailPageCommand;
        public ICommand ShowDetailPageCommand
        {
            get
            {
                return _showDetailPageCommand = _showDetailPageCommand ?? 
                    new Command<MovieItemViewModel>(async (item) => await ExecuteShowDetailPageCommand(item));
            }
        }
        #endregion

        #region Services
        private IDataService<IMovieItem> _dataService;
        private INavigationService _navigationService;
        private int _loadedPages; // number of pages loaded in list
        #endregion

        #region Implementation
        public MoviesViewModel()
        {
            _dataService = _dataService ?? DependencyService.Get<IDataService<IMovieItem>>();
            _navigationService = _navigationService ?? DependencyService.Get<INavigationService>();

            LoadPage(1);
        }

        public MoviesViewModel(INavigationService navigationService, IDataService<IMovieItem> dataService) :this()
        {
            _navigationService = navigationService;
            _dataService = dataService;
        }

        /// <summary>
        /// Load page and add it to MovieItem list
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task LoadPage(int page)
        {
            IsLoading = true;
            var items = await _dataService.GetItemsAtAsync(page);

            if (items.Count == 0)
            {
                // tell user user?
            }

            foreach (var item in items)
            {
                MovieItems.Add(item.ToMovieItemViewModel());
            }

            _loadedPages = page;
            IsLoading = false;

        }

        public async Task ExecuteLoadNextPageCommand()
        {
            await LoadPage(_loadedPages + 1);
        }

        public bool CanExecuteLoadNextPageCommand(MovieItemViewModel item)
        {
            return !IsLoading && MovieItems.Count -1 == item.MovieIndex;
        }

        public async Task ExecuteShowDetailPageCommand(MovieItemViewModel item)
        {
            await _navigationService.NavigateToDetail(item.MovieIndex);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch
            {
            }
        }
        #endregion
    }
}
