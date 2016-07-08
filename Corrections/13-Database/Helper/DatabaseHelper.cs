using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Database.Helper
{
    public class DatabaseHelper
    {
        public SQLiteConnection Provider { get; set; }

        public  async Task<bool> OnCreate<T>(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (Provider = new SQLiteConnection(DB_PATH))
                    {
                        Provider.CreateTable<T>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
