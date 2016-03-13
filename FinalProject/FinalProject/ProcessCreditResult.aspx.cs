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
    public partial class ProcessCreditResult1 : System.Web.UI.Page
    {

        Random rand = new Random();
        String[] randomFact = { "Deer can jump as high as 10 feet in the air from a full sprint", "Over 100,000 wildfires occur every year in the US", "Raccoons can purr! Like house cats, they purr when they feel content or safe",
                                "Black bears can run at speeds of up to 35 miles per hour", "Mosquitos can smell the carbon dioxide in a human's breath from over 100 feet away"}; //Source: http://blog.eurekatent.com/20-outdoor-facts-to-impress-friends/
        int randomDeliveryTime;
        String transactionAmount;
        int transactionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                Response.Redirect("index.aspx");
                
            } else
            {
                processResults();
            }
        }

        protected void processResults()
        {
            String AppId = ConfigurationManager.AppSettings["CreditAppId"];
            String SharedKey = ConfigurationManager.AppSettings["CreditAppSharedKey"];
            String AppTransId = Request.QueryString["TransId"].ToString();
            transactionId = Int32.Parse(AppTransId.ToString());

            //To be safe, you should check the value from the DB as well.
            String AppTransAmount = Request.QueryString["TransAmount"].ToString();
            transactionAmount = AppTransAmount;

            String status = Request.QueryString["StatusCode"].ToString();
            String hash = Request.QueryString["AppHash"].ToString();

            if (CreditAuthorizationClient.VerifyServerResponseHash(hash, SharedKey, AppId, AppTransId, AppTransAmount, status))
            {
                switch (status)
                {
                    case ("A"): transactionApproved(); break;
                    case ("D"): transactionDenied(); break;
                    case ("C"): transactionCancelled(); break;

                }
            }
            else
            {
                hashFail();
            }
        }

        protected void btnKeepShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void transactionApproved()
        {
            int userId = Int32.Parse(Session["LoggedInId"].ToString());
            randomDeliveryTime = rand.Next(10, 60);
            String fact = randomFact[rand.Next(0, randomFact.Length - 1)];
            String email;
            using (StoreContent context = new StoreContent())
            {
                var customerEmail = (from c in context.Customer
                                     where c.Id == userId
                                     select c).FirstOrDefault();

                email = customerEmail.email.ToString();
            }

            lblPageName.Text = "CHECKOUT SUCCESSFUL";
            lblStatus.Text = "The transaction was approved. Your credit card will be charged $" + transactionAmount.ToString();
            lblShipping.Text = "Your order will be shipped by supersonic drone for free!";
            lblDelivery.Text = "Drone will depart in 15 minutes and arrive at your doorstep in " + randomDeliveryTime + " minutes!";
            lblWarning.Text = "Please watch the sky when opening your door, as Above Treeline accepts no liability for customers hit by flying boxes.";
            lblConfirmationEmail.Text = "You should receive an order confirmation shortly at " + email;
            lblRandomFact.Text = "Did you know? " + fact;


            completeOrder(userId, transactionId);

        }

        protected void transactionDenied()
        {

            String fact = randomFact[rand.Next(0, randomFact.Length - 1)];

            lblPageName.Text = "TRANSACTION DENIED";
            lblStatus.Text = "Sorry, the transaction was denied";
            lblShipping.Text = null;
            lblDelivery.Text = null;
            lblWarning.Text = null;
            lblConfirmationEmail.Text = null;

            HyperLink link = new HyperLink();
            link.NavigateUrl = "checkout.aspx";
            link.Text = "Click here to return to checkout and try again";
            lblConfirmationEmail.Controls.Add(link);

            lblRandomFact.Text = fact;

            btnKeepShopping.Visible = false;


        }

        protected void transactionCancelled()
        {
            String fact = randomFact[rand.Next(0, randomFact.Length - 1)];

            lblPageName.Text = "TRANSACTION CANCELLED";
            lblStatus.Text = "Looks like you cancelled the transaction";
            lblShipping.Text = null;
            lblDelivery.Text = null;
            lblWarning.Text = null;
            lblConfirmationEmail.Text = null;

            HyperLink link = new HyperLink();
            link.NavigateUrl = "checkout.aspx";
            link.Text = "Click here if you made a mistake and you want to try again";
            lblConfirmationEmail.Controls.Add(link);

            lblRandomFact.Text = fact;

            btnKeepShopping.Visible = false;
        }

        protected void hashFail()
        {
            String fact = randomFact[rand.Next(0, randomFact.Length - 1)];

            lblPageName.Text = "HASH FAIL";
            lblStatus.Text = "Hash verification failed. Our bad!";
            lblShipping.Text = null;
            lblDelivery.Text = null;
            lblWarning.Text = null;
            lblConfirmationEmail.Text = null;

            HyperLink link = new HyperLink();
            link.NavigateUrl = "checkout.aspx";
            link.Text = "Click here to return to checkout and try again";
            lblConfirmationEmail.Controls.Add(link);

            lblRandomFact.Text = fact;

            btnKeepShopping.Visible = false;
        }

        protected void completeOrder(int userId, int transactionId)
        {
            using (StoreContent context = new StoreContent())
            {
                var order = (from c in context.Orders
                             where c.Id == transactionId && c.CustomerID == userId
                             select c).FirstOrDefault();

                var user = (from c in context.Customer
                            where c.Id == userId
                            select c).FirstOrDefault();

                var shipAdd = (from c in context.Address
                               where c.UserName == user.UserName && c.typeAdd == "Shipping"
                               select c).FirstOrDefault();
                
                order.OrderStatus = "Complete";
                order.OrderDate = DateTime.Now;

                Orders newOrder = context.Orders.Create();

                newOrder.CustomerID = userId;
                newOrder.SubTotal = 0;
                newOrder.OrderDate = DateTime.Now;
                newOrder.ShippingAddress = shipAdd.Address;
                newOrder.OrderStatus = "Active";

                context.Orders.Add(newOrder);

                context.SaveChanges();

                Session["cartID"] = newOrder.Id.ToString();

            }
        }
    }
}