using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesMobileApp.Services
{
    /// <summary>
    /// Platform specific file service, need implementation outside PCL
    /// </summary>
    public interface IFileService
    {
        string FileStoragePath { get; }
    }
}
