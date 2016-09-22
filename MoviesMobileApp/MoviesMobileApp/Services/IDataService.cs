using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesMobileApp.Services
{
    /// <summary>
    /// Data service interface -> handle getting data from repository or something like that
    /// </summary>
    /// <typeparam name="T">type of data handled by service</typeparam>
    public interface IDataService<T> 
    {
        /// <summary>
        /// Gets items from page
        /// </summary>
        /// <param name="page">page number</param>
        /// <returns>List of requested items</returns>
        Task<List<T>> GetItemsAtAsync(int page);

        /// <summary>
        /// Retrive count of items on page
        /// </summary>
        /// <returns></returns>
        int GetCountOfItemsOnPage();
    }
}
