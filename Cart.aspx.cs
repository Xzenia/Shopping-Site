﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        Account account = accountController.retrieveAccountDetails(Session["CurrentAccountID"].ToString());
        double totalCost = 0;

        foreach (Item item in itemList)
        {
            totalCost += item.Quantity * item.PricePerItem;
        }

        foreach (Item item in itemList)
        {
            Item currentItem = itemController.retrieveItem(item.Id);
            int itemStock = currentItem.Quantity - item.Quantity;
            transactionController.addTransaction(item, account, totalCost);
            itemController.editItemStock(item.Id, itemStock);
        }

        Session["OrderList"] = itemList;

        Session["Cart"] = null;

        Response.Redirect("Receipt.aspx");

    }
}