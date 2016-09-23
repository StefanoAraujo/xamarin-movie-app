using MoviesMobileApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesMobileApp.Models
{
    /// <summary>
    /// Movie item interface
    /// </summary>
    public interface IMovieItem
    {
        string PosterPath { get;}
        string PosterThumbPath { get; }
        bool Adult { get; }
        string Overview { get;  }
        string ReleaseDate { get;  }
        int Id { get;  }
        string OriginalTitle { get; }
        string OriginalLanguage { get;  }
        string Title { get;}
        string BackdropPath { get;  }
        float Popularity { get;  }
        int VoteCount { get;  }
        float VoteAverage { get; }
        int Index { get; } // index in list
        string Genres { get; } // genres separated with '/'
        string MovieUrl { get; }  // url to movie detal
    }
}
