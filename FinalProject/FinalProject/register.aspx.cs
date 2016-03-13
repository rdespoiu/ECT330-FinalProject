using FinalProject.JS.Models;
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

            if (Session["LoggedInId"] != null)
            {
                Response.Redirect("account.aspx?Id=" + Session["LoggedInId"].ToString());
            }

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

                        //adding different type of addresses

                        //billing first
                        TypeofAddress add = new TypeofAddress();
                        add.UserName = txtUsername.Text;
                        add.typeAdd = "Billing";
                        add.Address = txtBillingAddress.Text;
                        add.City = txtBillingCity.Text;
                        add.State = ddlBillingState.SelectedItem.ToString();
                        add.Zip = Int32.Parse(txtBillingZip.Text);
                        content.Address.Add(add);

                        //shipping address now
                        add = new TypeofAddress();
                        add.UserName = txtUsername.Text;
                        add.typeAdd = "Shipping";
                        add.Address = txtShippingAddress.Text;
                        add.City = txtShippingCity.Text;
                        add.State = ddlShippingState.SelectedItem.ToString();
                        add.Zip = Int32.Parse(txtShippingZip.Text);
                        content.Address.Add(add);

                        newCustomer.email = txtEmail.Text;
                        newCustomer.UserName = txtUsername.Text;
                        
                        //password will be hashed here
                        newCustomer.Password = FinalProject.SecuredPasswordHash.GenerateHash(txtPass1.Text);

                        if (chkNewsletter.Checked)
                        {
                            newCustomer.NewsLetter = true;
                        }
                        else
                        {
                            newCustomer.NewsLetter = false;
                        }

                        content.Customer.Add(newCustomer);
                        content.SaveChanges();

                        Session["LoggedInId"] = newCustomer.Id;
                        Response.Redirect("account.aspx?Id=" + newCustomer.Id.ToString());


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
                ddlShippingState.Items.Add(new ListItem(state));
                ddlBillingState.Items.Add(new ListItem(state));
            }
        }
    }
}