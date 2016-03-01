using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateStates();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                using (StoreContent content = new StoreContent())
                {

                    var checkUsername = (from c in content.Customer
                                     where c.UserName == txtUsername.Text
                                     select c).FirstOrDefault();

                    if (checkUsername == null)
                    {
                        Customer newCustomer = content.Customer.Create();
                        newCustomer.FirstName = txtFirstName.Text;
                        newCustomer.LastName = txtLastName.Text;
                        newCustomer.BillingAddress = txtBillingAddress.Text;
                        newCustomer.ShippingAddress = txtShippingAddress.Text;
                        newCustomer.City = txtCity.Text;
                        newCustomer.Zip = Int32.Parse(txtZip.Text);
                        newCustomer.State = ddlState.SelectedItem.ToString();
                        newCustomer.email = txtEmail.Text;
                        newCustomer.UserName = txtUsername.Text;
                        newCustomer.Password = txtPass1.Text;

                        if (chkNewsletter.Checked)
                        {
                            newCustomer.NewsLetter = true;
                        }
                        else
                        {
                            newCustomer.NewsLetter = false;
                        }
                    } else
                    {
                        lblPageName.Text = "Username is already taken! Please choose another.";
                        lblPageName.ForeColor = System.Drawing.Color.Red;
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
                ddlState.Items.Add(new ListItem(state));
            }
        }
    }
}