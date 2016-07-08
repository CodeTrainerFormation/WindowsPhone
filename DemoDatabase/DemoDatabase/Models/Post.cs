using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDatabase.Models
{
    public class Post
    {
        [JsonProperty("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("user_id"), Indexed]
        public int UserId { get; set; }

        [JsonProperty("title"), MaxLength(255)]
        public string Title { get; set; }

        [JsonProperty("body"), MaxLength(255)]
        public string Body { get; set; }

    }
}
