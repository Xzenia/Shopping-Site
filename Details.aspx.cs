using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details : System.Web.UI.Page
{
    Item retrievedItem; 

    protected void Page_Load(object sender, EventArgs e)
    {
        ItemController itemController = new ItemController();
        retrievedItem = new Item();

        int result;
        if (int.TryParse(Request.QueryString["id"], out result))
        {
            int itemId = Convert.ToInt32(Request.QueryString["id"]);
            retrievedItem = itemController.retrieveItem(itemId);

            ProductNameLabel.Text = retrievedItem.Name;
            ProductPriceLabel.Text = "Price Per Item: "+retrievedItem.PricePerItem.ToString();
            ProductStockLabel.Text = "Stock available: "+retrievedItem.Quantity.ToString();
            ProductImage.ImageUrl = retrievedItem.ProductImagePath;
        }
        else
        {
            Response.Write("<script>alert('Hello! Enter an integer as the id next time!');</script>");
            AddToCartButton.Visible = false;
            ProductNameLabel.Visible = false;
            ProductPriceLabel.Visible = false;
            ProductStockLabel.Visible = false;
            QuantityTextBox.Visible = false;
        }
    }

    protected void AddToCartButton_Click(object sender, ImageClickEventArgs e)
    {
        Item orderedItem = retrievedItem;
        orderedItem.Quantity = Convert.ToInt32(QuantityTextBox.Text);
        List<Item> cart;
        if (Session["Cart"] != null)
        {
            cart = (List<Item>)Session["Cart"];
            cart.Add(orderedItem);
        }
        else
        {
            cart = new List<Item>();
            cart.Add(orderedItem);
        }
        Session["Cart"] = cart;
        Response.Write("<script>alert('Item has been added to cart!');</script>");
        Response.Redirect("Purchase.aspx");
    }
}