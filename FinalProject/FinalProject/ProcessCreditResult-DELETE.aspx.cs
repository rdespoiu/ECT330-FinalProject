using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FinalProject
{
    public partial class ProcessCreditResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String AppId = ConfigurationManager.AppSettings["CreditAppId"];
            String SharedKey = ConfigurationManager.AppSettings["CreditAppSharedKey"];
            String AppTransId = Request.QueryString["TransId"].ToString();

            //To be safe, you should check the value from the DB as well.
            String AppTransAmount = Request.QueryString["TransAmount"].ToString();

            String status = Request.QueryString["StatusCode"].ToString();
            String hash = Request.QueryString["AppHash"].ToString();

            if (CreditAuthorizationClient.VerifyServerResponseHash(hash, SharedKey, AppId, AppTransId, AppTransAmount, status))
            {
                switch (status)
                {
                    case ("A"): lblStatus.Text = "Transaction Approved!"; break;
                    case ("D"): lblStatus.Text = "Transaction Denied!"; break;
                    case ("C"): lblStatus.Text = "Transaction Cancelled!"; break;

                }
            }
            else
            {
                lblStatus.Text = "Hash Verification failed... something went wrong.";
            }
        }
    }
}