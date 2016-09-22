using System;
using System.Threading.Tasks;

namespace MoviesMobileApp.Services
{
    /// <summary>
    /// Navigation service interface
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigate to detail page
        /// </summary>
        /// <param name="detail">Detail data that need to be filled in page</param>
        /// <returns></returns>
        Task NavigateToDetail(int movieIndex);

        /// <summary>
        /// Navigate back in navigation stack
        /// </summary>
        /// <returns></returns>
        Task NavigateBack();

        /// <summary>
        /// Open external Uri
        /// </summary>
        /// <param name="uri">Uri to open</param>
        void OpenUri(Uri uri);
    }
}
