using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Lifecycle.Models
{
    public class Comment
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("author")]
        public Customer Author { get; set; }

        public Comment(Customer _author, string _content)
        {
            Id = Guid.NewGuid();
            Content = _content;
            Author = _author;
            CreatedAt = DateTime.Now;
        }
    }
}
