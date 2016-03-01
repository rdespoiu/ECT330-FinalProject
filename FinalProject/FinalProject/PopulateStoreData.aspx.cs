using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class PopulateStoreData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (StoreContent content = new StoreContent())
            {
                ClearData(content);

                Category c = new Category();
                c.Id = 00;
                c.Description = "Climbing";
                content.Category.Add(c);

                c = new Category();
                c.Id = 01;
                c.Description = "Hiking";
                content.Category.Add(c);


                c = new Category();
                c.Id = 11;
                c.Description = "Apparel";
                content.Category.Add(c);


                Products p = new Products();
                p.ProductName = "Climbing Shoes";
                p.ProductDescription = "Shoes that won't weigh you down.";
                p.UnitPrice = 119.99;
                p.CategoryID = 00;
                p.Featured = false;
                p.image = "/images/climbing-shoes.jpg";
                p.Stock = 49;
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Climbing Harness";
                p.ProductDescription = "Hang on";
                p.UnitPrice = 79.99;
                p.CategoryID = 00;
                p.Featured = false;
                p.Stock = 28;
                p.image = "/images/climbing-harness.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Climbing Carabiner";
                p.ProductDescription = "Attach yourself to what's important";
                p.UnitPrice = 19.99;
                p.CategoryID = 00;
                p.Featured = false;
                p.Stock = 150;
                p.image = "/images/climbing-carabiner.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Climbing Belay Device";
                p.ProductDescription = "Belay with ease.";
                p.UnitPrice = 99.99;
                p.CategoryID = 00;
                p.Featured = false;
                p.Stock = 100;
                p.image = "/images/climbing-belaydevice.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Climbing Quickdraw";
                p.ProductDescription = "Precisioned attachment.";
                p.UnitPrice = 14.99;
                p.CategoryID = 00;
                p.Featured = false;
                p.Stock = 25;
                p.image = "/images/climbing-quickdraw";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Climbing Rope";
                p.ProductDescription = "Strong durable rope for scaling cliffs.";
                p.UnitPrice = 199.99;
                p.CategoryID = 00;
                p.Featured = false;
                p.Stock = 200;
                p.image = "/images/climbing-rope.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Climbing Cams";
                p.ProductDescription = "For when the only thing to hold on to is between a rock and another rock.";
                p.UnitPrice = 300;
                p.CategoryID = 00;
                p.Featured = false;
                p.Stock = 300;
                p.image = "/images/climbing-cams.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Hiking boots";
                p.ProductDescription = "Never lose traction";
                p.UnitPrice = 110.00;
                p.CategoryID = 01;
                p.Featured = false;
                p.Stock = 115;
                p.image = "/images/hiking-boots.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Hiking Pack";
                p.ProductDescription = "Mystery bags of all bags";
                p.UnitPrice = 200.00;
                p.CategoryID = 01;
                p.Featured = false;
                p.Stock = 35;
                p.image = "/images/hiking-pack.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Hiking Sleeping Bag";
                p.ProductDescription = "Made of that material that will hug you back when you sleep.";
                p.UnitPrice = 140.00;
                p.CategoryID = 01;
                p.Featured = false;
                p.Stock = 60;
                p.image = "/images/hiking-sleepingbag.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Apparel-Jacket";
                p.ProductDescription = "Look ready to take on the climb.";
                p.UnitPrice = 170.00;
                p.CategoryID = 11;
                p.Featured = false;
                p.Stock = 180;
                p.image = "/images/apparel-jacket.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Apparel-Pants";
                p.ProductDescription = "The swiss army knife of pants.";
                p.UnitPrice = 80.00;
                p.CategoryID = 11;
                p.Featured = false;
                p.Stock = 360;
                p.image = "/images/apparel-pants.jpg";
                content.Products.Add(p);

                p = new Products();
                p.ProductName = "Apparel-Shorts";
                p.ProductDescription = "Like the pants but half the length.";
                p.UnitPrice = 60.00;
                p.CategoryID = 11;
                p.Featured = false;
                p.Stock = 360;
                p.image = "/images/apparel-shorts.jpg";
                //this image can be changed, i just couldn't find a picture of actual shorts
                content.Products.Add(p);

                content.SaveChanges();
            }
        }
        public void ClearData(StoreContent content)
        {
            List<string> tablenames = content.Database.SqlQuery<string>("SELECT Table_Name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE '%Migration%'").ToList();
            for (int i = 0; tablenames.Count > 0; i++)
            {
                try
                {
                    content.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", tablenames.ElementAt(i % tablenames.Count)));
                    tablenames.RemoveAt(i % tablenames.Count);
                    i = 0;
                }
                catch
                {

                }
                content.SaveChanges();
            }
        }
    }
}