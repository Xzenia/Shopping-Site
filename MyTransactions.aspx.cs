using System;
using System.Data;

public partial class MyTransactions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TransactionController transactionController = new TransactionController();

        if (Session["CurrentAccountID"] != null)
        {
            DataTable transactionDataTable = transactionController.viewTransaction(Session["CurrentAccountID"].ToString());

            TransactionGridView.DataSource = transactionDataTable;
            TransactionGridView.DataBind();
        }
        else
        {
            ErrorLabel.Text = "You need to be registered in order to see this feature.";
        }

    }
}