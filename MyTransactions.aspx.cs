using System;
using System.Data;
using System.Web;

public partial class MyTransactions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TransactionController transactionController = new TransactionController();
        HttpCookie sessionCookie = Request.Cookies["Session"];

        if (sessionCookie.Values["username"] != null)
        {
            DataTable transactionDataTable = transactionController.viewTransaction(sessionCookie.Values["username"]);

            TransactionGridView.DataSource = transactionDataTable;
            TransactionGridView.DataBind();
        }
        else
        {
            ErrorLabel.Text = "You need to be registered in order to see this feature.";
        }


        TransactionGridView.Font.Size = 14;
    }


}