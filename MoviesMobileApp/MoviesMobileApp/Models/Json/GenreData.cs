using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesMobileApp.Models
{
    /// <summary>
    /// Json response from movieDB
    /// </summary>
    public class GenreList
    {
        [JsonProperty(PropertyName = "genres")]
        public List<GenreData> Genres {get;set;}
    }
    /// <summary>
    /// Json response from movieDB
    /// </summary>
    public class GenreData
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
