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
using System.IO;
using Xamarin.Forms;
using MoviesMobileApp.Services;
using MoviesMobileApp.Droid.Services;

[assembly: Dependency(typeof(SQLite_Android))]
namespace MoviesMobileApp.Droid.Services
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
    }
}