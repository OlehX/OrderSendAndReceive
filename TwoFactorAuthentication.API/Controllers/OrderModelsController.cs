using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TwoFactorAuthentication.API;
using TwoFactorAuthentication.API.Models;

namespace TwoFactorAuthentication.API.Controllers
{
    public class OrderModelsController : ApiController
    {
        private OrderContext db = new OrderContext();
        // GET: api/OrderModels
        public IQueryable<OrderModel> GetOrderModels()
        {
            return db.Orders;
        }

        // GET: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public async Task<IHttpActionResult> GetOrderModel(int id)
        {
            OrderModel orderModel = await db.Orders.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return Ok(orderModel);
        }

        // PUT: api/OrderModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderModel(int id, OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderModel.Id)
            {
                return BadRequest();
            }

            db.Entry(orderModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderModels
        [ResponseType(typeof(OrderModel))]
        public async Task<IHttpActionResult> PostOrderModel(OrderModel orderModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(orderModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orderModel.Id }, orderModel);
        }

        // DELETE: api/OrderModels/5
        [ResponseType(typeof(OrderModel))]
        public async Task<IHttpActionResult> DeleteOrderModel(int id)
        {
            OrderModel orderModel = await db.Orders.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }

            db.Orders.Remove(orderModel);
            await db.SaveChangesAsync();

            return Ok(orderModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderModelExists(int id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }
    }
}