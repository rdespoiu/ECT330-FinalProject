using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateData();
        }

        protected void populateData()
        {

            try
            {
                String productId = Request.QueryString["Id"];

                using (StoreContent content = new StoreContent())
                {
                    var currentProduct = (from c in content.Products
                                          where c.Id.ToString() == productId
                                          select c).FirstOrDefault();
                    
                    imgProduct.ImageUrl = currentProduct.image;
                    lblProductName.Text = currentProduct.ProductName;
                    lblProductDescription.Text = currentProduct.ProductDescription;
                    lblPrice.Text = "$" + currentProduct.UnitPrice.ToString();

                    if (currentProduct.Stock > 10)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            ListItem itemQuantity = new ListItem();
                            itemQuantity.Text = i.ToString();
                            itemQuantity.Value = i.ToString();

                            ddlQuantity.Items.Add(itemQuantity);
                        }

                    }
                    else
                    {
                        for (int i = 1; i <= currentProduct.Stock; i++)
                        {
                            ListItem itemQuantity = new ListItem();
                            itemQuantity.Text = i.ToString();
                            itemQuantity.Value = i.ToString();

                            ddlQuantity.Items.Add(itemQuantity);
                        }
                    }

                    if (currentProduct.Stock > 0)
                    {

                        btnAddToCart.Text = "Add To Cart";
                        btnAddToCart.Command += new CommandEventHandler(AddToCart);
                        btnAddToCart.CommandArgument = currentProduct.Id.ToString();
                    } else
                    {
                        btnAddToCart.Text = "Out of Stock!";
                    }

                }

            } catch
            {

            }
            

            
        }

        private void AddToCart(object sender, CommandEventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                lblProductName.Text = "Please sign in or register to add items!";
                lblProductName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int addId = Convert.ToInt32(e.CommandArgument);
            int custId, cartId;
            bool hasCart = false;
            if (Session["LoggedInId"] == null)
                custId = 1;
            else
                custId = Int32.Parse(Session["LoggedInId"].ToString());

            if (Session["CartID"] == null)
            {
                using (StoreContent context = new StoreContent())
                {
                    var check = (from c in context.Orders
                                 where c.CustomerID == custId && c.OrderStatus == "Active"
                                 orderby c.Id descending
                                 select c).FirstOrDefault();
                    if (check != null)
                    {
                        Session["cartID"] = check.Id;
                        hasCart = true;
                    }
                }
                if (!hasCart)
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
            }
            cartId = Int32.Parse(Session["cartID"].ToString());
            using (StoreContent context = new StoreContent())
            {
                int quantityToAdd;

                var cart = (from c in context.Orders
                            where c.Id == cartId
                            select c).FirstOrDefault();
                var item = (from p in context.Products
                            where p.Id == addId
                            select p).FirstOrDefault();
                var checkItem = (from c in context.OrderItem
                                 where c.ProductID == item.Id && c.OrderID == cart.Id
                                 select c).FirstOrDefault();

                if (checkItem != null)
                {
                    checkItem.Quantity = checkItem.Quantity + Int32.Parse(ddlQuantity.SelectedValue);
                    quantityToAdd = Int32.Parse(ddlQuantity.SelectedValue);
                }
                else
                {
                    

                    var orditem = new OrderItem();
                    orditem.CustomerID = custId;
                    orditem.OrderID = cartId;
                    orditem.ProductID = item.Id;

                    if (Int32.Parse(ddlQuantity.SelectedValue) > 1)
                    {
                        quantityToAdd = Int32.Parse(ddlQuantity.SelectedValue);
                        orditem.Quantity = quantityToAdd;
                    }
                    else
                    {
                        quantityToAdd = 1;
                        orditem.Quantity = Int32.Parse(ddlQuantity.SelectedValue);
                    }

                    context.OrderItem.Add(orditem);
                }

                if (cart != null)
                {
                    cart.SubTotal += Decimal.Parse((item.UnitPrice * Int32.Parse(ddlQuantity.SelectedValue)).ToString()); //Subtotal now reflects unit price * quantity of units  --RID
                }
                item.Stock = item.Stock - quantityToAdd;   //remove from stock
                context.SaveChanges();
                
            }

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}