using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class orderdetail : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null || Request.QueryString["Id"] == null)
            {
                Response.Redirect("index.aspx");
            } else
            {
                populateData();
            }

            
            
        }

        protected void populateData()
        {
            int orderId = Int32.Parse(Request.QueryString["Id"].ToString());
            int userId = Int32.Parse(Session["LoggedInId"].ToString());

            using (StoreContent context = new StoreContent())
            {

                var orderItems = from c in context.OrderItem
                                 where c.OrderID == orderId && c.CustomerID == userId
                                 select c;
                

                if (orderItems != null)
                {
                    foreach (OrderItem item in orderItems)
                    {

                        var product = (from c in context.Products
                                       where c.Id == item.ProductID
                                       select c).FirstOrDefault();

                        TableRow row = new TableRow();
                        TableCell cell;

                        cell = new TableCell();
                        HyperLink link = new HyperLink();
                        link.NavigateUrl = "product.aspx?Id=" + product.Id;
                        link.Text = product.ProductName;
                        cell.Controls.Add(link);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = item.Quantity.ToString();
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = "$" + (product.UnitPrice * item.Quantity).ToString("N2") + " (" + product.UnitPrice.ToString("N2") + " ea)";
                        row.Cells.Add(cell);



                        
                    }

                    var orderTotal = (from c in context.Orders
                                      where c.Id == orderId
                                      select c).FirstOrDefault();

                    if (orderTotal != null)
                    {
                        lblTotal.Text = orderTotal.SubTotal.ToString("N2");
                    }

                }

                


            }




        }
    }
}