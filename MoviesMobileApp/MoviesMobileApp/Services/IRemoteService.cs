using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesMobileApp.Models;
using MoviesMobileApp.Settings;

namespace MoviesMobileApp.Services
{
    /// <summary>
    /// Remote service interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRemoteService<T>: IDataService<T>
    { 
        // Settings of remote service
        IRemoteSettings Settings { get; }
    }
}
