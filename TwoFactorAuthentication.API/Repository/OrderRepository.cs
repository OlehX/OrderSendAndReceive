using System;
using System.Collections.Generic;
using System.Linq;
using TwoFactorAuthentication.API.Interfaces;
using TwoFactorAuthentication.API.Models;

namespace TwoFactorAuthentication.API.Repository
{
    public class OrderRepository : IOrderModel
    {
        private OrderContext context;
        public OrderRepository(OrderContext _context)
        {
            context = _context;
        }
       
        public async void Add(OrderModel b)
        {
            context.Orders.Add(b);
            await context.SaveChangesAsync();

        }

        public void Edit(OrderModel b)
        {
            context.Entry(b).State = System.Data.Entity.EntityState.Modified;
        }

        public async void Remove(string Id)
        {
            OrderModel b = context.Orders.Find(Id);
            context.Orders.Remove(b);
            await context.SaveChangesAsync();
        }

        public IEnumerable<OrderModel> GetOrder()
        {
            return context.Orders;
        }

        public OrderModel FindById(int Id)
        {
            var c = (from r in context.Orders where r.Id == Id select r).FirstOrDefault();
            return c;
        }


    }
}