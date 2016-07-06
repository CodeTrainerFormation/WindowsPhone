using _5_Collections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Collections.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private Restaurant _restaurantSelected;

        public Restaurant RestaurantSelected
        {
            get { return _restaurantSelected; }
            set {
                SetProperty(ref this._restaurantSelected, value);
            }
        }

        public DetailViewModel()
        {

        }
    }
}
