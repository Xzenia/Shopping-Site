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

            if (retrievedItem.Name != "")
            {
                ProductNameLabel.Text = retrievedItem.Name;
                ProductPriceLabel.Text = "Price Per Item: " + retrievedItem.PricePerItem.ToString();
                ProductStockLabel.Text = "Stock available: " + retrievedItem.Quantity.ToString();
                ProductImage.ImageUrl = retrievedItem.ProductImagePath;
            }
            else
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Item link is invalid!";

                hideAllContents();
            }

        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "Item link is invalid!";

            hideAllContents();
        }
    }

    private void hideAllContents()
    {
        ProductImage.Visible = false;
        ProductNameLabel.Visible = false;
        ProductPriceLabel.Visible = false;
        ProductStockLabel.Visible = false;
        QuantityLabel.Visible = false;
        AddToCartButton.Visible = false;
        ProductNameLabel.Visible = false;
        ProductPriceLabel.Visible = false;
        ProductStockLabel.Visible = false;
        QuantityTextBox.Visible = false;
    }

    protected void AddToCartButton_Click(object sender, ImageClickEventArgs e)
    {
        Item orderedItem = retrievedItem;
        orderedItem.Quantity = Convert.ToInt32(QuantityTextBox.Text);
        List<Item> cart;
        List<int> cartItemIds = new List<int>();

        if (Session["CurrentAccount"] != null)
        {
            if (Session["Cart"] != null)
            {
                cart = (List<Item>)Session["Cart"];

                foreach (Item item in cart)
                {
                    cartItemIds.Add(item.Id);
                }

                if (cartItemIds.Contains(orderedItem.Id))
                {
                    int itemIndex = cart.FindIndex(p => p.Id == orderedItem.Id);
                    Item temp = cart[itemIndex];
                    temp.Quantity += orderedItem.Quantity;
                }
                else
                {
                    cart.Add(orderedItem);
                }

            }
            else
            {
                cart = new List<Item>();
                cart.Add(orderedItem);
            }

            Session["Cart"] = cart;
            ErrorLabel.Text = "Item added to cart!";
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "You need to be logged in to add items in the cart!";
        }
    }
}