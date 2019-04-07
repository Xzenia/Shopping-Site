using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Purchase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemController itemController = new ItemController();
        DataSet itemDataSet = itemController.viewAllItems();
        ItemList.DataSource = itemDataSet;
        ItemList.DataBind();
    }

    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        TransactionController transactionController = new TransactionController();
        AccountController accountController = new AccountController();
        ItemController itemController = new ItemController();
        List<Item> itemList = new List<Item>();
        List<string> errorList = new List<string>();

        ErrorLabel.Text = "";
    }
}