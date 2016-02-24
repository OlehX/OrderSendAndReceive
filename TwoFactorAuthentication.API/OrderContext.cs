
using System.Data.Entity;
using System.Linq;
using System.Web;
using TwoFactorAuthentication.API.Models;

namespace TwoFactorAuthentication.API
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("OrderContext")
        {

        }
        public DbSet<OrderModel> Orders { get; set; }

    }
}