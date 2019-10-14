using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;

namespace MusicStore.Models
{
    public class OrderDAL : IOrderDAL
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public Order FindById(int? id)
        {
            return storeDB.Orders.Find(id);
        }

        public void SaveNewOrder(Order order)
        {
            storeDB.Orders.Add(order);
            storeDB.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            storeDB.Entry(order).State = EntityState.Modified;
            storeDB.SaveChanges();
        }

        public void Dispose()
        {
            storeDB.Dispose();
        }
    }
}