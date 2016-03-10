using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProject.Models;

namespace FinalProject
{
    public partial class index : System.Web.UI.Page
    {
        String userFirstName;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request["action"] == "logout")
            {
                Session.Clear();
                Response.Redirect("/index.aspx");
            }

            lblInvalidCredentials.Visible = false;
            pnlSignIn.Visible = true;
            pnlSignedInOptions.Visible = false;
            updateUserName();
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
                    Session["cartID"] = user.Id.ToString();

                    lblInvalidCredentials.Visible = false;
                    updateUserName();

                }
                else
                {
                    lblInvalidCredentials.Visible = true;
                    signInContent.Style.Add("visibility", "visible");
                }
            }
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

                    lblSignInUsername.Text = "Hi, " + (String) userName + "! &#x25BC;";
                    userFirstName = (String) userName;
                }

                pnlSignIn.Visible = false;
                pnlSignedInOptions.Visible = true;
                lblFirstName.Text = userFirstName;
            }
        }
    }
}
