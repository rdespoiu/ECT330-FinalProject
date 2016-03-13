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
                verifyUser();
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

                        if (item.Quantity > 1)
                        {
                            cell.Text = "$" + (product.UnitPrice * item.Quantity).ToString("N2") + " ($" + product.UnitPrice.ToString("N2") + " ea)";
                        } else
                        {
                            cell.Text = "$" + product.UnitPrice.ToString("N2");
                        }
                        
                        row.Cells.Add(cell);

                        tblOrderDetail.Rows.Add(row);


                        
                    }

                    var orderTotal = (from c in context.Orders
                                      where c.Id == orderId
                                      select c).FirstOrDefault();

                    if (orderTotal != null)
                    {
                        lblOrder.Text = "Order Date: " + orderTotal.OrderDate.ToString("MM/dd/yyyy");
                        lblTotal.Text = orderTotal.SubTotal.ToString("N2");
                    }

                }

                


            }




        }

        protected void verifyUser()
        {
            using (StoreContent context = new StoreContent())
            {
                try {
                    int userId = Int32.Parse(Session["LoggedInId"].ToString());
                    int orderId = Int32.Parse(Request.QueryString["Id"].ToString());

                    var order = (from c in context.Orders
                                 where c.Id == orderId && c.CustomerID == userId
                                 select c).FirstOrDefault();

                    if (order == null)
                    {
                        Response.Redirect("index.aspx");
                    }

                } catch
                {
                    Response.Redirect("index.aspx");
                }
                


            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("orders.aspx");
        }
    }
}