using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using MoviesMobileApp.Models;
using MoviesMobileApp.Services;
using Xamarin.Forms;

namespace MoviesMobileApp.Database
{

    /// <summary>
    /// Movie database with moviedbitems
    /// </summary>
    public class MovieDatabase
    {
        SQLiteConnection _db { get; }
        static object _locker = new object();

        public const string DbFileName = "moviedb.db3";

        public MovieDatabase()
        {
            /*
            var rootFolderPath = DependencyService.Get<IFileService>().FileStoragePath;
            var dbPath = Path.Combine(rootFolderPath, DbFileName);
            _db = new SQLiteConnection(dbPath);
            */

            _db = DependencyService.Get<ISQLite>().GetConnection();

            _db.CreateTable<MovieDbItem>();
        }

        public MovieDbItem GetItemAt(int posId)
        {
            lock(_locker)
            {
                return _db.Get<MovieDbItem>(posId);
            }
        }

        public void Update(MovieDbItem item)
        {
            lock (_locker)
            {
                _db.Update(item);
            }
        }

        public int Insert(MovieDbItem item)
        {
            lock (_locker)
            {
                return _db.Insert(item);
            }
        }

        public int InsertOrReplace(MovieDbItem item)
        {
            lock (_locker)
            {
               return _db.InsertOrReplace(item);
            }
        }

        public int DeleteItem(MovieDbItem item)
        {
            lock (_locker)
            {
                return _db.Delete(item);
            }
        }

        public IEnumerable<MovieDbItem> GetItemsAt(int pageOffset, int count)
        {
            lock (_locker)
            {
                var items = new List<MovieDbItem>();
               
                // todo: optimalize with query
                for (int idx = pageOffset; idx < pageOffset + count; idx++)
                {
                    var item = _db.Get<MovieDbItem>(idx);
                    items.Add(item);
                }
               
                return items;
                //return _db.Query<MovieDbItem>("",new object()).Cast<IMovieItem>();
            }
        }

        public int ItemsCount()
        {
            lock (_locker)
            {
                return _db.Table<MovieDbItem>().ToList().Count; // not effective
            }
        }


    }
}
