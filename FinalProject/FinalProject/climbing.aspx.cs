using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class climbing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "alert('You are logged in as " + Session["FirstName"] + " " + Session["LastName"] + "');", true);
            }
        }
    }
}
