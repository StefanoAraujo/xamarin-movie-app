using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MoviesMobileApp.Database
{
    /// <summary>
    /// Database movie data model
    /// </summary>
    public class MovieDbItem : Models.IMovieItem
    {
        public int Id { get; set; }
        [PrimaryKey]
        public int Index { get; set; } // used as primary key -> we are caching position in user list, not movies
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string OriginalTitle { get; set; }
        public string PosterPath { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string ReleaseDate { get; set; }
        public string OriginalLanguage { get; set; }
        public string BackdropPath { get; set; }
        public float Popularity { get; set; }
        public int VoteCount { get; set; }
        public float VoteAverage { get; set; }
        public string Genres { get; set; }
        public string MovieUrl { get; set; }
    }
}
