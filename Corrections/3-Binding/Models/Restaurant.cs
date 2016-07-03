using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Binding.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PictureUri { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Menu> Menus { get; set; }

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
