using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoFactorAuthentication.API.Models;

namespace TwoFactorAuthentication.API.Interfaces
{
    interface IOrderModel
    {
        void Add(OrderModel o);
        void Remove(string Id);
        IEnumerable<OrderModel> GetOrder();
        OrderModel FindById(int Id);
    }
}
