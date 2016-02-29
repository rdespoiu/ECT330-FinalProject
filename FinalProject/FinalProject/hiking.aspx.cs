using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class hiking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateData();
        }

        protected void populateData()
        {
            using (StoreContent content = new StoreContent())
            {

                var categoryId = (from c in content.Category
                                  where c.Id == 2 //2 is the category ID for hiking
                                  select c.Id).FirstOrDefault();

                var products = from c in content.Products
                               where c.CategoryID == categoryId
                               select c;

                foreach (Products product in products)
                {

                    String productId = product.Id.ToString();

                    TableRow row = new TableRow();
                    TableCell cell;

                    cell = new TableCell();
                    Image img = new Image();
                    img.ImageUrl = product.image;
                    cell.Controls.Add(img);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    HyperLink link = new HyperLink();
                    link.Text = product.ProductName;
                    link.NavigateUrl = "/product.aspx?Id=" + productId;
                    cell.Controls.Add(link);
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = "$" + product.UnitPrice.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    Button addToCartBtn = new Button();
                    addToCartBtn.Text = "Add To Cart";
                    addToCartBtn.ID = product.Id.ToString(); //Will use this when adding the onClick event handler so that it can add this product ID to the user's cart
                    addToCartBtn.CssClass = "addToCartButton";
                    cell.Controls.Add(addToCartBtn);
                    row.Cells.Add(cell);


                    tblProducts.Rows.Add(row);

                }


            }
        }
    }
}