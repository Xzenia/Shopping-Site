using System;
using System.Data;
public partial class Transactions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TransactionController transactionController = new TransactionController();

        DataSet transactionDataSet = transactionController.viewAllTransactions();

        TransactionGridView.DataSource = transactionDataSet;
        TransactionGridView.DataBind();
    }
}