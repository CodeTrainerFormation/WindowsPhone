using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Lifecycle.Models
{
    public class Restaurant
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string PictureUri { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }

        [JsonProperty("menus")]
        public List<Menu> Menus { get; set; }

        public double MenusAverage { get; set; }

        public Restaurant(string _name)
        {
            Id = Guid.NewGuid();
            Name = _name;
            PictureUri = "http://lorempixel.com/600/250/food";
            Comments = new List<Comment>();
            Menus = new List<Menu>();
        }
    }
}
