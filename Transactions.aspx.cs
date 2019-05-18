using System;
using System.Data;
public partial class Transactions : System.Web.UI.Page
{
    private TransactionController transactionController;
    private AccountController accountController;

    private DataSet transactionDataSet;
    private bool isAuthorized;

    protected void Page_Load(object sender, EventArgs e)
    {
        accountController = new AccountController();
        transactionController = new TransactionController();

        if (Session["CurrentAccount"] != null)
        {
            Account currentAccount = (Account)Session["CurrentAccount"];

            if (accountController.isAccountAdmin(currentAccount.Username))
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

        string orderedItemsString = "";

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
            transactionController.updateTransactionStatus(TransactionGridView.SelectedRow.Cells[1].Text.ToString(), TransactionGridView.SelectedRow.Cells[2].Text.ToString(), TransactionStatusDropDownList.SelectedValue);
            reloadTable();
        }
        catch
        {
            ErrorLabel.Text = "You must select a row before updating the transaction status!";
        }
    }
}