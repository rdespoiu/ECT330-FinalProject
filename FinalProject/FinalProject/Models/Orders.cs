using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int OrderItemID { get; set; }
        public Decimal SubTotal { get; set; }
        public String ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public String OrderStatus { get; set; }
    }
}