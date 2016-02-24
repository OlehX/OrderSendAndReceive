
using System;
using System.Data.Entity;
using TwoFactorAuthentication.API.Models;

namespace TwoFactorAuthentication.API
{
    public class OrderDbInitialize : DropCreateDatabaseIfModelChanges<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            context.Orders.Add(
                  new OrderModel
                  {
                      Id = 1,
                      Name = "India",
                      SName = "Delhi",
                      Company = "Home",
                      City = "Uman",
                      Address = "Road 25",
                      Price = 30.00,
                      Date = DateTime.UtcNow.AddDays(-6).ToString()
                  });
            context.Orders.Add(
                 new OrderModel
                 {
                     Id = 2,
                     Name = "Artem",
                     SName = "Delhi",
                     Company = "Home",
                     City = "Uman",
                     Address = "Road 25",
                     Price = 30.00,
                     Date = DateTime.UtcNow.AddDays(-5).ToString()
                 });


            context.SaveChanges();

            base.Seed(context);

        }
    
}
}