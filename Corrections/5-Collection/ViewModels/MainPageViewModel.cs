using _5_Collection.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace _5_Collection.ViewModels
{
    public class MainPageViewModel
    {

        public ObservableCollection<Restaurant> Restaurants { get; set; }

        public MainPageViewModel()
        {
            this.Restaurants = new ObservableCollection<Restaurant>();
            this.LoadJsonAsync();
        }

        public async void LoadJsonAsync()
        {
            StorageFile sampleFile
                = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Data/restaurants.json"));

            string contentFileJson = await FileIO.ReadTextAsync(sampleFile);

            ObservableCollection<Restaurant> restaurants = JsonConvert.DeserializeObject<ObservableCollection<Restaurant>>(contentFileJson);

            this.Restaurants = restaurants;
        }
    }
}
