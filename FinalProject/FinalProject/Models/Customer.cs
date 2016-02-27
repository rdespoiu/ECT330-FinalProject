using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String BillingAddress { get; set; }
        public String ShippingAddress { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int Zip { get; set; }
        public String email { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public bool NewsLetter { get; set; }
    }
}