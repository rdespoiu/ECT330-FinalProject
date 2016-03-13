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

                            //billing address
                            TypeofAddress add = new TypeofAddress();
                            add.UserName = txtUsername.Text;
                            add.typeAdd = "Billing";
                            add.Address = txtBillingAddress.Text;
                            add.City = txtBillingCity.Text;
                            add.State = ddlBillingState.SelectedItem.ToString();
                            add.Zip = Int32.Parse(txtBillingZip.Text);
                            context.Address.Add(add);

                            //shipping address
                            add = new TypeofAddress();
                            add.UserName = txtUsername.Text;
                            add.typeAdd = "Shipping";
                            add.Address = txtShippingAddress.Text;
                            add.City = txtShippingCity.Text;
                            add.State = ddlShippingState.SelectedItem.ToString();
                            add.Zip = Int32.Parse(txtShippingZip.Text);
                            context.Address.Add(add);

                            customer.email = txtEmail.Text;
                            customer.UserName = txtUsername.Text;

                            //Hash time!!
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

                        //show billing address
                        var billAdd = (from c in context.Address
                                       where c.UserName == txtUsername.Text && c.typeAdd == "Billing"
                                       select c).FirstOrDefault();
                        txtBillingAddress.Text = billAdd.Address;
                        txtBillingCity.Text = billAdd.City;
                        ddlBillingState.SelectedValue = billAdd.State;
                        txtBillingZip.Text = billAdd.Zip.ToString();

                        //show shipping address
                        var shipAdd = (from c in context.Address
                                       where c.UserName == txtUsername.Text && c.typeAdd == "Shipping"
                                       select c).FirstOrDefault();
                        txtShippingAddress.Text = shipAdd.Address;
                        txtShippingCity.Text = shipAdd.City;
                        ddlShippingState.SelectedValue = shipAdd.State;
                        txtShippingZip.Text = shipAdd.Zip.ToString();

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