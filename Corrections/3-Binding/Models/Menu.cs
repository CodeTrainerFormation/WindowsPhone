using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Binding.Models
{
    public class Menu
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PictureUri { get; set; }

        public double Price { get; set; }

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
