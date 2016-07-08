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
            using (var connection = new SQLiteConnection(App.DB_PATH))
            {
                
                var existingPost = connection.Find<Post>(postId);
                return existingPost;
            }
        }
        // Recupère un post
        public ObservableCollection<Post> GetAll()
        {
            using (var connection = new SQLiteConnection(App.DB_PATH))
            {
                List<Post> myCollection = connection.Table<Post>().ToList<Post>();
                ObservableCollection<Post> PostList = new ObservableCollection<Post>(myCollection);
                return PostList;
            }
        }

        //Met à jour un post
        public void Update(Post post)
        {
            using (var connection = new SQLiteConnection(App.DB_PATH))
            {
                var existingPost = connection.Query<Post>("select * from Post where Id = ?", post.Id).FirstOrDefault();
                if (existingPost != null)
                {
                    existingPost.UserId = post.UserId;
                    existingPost.Title = post.Title;
                    existingPost.Body = post.Body;
                    connection.RunInTransaction(() =>
                    {
                        connection.Update(existingPost);
                    });
                }
            }
        }

        // Insert un post dans la table 
        public void Insert(Post newpost)
        {
            using (var connection = new SQLiteConnection(App.DB_PATH))
            {
                connection.RunInTransaction(() =>
                {
                    connection.Insert(newpost);
                });
            }
        }

        // Supprime un post
        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(App.DB_PATH))
            {
                var existingPost = connection.Query<Post>("select * from Post where Id = ?", id).FirstOrDefault();
                if (existingPost != null)
                {
                    connection.RunInTransaction(() =>
                    {
                        connection.Delete(existingPost);
                    });
                }
            }
        }

        // Supprime tous les posts 
        public void DeleteAll()
        {
            using (var connection = new SQLiteConnection(App.DB_PATH))
            {
                connection.DropTable<Post>();
                connection.CreateTable<Post>();
                connection.Dispose();
                connection.Close();
            }
        }

    }
}
