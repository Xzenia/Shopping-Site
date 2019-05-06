using System;
using System.Collections.Generic;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Cart"] != null)
        {
            ItemList.DataSource = (List<Item>)Session["Cart"];
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
            int itemStock = currentItem.Quantity - item.Quantity;
            transactionController.addTransaction(item, account, totalCost, transactionId);
            itemController.editItemStock(item.Id, itemStock);
        }

        Session["OrderList"] = itemList;

        Session["Cart"] = null;

        Response.Redirect("Receipt.aspx");
    }
}