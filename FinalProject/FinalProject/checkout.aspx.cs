using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using FinalProject.Models;

namespace FinalProject
{
    public partial class checkout : System.Web.UI.Page
    {

        String AppTransId;
        String AppTransAmount;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null || Session["cartID"] == null)
            {
                Response.Redirect("index.aspx");
            } else
            {
                populateOrderConfirmation();
                populateAddresses();
            }
        }

        protected void RedirectUser(object sender, EventArgs e)
        {

            //Assign the values for the properties we need to pass to the service
            String AppId = ConfigurationManager.AppSettings["CreditAppId"];
            String SharedKey = ConfigurationManager.AppSettings["CreditAppSharedKey"];

            // Hash the values so the server can verify the values are original
            String hash = HttpUtility.UrlEncode(CreditAuthorizationClient.GenerateClientRequestHash(SharedKey, AppId, AppTransId, AppTransAmount));

            //Create the URL and  concatenate  the Query String values
            String url = "http://ectweb2.cs.depaul.edu/ECTCreditGateway/Authorize.aspx";
            url = url + "?AppId=" + AppId;
            url = url + "&TransId=" + AppTransId;
            url = url + "&AppTransAmount=" + AppTransAmount;
            url = url + "&AppHash=" + hash;

            //Redirect the User to the Service
            Response.Redirect(url);
        }

        protected void populateOrderConfirmation()
        {


            if (Session["cartID"] != null)
            {
                int cartId = Int32.Parse(Session["cartID"].ToString());
                Decimal totalPrice = 0;

                using (StoreContent context = new StoreContent())
                {
                    var cart = (from c in context.Orders
                                where c.Id == cartId
                                select c).FirstOrDefault();

                   

                    if (cart != null)
                    {

                        var orderItems = from c in context.OrderItem
                                          where c.OrderID == cartId
                                          select c;

                        AppTransId = cart.Id.ToString();                        
                        
                        foreach (OrderItem item in orderItems)
                        {
                            var product = (from c in context.Products
                                           where c.Id == item.ProductID
                                           select c).First();
                            
                            TableRow row = new TableRow();
                            TableCell cell;

                            cell = new TableCell();
                            cell.Text = product.ProductName;
                            row.Cells.Add(cell);

                            cell = new TableCell();
                            cell.Text = "$" + (product.UnitPrice * item.Quantity).ToString("N2");
                            row.Cells.Add(cell);

                            cell = new TableCell();
                            cell.Text = item.Quantity.ToString();
                            row.Cells.Add(cell);

                            tblOrderConfirmation.Rows.Add(row);

                            totalPrice += Decimal.Parse((product.UnitPrice * item.Quantity).ToString());
                        }
                    }
                }

                AppTransAmount = totalPrice.ToString();
                lblTotal.Text = "Total: $" + totalPrice.ToString("N2");

                if (Int32.Parse(AppTransAmount) <= 0)
                {
                    Response.Redirect("index.aspx");
                }
            }
            


            
        }

        protected void populateAddresses()
        {
            if (Session["LoggedInId"] != null)
            {
                using (StoreContent context = new StoreContent())
                {
                    int userId = Int32.Parse(Session["LoggedInId"].ToString());

                    var user = (from c in context.Customer
                                where c.Id == userId
                                select c).FirstOrDefault();

                    if (user != null)
                    {
                        lblShippingAddress.Text = user.ShippingAddress;
                        lblShippingCity.Text = user.City;
                        lblShippingState.Text = user.State;
                        lblShippingZip.Text = user.Zip.ToString();

                        lblBillingAddress.Text = user.BillingAddress;
                        lblBillingCity.Text = user.City;
                        lblBillingState.Text = user.State;
                        lblBillingZip.Text = user.Zip.ToString();
                    }
                }
            }
        }
    }
}