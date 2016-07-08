using _13_Database.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Database.Helper
{
    public class PostHelper : DatabaseHelper
    {

        public Post GetById(int postId)
        {
            using (var Provider = new SQLiteConnection(App.DB_PATH))
            {
                
                var existingPost = Provider.Find<Post>(postId);
                return existingPost;
            }
        }
        // Retrieve the all post list from the database. 
        public ObservableCollection<Post> GetAll()
        {
            using (var Provider = new SQLiteConnection(App.DB_PATH))
            {
                List<Post> myCollection = Provider.Table<Post>().ToList<Post>();
                ObservableCollection<Post> PostList = new ObservableCollection<Post>(myCollection);
                return PostList;
            }
        }

        //Update existing conatct 
        public void Update(Post post)
        {
            using (var Provider = new SQLiteConnection(App.DB_PATH))
            {
                var existingPost = Provider.Query<Post>("select * from Post where Id =" + post.Id).FirstOrDefault();
                if (existingPost != null)
                {
                    existingPost.UserId = post.UserId;
                    existingPost.Title = post.Title;
                    existingPost.Body = post.Body;
                    Provider.RunInTransaction(() =>
                    {
                        Provider.Update(existingPost);
                    });
                }
            }
        }
        // Insert the new post in the Post table. 
        public void Insert(Post newpost)
        {
            using (var Provider = new SQLiteConnection(App.DB_PATH))
            {
                Provider.RunInTransaction(() =>
                {
                    Provider.Insert(newpost);
                });
            }
        }

        //Delete specific post 
        public void Delete(int Id)
        {
            using (var Provider = new SQLiteConnection(App.DB_PATH))
            {
                var existingPost = Provider.Query<Post>("select * from Post where Id =" + Id).FirstOrDefault();
                if (existingPost != null)
                {
                    Provider.RunInTransaction(() =>
                    {
                        Provider.Delete(existingPost);
                    });
                }
            }
        }
        //Delete all list or delete Post table 
        public void DeleteAll()
        {
            using (var Provider = new SQLiteConnection(App.DB_PATH))
            {
                Provider.DropTable<Post>();
                Provider.CreateTable<Post>();
                Provider.Dispose();
                Provider.Close();
            }
        }

    }
}
