using _3_Binding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Binding.ViewModels
{
    public class DetailViewModel
    {
        public Restaurant Restaurant { get; set; }

        public DetailViewModel()
        {
            

            // Création d'un client
            Customer customer = new Customer("John", "Doe");

            // Création de quelques commentaires...
            List<Comment> comments = new List<Comment>()
            {
                new Comment(customer, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras pulvinar fringilla lacus ut vestibulum. Etiam blandit est vitae ante blandit feugiat. Integer ut mattis libero, vitae facilisis odio. Donec feugiat odio ut lacus ultricies, ut ultricies arcu maximus. Suspendisse leo metus, tempus quis nibh et, pulvinar sollicitudin dolor."),
                new Comment(customer, "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In hac habitasse platea dictumst. Sed neque quam, rhoncus feugiat sem eget, pulvinar ultrices libero. Morbi sollicitudin velit mauris, non lobortis leo vestibulum nec. Sed fermentum massa ac egestas commodo."),
                new Comment(customer, "Maecenas aliquet nisi id orci convallis, sed venenatis metus posuere. Sed ipsum mauris, finibus ut tortor non, ultrices accumsan neque. Integer ornare, elit non auctor semper, lorem nisi ornare velit, quis mattis purus nisi at purus. Sed sed blandit quam."),
                new Comment(customer, "In sagittis mattis ipsum sit amet ultrices. Fusce commodo elementum interdum. Sed vestibulum pulvinar sapien sit amet efficitur. Suspendisse iaculis porta mauris, ac lacinia ex eleifend sit amet. Etiam nec eleifend ex, eget ornare sapien. Proin condimentum urna mi. Mauris eget porta magna."),
            };

            // Création de quelques plats...
            List<Menu> menus = new List<Menu>()
            {
                new Menu("Pizza", 11.99, 4.2),
                new Menu("Choucroute", 14.49, 3.7),
                new Menu("Tartiflette", 17.99, 4.8),
                new Menu("Boeuf bourguignon", 19.99, 5),
            };

            // création d'un restaurant
            this.Restaurant = new Restaurant("Chez cotofrims");

            // Affectation de menus et commentaires au restaurant
            this.Restaurant.Comments = comments;
            this.Restaurant.Menus = menus;
        }
    }
}
