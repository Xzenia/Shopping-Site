using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddItemPage : System.Web.UI.Page
{
    private bool isAuthorized = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();

        if (Session["CurrentAccountID"] != null && accountController.isAccountAdmin(Session["CurrentAccountID"].ToString()))
        {
            isAuthorized = true;
        }
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {

        ItemController itemController = new ItemController();

        Item newItem = new Item();
        newItem.Name = ItemNameTextBox.Text;
        newItem.PricePerItem = Convert.ToDouble(PriceTextBox.Text);
        newItem.Quantity = Convert.ToInt32(StockTextBox.Text);

        if (isAuthorized)
        {
            itemController.addItem(newItem);

            ErrorLabel.Text = "Item added!";

            ItemNameTextBox.Text = "";
            PriceTextBox.Text = "";
            StockTextBox.Text = "";
        }
        else
        {
            ErrorLabel.Text = "You are not authorized to enter new items in the database!";
        }
    }
}