using _13_Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Database.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Post> posts;

        public ObservableCollection<Post> Posts
        {
            get { return posts; }
            set { SetProperty(ref this.posts, value); }
        }

        public MainPageViewModel()
        {
            this.posts = new ObservableCollection<Post>();
        }

    }
}
