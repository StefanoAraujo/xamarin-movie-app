using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MoviesMobileApp.Services;
using MoviesMobileApp.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(FileService_Android))]
namespace MoviesMobileApp.Droid.Services
{
    public class FileService_Android : IFileService
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