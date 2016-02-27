using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public String ProductName { get; set; }
        public String ProductDescription { get; set; }
        public Double UnitPrice { get; set; }
        public String image { get; set; }
        public int CategoryID { get; set; }
        public bool Featured { get; set; }
    }
}