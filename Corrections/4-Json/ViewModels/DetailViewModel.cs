using _4_Json.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace _4_Json.ViewModels
{
    public class DetailViewModel
    {
        public Restaurant Restaurant { get; set; }

        public DetailViewModel()
        {
            this.LoadJsonAsync();
        }

        public async void LoadJsonAsync()
        {
            StorageFile sampleFile
                = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Data/one_restaurant.json"));

            string contentFileJson = await FileIO.ReadTextAsync(sampleFile);

            Restaurant restaurant = JsonConvert.DeserializeObject<Restaurant>(contentFileJson);

            this.Restaurant = restaurant;
        }
    }
}
