using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Actions : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            updateUserName();
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
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            using (StoreContent context = new StoreContent())
            {
                var user = (from c in context.Customer
                            where c.UserName == txtUsername.Text && c.Password == txtPassword.Text
                            select c).FirstOrDefault();

                if (user != null)
                {
                    Session["LoggedInId"] = user.Id.ToString();
                    Session["FirstName"] = user.FirstName;
                    Session["LastName"] = user.LastName;

                    /*
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "alert('Login credentials accepted!');", true);*/  //Got it to update with user's first name upon login. This is no longer necessary.

                    updateUserName();

                }
                else
                {
                    //Display invalid login
                    /* ScriptManager.RegisterStartupScript(this, this.GetType(), "err-msg",
                 "alert('Incorrect login credentials given!');", true);*/ //THIS WILL REDIRECT USERS TO ANOTHER SIGN IN PAGE WITH AN ERROR MESSAGE OF INVALID CREDENTIALS

                }
            }
        }
    }
}