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
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "alert('Login credentials accepted!');", true);
                }
                else
                {
                    //Display invalid login
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err-msg",
                "alert('Incorrect login credentials given!');", true);
                }
            }
        }
    }
}
