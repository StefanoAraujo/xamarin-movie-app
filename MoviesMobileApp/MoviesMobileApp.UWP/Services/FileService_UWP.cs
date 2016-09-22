using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesMobileApp.Services;
using MoviesMobileApp.UWP.Services;

[assembly: Xamarin.Forms.Dependency(typeof(FileService_UWP))]

namespace MoviesMobileApp.UWP.Services
{
    class FileService_UWP : IFileService
    {
        public string FileStoragePath
        {
            get
            {
                return Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            }
        }
    }
}
