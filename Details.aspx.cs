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
        try
        {
            int itemId = Convert.ToInt32(Request.QueryString["id"]);
            retrievedItem = itemController.retrieveItem(itemId);

            if (retrievedItem.Id != 0)
            {
                ProductNameLabel.Text = retrievedItem.Name;
                ProductPriceLabel.Text = "&#8369;" + retrievedItem.PricePerItem.ToString();
                ProductStockLabel.Text = "Stock Available: " + retrievedItem.Quantity.ToString();
                ProductImage.ImageUrl = retrievedItem.ProductImagePath;

                if (retrievedItem.SalePrice > 0)
                {
                    ProductPriceLabel.Text = "<strike>&#8369;" + retrievedItem.PricePerItem.ToString() + "</strike>&nbsp;&#8369;" + retrievedItem.SalePrice;
                }

                RangeValidator.MinimumValue = "1";
                RangeValidator.MaximumValue = retrievedItem.Quantity.ToString();

                RangeValidator.ErrorMessage = "Only a value from 1 - " + retrievedItem.Quantity + " are allowed.";
            }
            else
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Item link is invalid!";

                hideAllContents();
            }
        }
        catch
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


        if (orderedItem.SalePrice > 0)
        {
            orderedItem.PricePerItem = orderedItem.SalePrice;
        }

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

            QuantityTextBox.Text = "1";
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "You need to be logged in to add items in the cart!";
        }
    }
}