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
                                     orderby c.OrderDate descending
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
                        link.Text = order.OrderDate.ToString("MM/dd/yyyy");
                        link.NavigateUrl = "orderdetail.aspx?Id=" + order.Id;
                        cell.Controls.Add(link);
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = "$" + order.SubTotal.ToString("N2");
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = order.OrderStatus;
                        row.Cells.Add(cell);
                    
                        tblOrders.Rows.Add(row);


                        for (int i = 0; i < 100; i++)
                        {
                            System.Console.WriteLine("WE MADE IT HERE");
                            System.Console.Write("WE MADE IT HERE");

                        }
                        
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