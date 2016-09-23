using MoviesMobileApp.Services;
using MoviesMobileApp.UWP.Services;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace MoviesMobileApp.UWP.Services
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
        {
        }
        #region ISQLite implementation
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}
