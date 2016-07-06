using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Lifecycle.Models
{
    public class Menu
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("picture")]
        public string PictureUri { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        public Menu(string _name, double _price, double _rating)
        {
            Id = Guid.NewGuid();
            PictureUri = "http://lorempixel.com/48/48/food";
            Name = _name;
            Price = _price;
            Rating = _rating;
        }
    }
}
