using System;
using System.Data;
using System.Web;
using System.Net.Mail;
using System.Net;

public partial class Transactions : System.Web.UI.Page
{
    private TransactionController transactionController;
    private AccountController accountController;

    private DataSet transactionDataSet;
    private bool isAuthorized;

    private string orderedItemsString;

    private Account account;

    protected void Page_Load(object sender, EventArgs e)
    {
        accountController = new AccountController();
        transactionController = new TransactionController();

        if (Session["CurrentAccount"] != null)
        {
            Account currentAccount = (Account)Session["CurrentAccount"];
            if (accountController.isAccountAdmin(currentAccount.Id.ToString()))
            {
                isAuthorized = true;
                reloadTable();
            }
            else
            {
                isAuthorized = false;
            }
        }
        else
        {
            isAuthorized = false;
        }

        if (!isAuthorized)
        {
            TransactionGridView.Visible = false;
            Response.Redirect("Index.aspx");
        }
    }

    protected void TransactionGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        TransactionIDTextBox.Text = TransactionGridView.SelectedRow.Cells[1].Text.ToString();
        UsernameTextBox.Text = TransactionGridView.SelectedRow.Cells[2].Text.ToString();
        FullNameTextBox.Text = TransactionGridView.SelectedRow.Cells[3].Text.ToString();
        DateTextBox.Text = TransactionGridView.SelectedRow.Cells[4].Text.ToString();
        TimeTextBox.Text = TransactionGridView.SelectedRow.Cells[5].Text.ToString();

        TransactionStatusDropDownList.SelectedValue = TransactionGridView.SelectedRow.Cells[11].Text.ToString();

        DataTable orderedItems = transactionController.viewOrderedItems(TransactionIDTextBox.Text, UsernameTextBox.Text);

        orderedItemsString = "";

        foreach (DataRow row in orderedItems.Rows)
        {
            orderedItemsString += row["ItemName"] + " - x" + row["Quantity"] + "<br/>";
        }

        OrderedItemsLabel.Text = "";
        OrderedItemsLabel.Text = orderedItemsString;
    }

    private void reloadTable()
    {
        transactionDataSet = transactionController.viewAllTransactions();

        TransactionGridView.DataSource = transactionDataSet;
        TransactionGridView.DataBind();
    }


    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        try
        {
            string accountId = accountController.retrieveId(TransactionGridView.SelectedRow.Cells[2].Text.ToString());
            Account account = accountController.retrieveAccountDetails(accountId);

            transactionController.updateTransactionStatus(TransactionGridView.SelectedRow.Cells[1].Text.ToString(), TransactionGridView.SelectedRow.Cells[2].Text.ToString(), TransactionStatusDropDownList.SelectedValue);
            
            if (TransactionStatusDropDownList.SelectedValue.Equals("Delivering"))
            {
                string message = "Dear " + account.FirstName + " " + account.LastName + "<br/> <br/>We would like to inform you that your order is about to be delivered at the address you have provided <strong>(" + account.Address + ")</strong>" +
            "<br/><br/>Your order: <br/>" + OrderedItemsLabel.Text + "<br/><br/><br/>For any further concerns, please message us through Facebook Messenger, GreatFinds Online Store.";

                accountController.sendEmail(account.Id.ToString(), account.Email, "Your order is being delivered to you", message);
            }

            reloadTable();
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "An error has occurred. Do not worry, this will be resolved soon!<br/> <br/> <br/>Exception message for nerds: " + ex.ToString();
        }
    }

    protected void TransactionGridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        TransactionGridView.PageIndex = e.NewPageIndex;
        TransactionGridView.DataBind();
    }

    protected void TransactionStatusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (TransactionStatusDropDownList.SelectedValue.Equals("Delivering"))
        {
            EmailUserCheckBox.Visible = true;
        }
        else
        {
            EmailUserCheckBox.Visible = false;
        }
    }
}