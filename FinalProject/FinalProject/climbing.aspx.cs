using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class climbing : System.Web.UI.Page
    {

        CheckBox[] checkBoxArray;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInId"] != null)
            {

            }

            populateData();
            populateCheckBoxArray();

        }


        protected void populateData()
        {
            using (StoreContent content = new StoreContent())
            {

                var categoryId = (from c in content.Category
                                  where c.Id == 1 //1 is the category ID for climbing
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

        protected void checkBoxChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox) sender;

            if (chkBox.Checked)
            {
                lblPageName.Text = "Filtered by: " + chkBox.Text;

                using (StoreContent context = new StoreContent())
                {

                    string subcategory = chkBox.Text;
                    string filterQuery = subcategory.Substring(0, subcategory.Length - 2);

                    var categoryId = (from c in context.Category
                                      where c.Id == 1 //1 is the category ID for climbing
                                      select c.Id).FirstOrDefault();

                    var products = from c in context.Products
                                   where c.CategoryID == categoryId
                                   select c;

                    foreach (Products product in products)
                    {
                        TableRow row = tblProducts.Rows[0];
                        tblProducts.Rows.Remove(row);
                    }

                    foreach (Products product in products)
                    {
                        if (product.ProductName.Contains(filterQuery))
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

            } else
            {
                lblPageName.Text = "CLIMBING";

            }

            uncheckBoxes(chkBox);

        }

        protected void priceCheckBoxChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked)
            {
                lblPageName.Text = "Filtered by: " + chkBox.Text;
                int caseSwitch = caseSwitchMax(chkBox.Text);

                using (StoreContent context = new StoreContent())
                {
                    var categoryId = (from c in context.Category
                                      where c.Id == 1 //1 is the category ID for climbing
                                      select c.Id).FirstOrDefault();

                    var products = from c in context.Products
                                   where c.CategoryID == categoryId
                                   select c;

                    foreach (Products product in products) //Only used this as the iterator because this way it removes the exact amount of rows necessary
                    {
                        TableRow row = tblProducts.Rows[0];
                        tblProducts.Rows.Remove(row);
                    }

                    switch(caseSwitch)
                    {
                        case 1:
                            foreach(Products product in products)
                            {
                                if (product.UnitPrice <= 50)
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
                            break;

                        case 2:
                            foreach (Products product in products)
                            {
                                if (product.UnitPrice > 50 && product.UnitPrice <= 100)
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
                            break;

                        case 3:
                            foreach (Products product in products)
                            {
                                if (product.UnitPrice > 100 && product.UnitPrice <= 200)
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
                            break;

                        case 4:
                            foreach (Products product in products)
                            {
                                if (product.UnitPrice > 200)
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
                            break;

                    }
                }
                
            } else
            {
                lblPageName.Text = "CLIMBING";
            }

            uncheckBoxes(chkBox);
        }

        protected void populateCheckBoxArray()
        {
            checkBoxArray = new CheckBox[11];

            checkBoxArray[0] = chkShoes;
            checkBoxArray[1] = chkHarnesses;
            checkBoxArray[2] = chkRopes;
            checkBoxArray[3] = chkCarabiners;
            checkBoxArray[4] = chkBelay;
            checkBoxArray[5] = chkQuickdraws;
            checkBoxArray[6] = chkHelmets;

            checkBoxArray[7] = chkRangeZeroFifty;
            checkBoxArray[8] = chkRangeFiftyOneHundred;
            checkBoxArray[9] = chkRangeOneHundredTwoHundred;
            checkBoxArray[10] = chkRangeTwoHundredPlus;
        }

        protected void uncheckBoxes(CheckBox chkToKeep)
        {
            foreach (CheckBox chkBox in checkBoxArray)
            {
                if (chkBox.Text != chkToKeep.Text)
                {
                    chkBox.Checked = false;
                }
            }
        }

        protected int caseSwitchMax(string rangeText)
        {
            if (rangeText == "$0 - $50")
            {
                return 1;
            } else if (rangeText == "$50 - $100")
            {
                return 2;
            } else if (rangeText == "$100 - $200")
            {
                return 3;
            } else
            {
                return 4;
            }
            
        }
    }
}
