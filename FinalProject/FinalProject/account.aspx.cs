using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                Response.Redirect("index.aspx");
            } else
            {
                populateLinks();
            }
        }

        protected void populateLinks()
        {
            using (StoreContent context = new StoreContent())
            {
                int userId = Int32.Parse(Session["LoggedInId"].ToString());

                var userFirstName = (from c in context.Customer
                                     where c.Id == userId
                                     select c.FirstName).FirstOrDefault().ToString();

                if (userFirstName != null)
                {
                    lblPageName.Text = "Welcome, " + userFirstName;
                }
            }
        }
    }
}