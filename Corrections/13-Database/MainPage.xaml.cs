using _13_Database.Helper;
using _13_Database.Models;
using _13_Database.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _13_Database
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public PostHelper PostHelper { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.PostHelper = new PostHelper();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var fileExists = await PostHelper.CheckFileExists(App.DB_PATH);
            if (fileExists)
            {
                await LoadJson();
            }else
            {
                // Récupère les entrées en base
                ((MainPageViewModel)this.DataContext).Posts = this.PostHelper.GetAll();
            }
        }

        public async Task LoadJson()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(new Uri("http://jsonplaceholder.typicode.com/posts"));

                if (response.IsSuccessStatusCode)
                {
                    var postsString = await response.Content.ReadAsStringAsync();

                    var posts = JsonConvert.DeserializeObject<ObservableCollection<Post>>(postsString);
                    
                    await this.PostHelper.OnCreate<Post>(App.DB_PATH);

                    await InsertPosts(posts);
                }
            }
        }

        // Insert les données en base
        public async Task InsertPosts(ObservableCollection<Post> posts)
        {
            var vm = (MainPageViewModel)this.DataContext;

            foreach (var p in posts)
            {
                await Task.Run(() =>
                 {
                     this.PostHelper.Insert(p);
                 });
                vm.Posts.Add(p);
            }

        }
    }
}
