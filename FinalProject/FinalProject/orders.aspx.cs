using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] == null)
            {
                Response.Redirect("index.aspx");
            }

            populateOrders();
        }

        protected void populateOrders()
        {
            int userId = Int32.Parse(Session["LoggedInId"].ToString());

            using (StoreContent context = new StoreContent())
            {
                var customerOrders = from c in context.Orders
                                     where c.CustomerID == userId && c.OrderStatus == "Complete"
                                     select c;

                if (customerOrders != null)
                {
                    foreach (Orders order in customerOrders)
                    {

                        TableRow row = new TableRow();
                        TableCell cell;
                        HyperLink link;

                        cell = new TableCell();
                        link = new HyperLink();
                        link.Text = order.OrderDate.ToString();
                        link.NavigateUrl = "orderdetail.aspx?Id=" + order.Id;
                        cell.Controls.Add(link);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = order.SubTotal.ToString("N2");
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = order.OrderStatus;
                        row.Cells.Add(cell);

                        tblOrders.Rows.Add(row);


                        /*
                        var orderItems = from c in context.OrderItem
                                         where c.OrderID == order.Id
                                         select c;

                        //Don't want to do nested for loops, runtime might get really bad for users with a lot of orders. Hopefully can find a better way to implement
                        foreach (OrderItem orderItem in orderItems)
                        {

                            var productOrdered = (from c in context.Products
                                                  where c.Id == orderItem.ProductID
                                                  select c).FirstOrDefault();

                            TableRow row = new TableRow();
                            TableCell cell;
                            HyperLink link;

                            //Order Date
                            cell = new TableCell();
                            cell.Text = order.OrderDate.ToString();
                            row.Cells.Add(cell);

                            //Order Item
                            cell = new TableCell();
                            link = new HyperLink();
                            link.Text = productOrdered.ProductName;
                            link.NavigateUrl = "product.aspx?Id=" + productOrdered.Id.ToString();
                            cell.Controls.Add(link);
                            row.Cells.Add(cell);

                            //Order Quantity
                            cell = new TableCell();
                            cell.Text = orderItem.Quantity.ToString();
                            row.Cells.Add(cell);

                            //Total
                            cell = new TableCell();
                            cell.Text = "$" + order.SubTotal.ToString();
                            row.Cells.Add(cell);

                            //Order Status
                            cell = new TableCell();
                            cell.Text = order.OrderStatus;
                            row.Cells.Add(cell);

                            tblOrders.Rows.Add(row);
                        }*/
                    }
                } else
                {
                    TableRow row = new TableRow();
                    TableCell cell;

                    cell = new TableCell();
                    cell.Text = "You have no order history. Why not buy something now?";

                    tblOrders.Rows.Add(row);
                }
            }
        }
    }
}