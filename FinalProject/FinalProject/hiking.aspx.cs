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

        CheckBox[] checkBoxArray;

        protected void Page_Load(object sender, EventArgs e)
        {
            populateData();
            populateCheckBoxArray();
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
                    //Check if in stock
                    if (product.Stock > 0)
                    {
                        addToCartBtn.Text = "Add To Cart";
                        addToCartBtn.ID = product.Id.ToString(); //Will use this when adding the onClick event handler so that it can add this product ID to the user's cart
                        addToCartBtn.CssClass = "addToCartButton";
                        addToCartBtn.Command += new CommandEventHandler(AddToCart);
                        addToCartBtn.CommandArgument = product.Id.ToString();
                        cell.Controls.Add(addToCartBtn);
                        row.Cells.Add(cell);
                    }
                    else {
                        addToCartBtn.Text = "Out of Stock";
                        addToCartBtn.ID = product.Id.ToString(); //Will use this when adding the onClick event handler so that it can add this product ID to the user's cart
                        addToCartBtn.CssClass = "addToCartButton";
                        cell.Controls.Add(addToCartBtn);
                        row.Cells.Add(cell);
                    }


                    tblProducts.Rows.Add(row);

                }


            }
        }

        protected void checkBoxChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;

            if (chkBox.Checked)
            {
                lblPageName.Text = "Filtered by: " + chkBox.Text;

                using (StoreContent context = new StoreContent())
                {

                    string subcategory = chkBox.Text;
                    string filterQuery = subcategory.Substring(0, subcategory.Length - 2);

                    var categoryId = (from c in context.Category
                                      where c.Id == 2 //2 is the category ID for hiking
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

            }
            else
            {
                lblPageName.Text = "HIKING";

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
                                      where c.Id == 2
                                      select c.Id).FirstOrDefault();

                    var products = from c in context.Products
                                   where c.CategoryID == categoryId
                                   select c;

                    foreach (Products product in products) //Only used this as the iterator because this way it removes the exact amount of rows necessary
                    {
                        TableRow row = tblProducts.Rows[0];
                        tblProducts.Rows.Remove(row);
                    }

                    switch (caseSwitch)
                    {
                        case 1:
                            foreach (Products product in products)
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

            }
            else
            {
                lblPageName.Text = "HIKING";
            }

            uncheckBoxes(chkBox);
        }
        
        private void AddToCart(object sender, CommandEventArgs e)
        {

            if (Session["LoggedInId"] == null)
            {
                lblPageName.Text = "Please sign in or register to add items!";
                lblPageName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int addId = Convert.ToInt32(e.CommandArgument);
            int custId, cartId;
            bool hasCart = false;
            if (Session["LoggedInId"] == null)
                custId = 1;
            else
                custId = Int32.Parse(Session["LoggedInId"].ToString());

                if (Session["cartID"] == null)
            {
                using (StoreContent context = new StoreContent())
                {
                    var check = (from c in context.Orders
                                 where c.CustomerID == custId && c.OrderStatus == "Active"
                                 orderby c.Id descending
                                 select c).FirstOrDefault();
                    if(check!= null)
                    {
                        Session["cartID"] = check.Id;
                        hasCart = true;
                    }
                }
                if (!hasCart) {
                    var cart = new Orders();
                    cart.CustomerID = custId;
                    cart.OrderStatus = "Active";
                    cart.OrderDate = DateTime.Now;
                    cart.SubTotal = 0;
                    using (StoreContent context = new StoreContent())
                    {
                        context.Orders.Add(cart);
                        context.SaveChanges();
                        Session["cartID"] = cart.Id;
                    }
                }
            }
            cartId = Int32.Parse(Session["cartID"].ToString());
            using (StoreContent context = new StoreContent())
            {
                var cart = (from c in context.Orders
                            where c.Id == cartId
                            select c).FirstOrDefault();
                var item = (from p in context.Products
                            where p.Id == addId
                            select p).FirstOrDefault();
                if (item != null)
                {
                    var orditem = new OrderItem();
                    orditem.CustomerID = custId;
                    orditem.OrderID = cartId;
                    orditem.ProductID = item.Id;
                    orditem.Quantity = 1; //hard coded, can add function to add multiple items
                    context.OrderItem.Add(orditem);
                    if (cart != null)
                        cart.SubTotal += Decimal.Parse(item.UnitPrice.ToString());
                    item.Stock--;   //remove from stock
                    context.SaveChanges();
                }
            }
        }

        protected void populateCheckBoxArray()
        {
            checkBoxArray = new CheckBox[7];

            checkBoxArray[0] = chkPacks;
            checkBoxArray[1] = chkSleepingBags;
            checkBoxArray[2] = chkHikingBoots;

            checkBoxArray[3] = chkRangeZeroFifty;
            checkBoxArray[4] = chkRangeFiftyOneHundred;
            checkBoxArray[5] = chkRangeOneHundredTwoHundred;
            checkBoxArray[6] = chkRangeTwoHundredPlus;

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
            }
            else if (rangeText == "$50 - $100")
            {
                return 2;
            }
            else if (rangeText == "$100 - $200")
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
    }
}
