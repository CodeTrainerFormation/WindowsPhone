using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DemoDatabase.Helpers
{
    public class DatabaseHelper
    {
        public SQLiteConnection Connection { get; set; }

        public string DbName { get; set; }
        public string DbPath { get; set; }

        public DatabaseHelper()
        {
            this.DbName = "db.sqlite";
            this.DbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, this.DbName);
        }

        public async Task<int> OnCreate<T>()
        {
            using (this.Connection = new SQLiteConnection(this.DbPath))
            {
                
                if (this.CheckFileExists().Result)
                {
                    return this.Connection.CreateTable<T>();
                }
            }

            return 0;
        }

        public async Task<bool> CheckFileExists()
        {
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync(this.DbName);
                return true;
            }
            catch (FileNotFoundException e)
            {
                return false;
            }
        }
    }
}
