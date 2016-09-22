using MoviesMobileApp.Models;
using MoviesMobileApp.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviesMobileApp.ViewModels
{
    /// <summary>
    /// Detail page view model
    /// </summary>
    public class MovieDetailViewModel
    {

        #region Binding Properties
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public int Year { get; set; }
        public string Overview { get; set; }
        public int RankPercentage { get; set; }
        public string ButtonText { get; set; }
        public string Genres { get; set; }
        public bool IsOriginalTitleVisible { get { return string.Compare(OriginalTitle, Title) != 0; } }
        public ImageSource BackdropImageSource {get;set; }
        public ImageSource PosterImageSource { get;set;}
        public Uri MoviePageUri { get; set; }
        #endregion

        #region Commands
        private ICommand _goBackCommand;
        public ICommand GoBackCommand
        {
            get { return _goBackCommand = _goBackCommand ?? new Command(async () => await _navigationService.NavigateBack()); }
        }
        private ICommand _openMovieLinkCommand;
        public ICommand OpenMovieLinkCommand
        {
            get { return _openMovieLinkCommand = _openMovieLinkCommand ?? new Command(() => _navigationService.OpenUri(MoviePageUri)); }
        }
        #endregion

        #region Services
        private INavigationService _navigationService;
        #endregion

        public MovieDetailViewModel()
        {
            _navigationService = _navigationService ?? DependencyService.Get<INavigationService>();
            
        }
    }
}
