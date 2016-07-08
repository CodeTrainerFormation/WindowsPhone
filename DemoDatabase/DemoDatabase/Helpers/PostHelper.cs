using DemoDatabase.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDatabase.Helpers
{
    public class PostHelper : DatabaseHelper
    {
        public void InsertPost(Post post)
        {
            using(Connection = new SQLiteConnection(this.DbPath))
            {
                this.Connection.Insert(post);
            }
        }

        public ObservableCollection<Post> GetAll()
        {
            using (Connection = new SQLiteConnection(this.DbPath))
            {
                List<Post> posts = this.Connection.Table<Post>().ToList();

                return new ObservableCollection<Post>(posts);
            } 
        }
    }
}
