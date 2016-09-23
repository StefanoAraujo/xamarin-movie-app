using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesMobileApp.Services;
using MoviesMobileApp.Windows.Services;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(FileService_Win81))]
namespace MoviesMobileApp.Windows.Services
{
    class FileService_Win81 :IFileService
    {
        public string FileStoragePath
        {
            get
            {
                return ApplicationData.Current.LocalFolder.Path;
            }
        }
    }
}
