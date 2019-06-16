using System;
using System.Collections.Generic;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RemoveItem"] != null && Session["Cart"] != null)
        {
            List<Item> cartContents = (List<Item>)Session["Cart"];

            int test;
            if (int.TryParse(Request.QueryString["RemoveItem"], out test))
            {
                int itemIndex = cartContents.FindIndex(p => p.Id == Convert.ToInt32(Request.QueryString["RemoveItem"]));
                if (itemIndex >= 0)
                {
                    cartContents.RemoveAt(itemIndex);
                    Session["Cart"] = cartContents;
                }
            }

            Response.Redirect("Cart.aspx");
        }
        else if (Session["Cart"] != null)
        {
            List<Item> cartContents = (List<Item>)Session["Cart"];

            if (cartContents.Count <= 0)
            {
                ErrorLabel.Text = "Cart is empty!";
                OrderItemsButton.Visible = false;
            }

            ItemList.DataSource = cartContents;
            ItemList.DataBind();
        }
        else
        {
            ErrorLabel.Text = "Cart is empty!";
            OrderItemsButton.Visible = false;
        }

    }

    protected void OrderItemsButton_Click(object sender, EventArgs e)
    {
        TransactionController transactionController = new TransactionController();
        AccountController accountController = new AccountController();
        ItemController itemController = new ItemController();
        List<Item> itemList = (List<Item>)Session["Cart"];

        Account account = (Account)Session["CurrentAccount"];

        if (Session["CurrentAccount"] != null)
        {
            double totalCost = 0;

            foreach (Item item in itemList)
            {
                totalCost += item.Quantity * item.PricePerItem;
            }

            Random random = new Random();
            int transactionId = random.Next(1111111, 9999999);

            foreach (Item item in itemList)
            {
                Item currentItem = itemController.retrieveItem(item.Id);
                transactionController.addTransaction(item, account, totalCost, transactionId);
            }

            Session["OrderList"] = itemList;

            Session["Cart"] = null;

            Response.Redirect("Receipt.aspx");
        }
        else
        {
            ErrorLabel.Text = "You need to be logged in to order these items.";
        }

    }
}