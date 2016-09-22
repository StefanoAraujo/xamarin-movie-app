using MoviesMobileApp.Models;
using System;
using Xamarin.Forms;

namespace MoviesMobileApp.ViewModels
{
    /// <summary>
    /// View model of item in main page listview
    /// </summary>
    public class MovieItemViewModel
    {
        public string Title { get; set; }//{ get { return Data.Title; } }
        public string Description { get; set; }//{ get { return string.Format("{0}% | {1}", RankPercentage, Data.Genres); } }
        public int RankPercentage { get; set; }//{ get { return (int)(Data.VoteAverage * 10); } }
        public ImageSource PosterSource { get; set; } //{ get { return new UriImageSource { Uri = new Uri(Data.PosterPath), CachingEnabled = true, CacheValidity = new TimeSpan(10, 0, 1, 0) }; } }
        //public IMovieItem Data { get; set; }
        public int MovieIndex { get; set;}
    }
}
