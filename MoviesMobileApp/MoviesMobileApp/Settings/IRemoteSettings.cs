using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(MoviesMobileApp.Settings.RemoteSettings))]
namespace MoviesMobileApp.Settings
{
    public interface IRemoteSettings
    {
        /// <summary>
        /// Apikey
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// Api baseUrl
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        /// Images base url
        /// </summary>
        string ImageBaseUrl { get; }

        /// <summary>
        /// Movies Base url
        /// </summary>
        string MoviePageBaseUrl { get; }

        /// <summary>
        /// Api method for discover new data
        /// </summary>
        string DiscoverMethod { get; }

        /// <summary>
        /// Small images path, use with image baseurl
        /// </summary>
        string SmallImageMethod { get; }

        /// <summary>
        /// Large images path, use with image baseurl
        /// </summary>
        string LargeImageMethod { get; }

        /// <summary>
        /// Count of items on page requested with remoteservice
        /// </summary>
        int ItemsOnPage { get; }
    }
}
