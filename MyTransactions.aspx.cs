using System;
using System.Data;

public partial class MyTransactions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TransactionController transactionController = new TransactionController();

        if (Session["CurrentAccount"] != null)
        {
            Account account = (Account)Session["CurrentAccount"];
            DataTable transactionDataTable = transactionController.viewTransaction(account.Username);

            TransactionGridView.DataSource = transactionDataTable;
            TransactionGridView.DataBind();
        }
        else
        {
            ErrorLabel.Text = "You need to be registered in order to see this feature.";
        }

    }
}