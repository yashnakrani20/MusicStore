using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreFinalTests.Fakes
{
    class FakeOrderDAL : IOrderDAL
    {
        public void Dispose()
        {
            return;
        }

        public int orderId = 6;
        public Order FindById(int? id)
        {
            if(id==5)
            {
                return new Order()
                {
                    OrderDate = DateTime.Now,
                    Username = "ghdeogks@gamil.com",
                    FirstName = "Daehan",
                    LastName = "Hong",
                    Address = "11 Fletcher Drive",
                    City = "Barrie",
                    State = "Ontario",
                    PostalCode = "L4M 5S2",
                    Country = "Canada",
                    Phone = "7059707312",
                    Email = "hdh0813@nate.com",
                    Total = 199
                };
            }
            return null;
        }

        public void SaveNewOrder(Order order)
        {
            return;
        }

        public void UpdateOrder(Order order)
        {
            return;
        }
    }
}
