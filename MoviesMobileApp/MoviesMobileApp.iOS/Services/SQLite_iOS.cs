using System;
using MoviesMobileApp.iOS.Services;
using MoviesMobileApp.Services;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_iOS))]
namespace MoviesMobileApp.iOS.Services
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
    }
}