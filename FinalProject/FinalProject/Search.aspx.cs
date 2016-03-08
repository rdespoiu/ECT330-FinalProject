using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class Search : System.Web.UI.Page
    {
        string search;
        int results = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            search = Request.QueryString["query"];
            using (StoreContent context = new StoreContent())
            {
                var products = (from p in context.Products
                                where p.ProductName.ToLower().Contains(search.ToLower()) || p.ProductDescription.ToLower().Contains(search.ToLower())
                                select p).ToList();
                if(products!= null)
                {
                    foreach(Products p in products) { 
                        TableRow row = new TableRow();

                        TableCell cell = new TableCell();
                        cell.Text = "<img src=\"" + p.image + "\" />";
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = p.ProductName;
                        row.Cells.Add(cell);

                        cell = new TableCell();
                        cell.Text = p.ProductDescription;
                        row.Cells.Add(cell);
                        tblSearch.Rows.Add(row);
                        results++;
                    }
                }
            }
            lblSearch.Text+=results+" result(s) for '"+search+"'";
        }
    }
}