using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperApp.Models
{
    public class ProductRepository
    {
        SQLiteConnection database;
        public ProductRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<product>();
        }
        public IEnumerable<product> GetItems() 
        {
         return database.Table<product>().ToList();
        }
        public product GetItem(int id)
        {
            return database.Get<product>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<product>(id);
        }
        public int SaveItem(product item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }   
    }
}
