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

        String AppId;
        String SharedKey;
        String AppTransId;
        String AppTransAmount;
        String hash;
        String url;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null || Session["cartID"] == null)
            {
                Response.Redirect("index.aspx");
            } else
            {
                populateOrderConfirmation();
            }
        }

        protected void RedirectUser(object sender, EventArgs e)
        {
            //Assign the values for the properties we need to pass to the service
            String AppId = ConfigurationManager.AppSettings["CreditAppId"];
            String SharedKey = ConfigurationManager.AppSettings["CreditAppSharedKey"];
            String AppTransId = "20";
            String AppTransAmount = "12.50";

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


            using (StoreContent context = new StoreContent())
            {

            }


            
        }
    }
}