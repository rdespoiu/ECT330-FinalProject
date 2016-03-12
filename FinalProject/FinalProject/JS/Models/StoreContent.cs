using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class StoreContent : DbContext
    {
        public StoreContent()
        {
            //should there be a change int he schema, drop and re create table w/ new schema
            // still need to repopulate afterwards
            Database.SetInitializer<StoreContent>(new DropCreateDatabaseIfModelChanges<StoreContent>());
        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Category> Category { get; set; } //different stock categories, i.e. shoes, rope, clothing...
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

    }
}