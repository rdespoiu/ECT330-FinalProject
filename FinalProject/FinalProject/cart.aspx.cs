using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedInId"] == null)
            {
                lblCart.Text = "Please sign in or register to view your cart!";
                lblCart.ForeColor = System.Drawing.Color.Red;

                lblCartQuantity.Text = null;

                return;
            }

            //Test cart     Session["cartID"] = 2;
            if (Session["cartID"] == null)
            {
                lblCartQuantity.Text = "(0 items)";
                lblSubtotal.Text += "0.00";
                btnCheckout.Enabled = false;
            }
            else
            {
                btnCheckout.Enabled = true;
                int cartId = Int32.Parse(Session["cartID"].ToString());
                int cartQuantity = 0;

                using (StoreContent context = new StoreContent())
                {
                    var cart = (from c in context.Orders
                                where c.Id == cartId
                                select c).First();
                    if(cart!= null)
                    {
                        int itemQty = 0;
                        bool firstFound = true;
                        var orderitems = (from o in context.OrderItem
                                         where o.OrderID == cartId
                                         select o);
                        foreach(OrderItem item in orderitems)
                        {
                            var product = (from p in context.Products
                                           where p.Id == item.ProductID
                                           select p).First();
                            int products = (from p in context.OrderItem
                                            where p.OrderID == cartId && p.ProductID == product.Id
                                            select p).Count();
                            if (products == 1)
                            {
                                cartQuantity += item.Quantity;
                                TableRow row = new TableRow();
                                TableCell cell = new TableCell();
                                cell.Text = "<img src=\"" + product.image + "\" />";
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                HyperLink link = new HyperLink();
                                link.Text = product.ProductName;
                                link.NavigateUrl = "product.aspx?Id=" + product.Id;
                                cell.Controls.Add(link);
                                row.Cells.Add(cell);

                                //If item quantity is > 1, show total price and price of each unit
                                cell = new TableCell();
                                if (item.Quantity <= 1)
                                {
                                    cell.Text = "$" + product.UnitPrice.ToString("N2");
                                } else
                                {
                                    cell.Text = "$" + (product.UnitPrice * item.Quantity).ToString("N2") + " ($" + product.UnitPrice.ToString("N2") + " ea)";
                                }

                                row.Cells.Add(cell);

                                cell = new TableCell();
                                cell.Text = item.Quantity.ToString();
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                Button removeFromCart = new Button();
                                removeFromCart.Text = "Remove From Cart";
                                removeFromCart.ID = product.Id.ToString(); //Will use this when adding the onClick event handler so that it can add this product ID to the user's cart
                                removeFromCart.CssClass = "actionButton";
                                removeFromCart.Command += new CommandEventHandler(RemoveFromCart);
                                removeFromCart.CommandArgument = product.Id.ToString();
                                cell.Controls.Add(removeFromCart);
                                row.Cells.Add(cell);

                                tblCart.Rows.Add(row);
                            }
                            else {
                                cartQuantity += item.Quantity;
                                itemQty+= item.Quantity;
                                TableRow row = new TableRow();
                                TableCell cell = new TableCell();
                                if (firstFound)
                                {
                                    cell.Text = "<img src=\"" + product.image + "\" />";
                                    row.Cells.Add(cell);

                                    cell = new TableCell();
                                    HyperLink link = new HyperLink();
                                    link.Text = product.ProductName;
                                    link.NavigateUrl = "product.aspx?Id=" + product.Id;
                                    cell.Controls.Add(link);
                                    row.Cells.Add(cell);

                                    cell = new TableCell();
                                    cell.Text = product.UnitPrice.ToString();
                                    row.Cells.Add(cell);

                                    cell = new TableCell();
                                    cell.ID = product.ProductName;
                                    cell.Text = item.Quantity.ToString();
                                    row.Cells.Add(cell);

                                    cell = new TableCell();
                                    Button removeFromCart = new Button();
                                    removeFromCart.Text = "Remove From Cart";
                                    removeFromCart.ID = product.Id.ToString(); //Will use this when adding the onClick event handler so that it can add this product ID to the user's cart
                                    removeFromCart.CssClass = "addToCartButton";
                                    removeFromCart.Command += new CommandEventHandler(RemoveFromCart);
                                    removeFromCart.CommandArgument = product.Id.ToString();
                                    cell.Controls.Add(removeFromCart);
                                    row.Cells.Add(cell);
                                    tblCart.Rows.Add(row);
                                    firstFound = false;
                                }
                                else
                                {
                                    TableCell c = tblCart.FindControl(product.ProductName.ToString()) as TableCell;
                                    c.Text = itemQty.ToString();
                                }
                                
                            }
                        }
                        lblCartQuantity.Text = "(" + cartQuantity + " items)";
                        lblSubtotal.Text += cart.SubTotal.ToString("N2");
                        
                    }
                }
            }
        }
        
        private void RemoveFromCart(object sender, CommandEventArgs e)
        {
            int remId = Convert.ToInt32(e.CommandArgument);
            int cartId = Int32.Parse(Session["cartID"].ToString());

            using (StoreContent context = new StoreContent())
            {
                var items = (from o in context.OrderItem
                            where o.OrderID == cartId && o.ProductID == remId
                            select o).ToList();
                var cart = (from c in context.Orders
                            where c.Id == cartId
                            select c).FirstOrDefault();
                var product = (from p in context.Products
                               where p.Id == remId
                               select p).First();
                foreach (OrderItem item in items)
                {
                    cart.SubTotal -= (decimal)(item.Quantity * product.UnitPrice);
                    product.Stock += item.Quantity;
                    context.OrderItem.Remove(item);
                    context.SaveChanges();
                }
            }
            Response.Redirect("cart.aspx");
        }

        protected void Checkout(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }

    }
}
