using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class ProductsMaster : System.Web.UI.MasterPage
    {
        String userFirstName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] == "logout")
            {
                Session.Clear();
                Response.Redirect("/index.aspx");
            }
            if (!IsPostBack)
            {
                txtSearchBar.Attributes.Add("onKeyPress", "doClick('" + btnSearch.ClientID + "',event)");
            }

            lblInvalidCredentials.Visible = false;
            pnlSignIn.Visible = true;
            pnlSignedInOptions.Visible = false;
            updateUserName();
            cartLabelQuantity();
        }

        protected void updateUserName()
        {
            if (Session["LoggedInId"] != null)
            {
                using (StoreContent content = new StoreContent())
                {

                    var userId = Session["LoggedInId"].ToString();

                    var userName = (from c in content.Customer
                                    where c.Id.ToString() == userId
                                    select c.FirstName).FirstOrDefault();

                    lblSignInUsername.Text = "Hi, " + (String)userName + "! &#x25BC;";
                    userFirstName = (String)userName;
                }

                pnlSignIn.Visible = false;
                pnlSignedInOptions.Visible = true;
                lblFirstName.Text = userFirstName;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            using (StoreContent context = new StoreContent())
            {
                var pwd = FinalProject.SecuredPasswordHash.GenerateHash(txtPassword.Text);
                var user = (from c in context.Customer
                            where c.UserName == txtUsername.Text && c.Password == pwd
                            select c).FirstOrDefault();

                if (user != null)
                {
                    Session["LoggedInId"] = user.Id.ToString();
                    Session["FirstName"] = user.FirstName;
                    Session["LastName"] = user.LastName;

                    lblInvalidCredentials.Visible = false;
                    updateUserName();

                    instantiateCart(Int32.Parse(Session["LoggedInId"].ToString()));

                    cartLabelQuantity();

                }
                else
                {
                    lblInvalidCredentials.Visible = true;
                    signInContent.Style.Add("visibility", "visible");

                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBar.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg",
                    "alert('Please enter some word to search.');", true);
            }
            else
            {
                Response.Redirect("Search.aspx?query=" + txtSearchBar.Text);
            }
        }

        protected void instantiateCart(int userId)
        {
            using (StoreContent context = new StoreContent())
            {
                var order = (from c in context.Orders
                             where c.CustomerID == userId && c.OrderStatus == "Active"
                             select c).FirstOrDefault();

                if (order != null)
                {
                    Session["cartID"] = order.Id.ToString();
                }
                else
                {

                    var user = (from c in context.Customer
                                where c.Id == userId
                                select c).First();

                    Orders newOrder = context.Orders.Create();

                    newOrder.CustomerID = userId;
                    newOrder.SubTotal = 0;
                    newOrder.OrderDate = DateTime.Now;
                    newOrder.ShippingAddress = user.ShippingAddress;
                    newOrder.OrderStatus = "Active";

                    context.Orders.Add(newOrder);
                    context.SaveChanges();

                }
            }
        }

        protected void cartLabelQuantity()
        {
            if (Session["LoggedInId"] != null && Session["cartID"] != null)
            {
                int CART_QUANTITY = 0;

                int cartId = Int32.Parse(Session["cartID"].ToString());
                int userId = Int32.Parse(Session["LoggedInId"].ToString());

                using (StoreContent context = new StoreContent())
                {
                    var order = (from c in context.Orders
                                 where c.Id == cartId && c.CustomerID == userId
                                 select c).FirstOrDefault();

                    var quantity = from c in context.OrderItem
                                   where c.OrderID == order.Id
                                   select c;

                    if (order != null && quantity != null)
                    {
                        foreach (OrderItem item in quantity)
                        {
                            CART_QUANTITY += item.Quantity;

                            lblShoppingCart.Text = "Shopping Cart" + " (" + CART_QUANTITY.ToString() + ")";

                        }
                    }

                }
            }
        }
    }
}
