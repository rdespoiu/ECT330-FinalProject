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
                                cell.Text = product.ProductName;
                                row.Cells.Add(cell);

                                cell = new TableCell();
                                cell.Text = product.UnitPrice.ToString();
                                row.Cells.Add(cell);

                                cell = new TableCell();
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
                                    cell.Text = product.ProductName;
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
                        lblSubtotal.Text += cart.SubTotal.ToString();
                        
                    }
                }
            }
        }

    }
}
