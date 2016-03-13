using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class editinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                Response.Redirect("index.aspx");
            } else
            {
                populateStates();
                populateForms();
            }
        }

        protected void btnSubmitEdits_Click(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] != null)
            {
                int userId = Int32.Parse(Session["LoggedInId"].ToString());

                using (StoreContent context = new StoreContent())
                {
                    var customer = (from c in context.Customer
                                    where c.Id == userId
                                    select c).FirstOrDefault();

                    if (customer != null)
                    {
                        if (Page.IsValid)
                        {
                            //add billing fields too
                            customer.FirstName = txtFirstName.Text;
                            customer.LastName = txtLastName.Text;
                            customer.BillingAddress = txtBillingAddress.Text;
                            customer.ShippingAddress = txtShippingAddress.Text;
                            customer.City = txtShippingCity.Text;
                            customer.Zip = Int32.Parse(txtShippingZip.Text);
                            customer.State = ddlShippingState.SelectedValue;
                            customer.email = txtEmail.Text;
                            customer.UserName = txtUsername.Text;

                            //Hash time!!
                            //customer.Password = txtPass1.Text;
                            customer.Password = FinalProject.SecuredPasswordHash.GenerateHash(txtPass1.Text);

                            if (chkNewsletter.Checked)
                            {
                                customer.NewsLetter = true;
                            } else
                            {
                                customer.NewsLetter = false;
                            }

                            context.SaveChanges();
                            Response.Redirect("account.aspx");
                        }
                    }
                }
            }
        }

        protected void populateForms()
        {

            int userId = Int32.Parse(Session["LoggedInId"].ToString());

            using (StoreContent context = new StoreContent())
            {
                var customer = (from c in context.Customer
                                where c.Id == userId
                                select c).FirstOrDefault();

                if (customer != null)
                {
                    if (!IsPostBack)
                    {
                        txtFirstName.Text = customer.FirstName;
                        txtLastName.Text = customer.LastName;
                        txtBillingAddress.Text = customer.BillingAddress;
                        txtShippingAddress.Text = customer.ShippingAddress;
                        txtShippingCity.Text = customer.City;
                        txtShippingZip.Text = customer.Zip.ToString();
                        ddlShippingState.SelectedValue = customer.State;
                        txtEmail.Text = customer.email;
                        txtUsername.Text = customer.UserName;

                    }
                }
            }
        }

        protected void populateStates()
        {
            String[] states = { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA"
                                , "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD"
                                , "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ"
                                , "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC"
                                , "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"};
            foreach (String state in states)
            {
                ddlShippingState.Items.Add(new ListItem(state));
                ddlBillingState.Items.Add(new ListItem(state));
            }
        }
    }
}