using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesMobileApp.Settings
{

    public class RemoteSettings : IRemoteSettings
    {
        public string ApiKey { get; } = "f14320d4bbf682254a30a9775652c518";
        public string BaseUrl { get; } = "http://api.themoviedb.org/3";
        public string ImageBaseUrl { get; } = "https://image.tmdb.org";
        public string MoviePageBaseUrl { get; } = "https://www.themoviedb.org/movie";
        public string DiscoverMethod { get; } = "/discover/movie";
        public string PosterImageMethod { get; } = "/t/p/w370";
        public string PosterThumbImageMethod { get; } = "/t/p/w92";
        public string BackdropImageMethod { get; } = "/t/p/w600";
        public int ItemsOnPage { get; } = 20;
    }
}
