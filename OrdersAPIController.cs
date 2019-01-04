using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_Web_API_Orders.Models;

namespace MVC_Web_API_Orders.Controllers
{
    public class OrdersAPIController : ApiController
    {
        MyDBContext db = new MyDBContext();
        // GET: api/OrdersAPI
        public IEnumerable<OrderModel> Get()
        {
            return db.Orders.ToList();
        }

        // GET: api/OrdersAPI/5
        public OrderModel Get(int id)
        {
            return db.Orders.FirstOrDefault(o => o.OrderID == id);
        }

        // POST: api/OrdersAPI
        public bool Post([FromBody]OrderModel value)
        {
            db.Orders.Add(value);
            db.SaveChanges();
            return true;
        }

        // PUT: api/OrdersAPI/5
        public void Put(int id, [FromBody]OrderModel value)
        {
            var dbmodel = db.Orders.FirstOrDefault(o => o.OrderID == id);
            dbmodel.CustomerMobileNo = value.CustomerMobileNo;
            dbmodel.ItemName = value.ItemName;
            dbmodel.ItemPrice = value.ItemPrice;
            dbmodel.ItemQuantity = value.ItemQuantity;
            db.SaveChanges();
        }

        // DELETE: api/OrdersAPI/5
        public void Delete(int id)
        {
            var model = (from o in db.Orders where o.OrderID == id select o).FirstOrDefault();
            db.Orders.Remove(model);
            db.SaveChanges();
        }
        [Route("api/OrdersAPI/Search/{key}")]
        [HttpGet]
        public IEnumerable<OrderModel> Search(string key)
        {
            var model = db.Orders.Where(o => o.CustomerMobileNo.Contains(key) || o.ItemName.Contains(key)).ToList();
            return model;
        }
    }
}
