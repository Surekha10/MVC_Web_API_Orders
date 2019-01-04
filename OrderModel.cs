using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Web_API_Orders.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public string CustomerMobileNo { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
    }
}