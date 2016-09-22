using MoviesMobileApp.Database;
using MoviesMobileApp.Models;
using MoviesMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesMobileApp.Extensions
{
    /// <summary>
    /// Usefull extensions for converting movie items
    /// </summary>
    public static class HelperExtensions
    {
        public static MovieDbItem ToMovieDbItem(this IMovieItem item)
        {
            return new MovieDbItem()
            {
                Id = item.Id,
                Index = item.Index,
                Adult = item.Adult,
                BackdropPath = item.BackdropPath,
                OriginalLanguage = item.OriginalLanguage,
                OriginalTitle = item.OriginalTitle,
                Overview = item.Overview,
                Popularity = item.Popularity,
                PosterPath = item.PosterPath,
                ReleaseDate = item.ReleaseDate,
                Title = item.Title,
                VoteAverage = item.VoteAverage,
                VoteCount = item.VoteCount,
                Genres = item.Genres,
                MovieUrl = item.MovieUrl
            };
        }

        public static MovieItemViewModel ToMovieItemViewModel(this IMovieItem item)
        {
            return new MovieItemViewModel()
            {
               //Data = item,
               MovieIndex = item.Index,
               Title = item.Title,
               Description = string.Format("{0}% | {1}", (int)(item.VoteAverage * 10), item.Genres),
               PosterSource = new Xamarin.Forms.UriImageSource
               { Uri = new Uri(item.PosterPath), CachingEnabled = true, CacheValidity = new TimeSpan(10, 0, 1, 0) }
           };
        }

        public static MovieDetailViewModel ToMovieDetailViewModel(this IMovieItem movieItem)
        {
            return new MovieDetailViewModel
            {
                Title = movieItem.Title,
                OriginalTitle = movieItem.OriginalTitle,
                Genres = movieItem.Genres,
                Overview = movieItem.Overview,
                Year = Convert.ToDateTime(movieItem.ReleaseDate).Year,
                RankPercentage = (int)(movieItem.VoteAverage * 10),
                ButtonText = "Open Website",
                PosterImageSource = new UriImageSource()
                {
                    Uri = new Uri(movieItem.PosterPath),
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(10, 0, 1, 0)
                },
                BackdropImageSource = new UriImageSource()
                {
                    Uri = new Uri(movieItem.BackdropPath), // todo: what if empty?
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(10, 0, 1, 0)
                },
                MoviePageUri = new Uri(movieItem.MovieUrl),

        };
        }

    }
}
