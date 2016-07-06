using _5_Collections.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace _5_Collections.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Restaurant> _restaurants;

        public ObservableCollection<Restaurant> Restaurants
        {
            get { return _restaurants; }
            set {
                SetProperty(ref this._restaurants, value);
            }
        }

        public MainPageViewModel()
        {
            this.LoadRestaurants();
        }


        public async void LoadRestaurants()
        {
            Uri jsonPath = new Uri("ms-appx:///Data/restaurants.json");
            StorageFile f = await StorageFile.GetFileFromApplicationUriAsync(jsonPath);

            string contentRestaurantsJson = await FileIO.ReadTextAsync(f);

            Restaurants = JsonConvert.DeserializeObject<ObservableCollection<Restaurant>>(contentRestaurantsJson);

            this.Restaurants.Select(r => { r.MenusAverage = Math.Round(r.Menus.Select(m => m.Rating).Average(), 2); return true; }).ToList();
            
        }

    }
}
