using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateData();
        }

        protected void populateData()
        {

            try
            {
                String productId = Request.QueryString["Id"];

                using (StoreContent content = new StoreContent())
                {
                    var currentProduct = (from c in content.Products
                                          where c.Id.ToString() == productId
                                          select c).FirstOrDefault();

                    //ADD IMAGE HERE imgProductImage
                    imgProduct.ImageUrl = currentProduct.image;
                    lblProductName.Text = currentProduct.ProductName;
                    lblProductDescription.Text = currentProduct.ProductDescription;
                    lblPrice.Text = "$" + currentProduct.UnitPrice.ToString();

                    if (currentProduct.Stock > 10)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            ListItem itemQuantity = new ListItem();
                            itemQuantity.Text = i.ToString();
                            itemQuantity.Value = i.ToString();

                            ddlQuantity.Items.Add(itemQuantity);
                        }

                    }
                    else
                    {
                        for (int i = 1; i <= currentProduct.Stock; i++)
                        {
                            ListItem itemQuantity = new ListItem();
                            itemQuantity.Text = i.ToString();
                            itemQuantity.Value = i.ToString();

                            ddlQuantity.Items.Add(itemQuantity);
                        }
                    }

                }

            } catch
            {

            }
            

            
        }
    }
}