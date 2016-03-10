using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class apparel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateData();
        }

        protected void populateData()
        {
            using (StoreContent content = new StoreContent())
            {

                var categoryId = (from c in content.Category
                                  where c.Id == 3 //3 is the category ID for climbing
                                  select c.Id).FirstOrDefault();

                var products = from c in content.Products
                               where c.CategoryID == categoryId
                               select c;

                foreach (Products product in products)
                {

                    String productId = product.Id.ToString();

                    TableRow row = new TableRow();
                    TableCell cell;

                    cell = new TableCell();
                    Image img = new Image();
                    img.ImageUrl = product.image;
                    cell.Controls.Add(img);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    HyperLink link = new HyperLink();
                    link.Text = product.ProductName;
                    link.NavigateUrl = "/product.aspx?Id=" + productId;
                    cell.Controls.Add(link);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "$" + product.UnitPrice.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    Button addToCartBtn = new Button();
                    //Check if in stock
                    if (product.Stock > 0)
                    {
                        addToCartBtn.Text = "Add To Cart";
                        addToCartBtn.ID = product.Id.ToString(); //Will use this when adding the onClick event handler so that it can add this product ID to the user's cart
                        addToCartBtn.CssClass = "addToCartButton";
                        addToCartBtn.Command += new CommandEventHandler(AddToCart);
                        addToCartBtn.CommandArgument = product.Id.ToString();
                        cell.Controls.Add(addToCartBtn);
                        row.Cells.Add(cell);
                    }
                    else {
                        addToCartBtn.Text = "Out of Stock";
                        addToCartBtn.ID = product.Id.ToString(); //Will use this when adding the onClick event handler so that it can add this product ID to the user's cart
                        addToCartBtn.CssClass = "addToCartButton";
                        cell.Controls.Add(addToCartBtn);
                        row.Cells.Add(cell);
                    }

                    tblProducts.Rows.Add(row);

                }


            }
        }
        
        private void AddToCart(object sender, CommandEventArgs e)
        {
            int addId = Convert.ToInt32(e.CommandArgument);
            int custId, cartId;
            if (Session["LoggedInId"] == null)
                custId = 1;
            else custId = Int32.Parse(Session["LoggedInId"].ToString());

            if (Session["CartID"] == null)  //Never checks if cust has current active cart
            {
                var cart = new Orders();
                cart.CustomerID = custId;
                cart.OrderStatus = "Active";
                cart.OrderDate = DateTime.Now;
                cart.SubTotal = 0;
                using (StoreContent context = new StoreContent())
                {
                    context.Orders.Add(cart);
                    context.SaveChanges();
                    Session["cartID"] = cart.Id;
                }
            }
            cartId = Int32.Parse(Session["cartID"].ToString());
            using (StoreContent context = new StoreContent())
            {
                var cart = (from c in context.Orders
                            where c.Id == cartId
                            select c).FirstOrDefault();
                var item = (from p in context.Products
                            where p.Id == addId
                            select p).FirstOrDefault();
                if (item != null)
                {
                    var orditem = new OrderItem();
                    orditem.CustomerID = custId;
                    orditem.OrderID = cartId;
                    orditem.ProductID = item.Id;
                    orditem.Quantity = 1; //hard coded, can add function to add multiple items
                    context.OrderItem.Add(orditem);
                    if(cart!= null)
                        cart.SubTotal += Decimal.Parse(item.UnitPrice.ToString());
                    item.Stock--;   //remove from stock
                    context.SaveChanges();
                }
            }
        }
    }
}
