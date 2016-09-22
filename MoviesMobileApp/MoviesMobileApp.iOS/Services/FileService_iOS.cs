using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoviesMobileApp.iOS.Services;
using MoviesMobileApp.Services;


[assembly: Xamarin.Forms.Dependency(typeof(FileService_iOS))]
namespace MoviesMobileApp.iOS.Services
{
    class FileService_iOS : IFileService
    {
        public string FileStoragePath
        {
            get
            {
               return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
        }
    }
}