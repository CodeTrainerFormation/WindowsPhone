using DemoDatabase.Helpers;
using DemoDatabase.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.Web.Http;

namespace DemoDatabase.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private ObservableCollection<Post> posts;

        public ObservableCollection<Post> Posts
        {
            get { return posts; }
            set {
                SetProperty(ref this.posts, value);
            }
        }

        public string JsonLoaded { get; set; }
        public PostHelper PostHelper { get; set; }

        public MainPageViewModel()
        {
            this.PostHelper = new PostHelper();

            if (!PostHelper.CheckFileExists().Result)
            {
                this.LoadJson();
            }else
            {
                this.Posts = this.PostHelper.GetAll();
            }
        }

        public async Task LoadJson()
        {
            var remote = (string)Application.Current.Resources["remote_json"];

            using (var client = new HttpClient())
            {
                var target = string.Concat(remote, "posts");
                HttpResponseMessage response = await client.GetAsync(new Uri(target));

                if(response.IsSuccessStatusCode)
                {
                    JsonLoaded = await response.Content.ReadAsStringAsync();

                    await InsertJson();
                }
            }
        }

        public async Task InsertJson()
        {
            this.Posts = JsonConvert.DeserializeObject<ObservableCollection<Post>>(this.JsonLoaded);

            await Task.Run(() =>
            {
                foreach (var p in this.Posts)
                {
                    this.PostHelper.InsertPost(p);
                }
            });
            
        }

    }
}
