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

        if (Response.Cookies["Settings"] == null)
        {
            HttpCookie settingsCookie = new HttpCookie("Settings");
            settingsCookie.Expires = DateTime.Now.AddHours(3);
            settingsCookie["EmailUser"] = "true";

            Response.AppendCookie(settingsCookie);
        }
        else if (Response.Cookies["Settings"]["EmailUser"] != null)
        {
            if (Response.Cookies["Settings"]["EmailUser"] == "false")
            {
                EmailUserCheckBox.Checked = false;
            }
            else
            {
                EmailUserCheckBox.Checked = true;
            }
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
            if (TransactionStatusDropDownList.SelectedValue.Equals("Delivering"))
            {
                sendNotificationEmail(UsernameTextBox.Text, OrderedItemsLabel.Text);
            }
            reloadTable();
        }
        catch
        {
            ErrorLabel.Text = "You must select a row before updating the transaction status!";
        }
    }

    private void sendNotificationEmail(string username, string orderedItems)
    {
        Account account = accountController.retrieveAccountDetails(username);

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("", "GreatFinds Team");
        mailMessage.To.Add(new MailAddress(account.Email));

        mailMessage.Subject = "Your order is being delivered";


        string message = "Dear " + account.FirstName + " " + account.LastName + "<br/> <br/>We would like to inform you that your order is about to be delivered at the address you have provided <strong>(" + account.Address + ")</strong>" +
            "<br/><br/>Your order: <br/>" + orderedItems + "<br/><br/><br/>For any further concerns, please message us through Facebook Messenger, GreatFinds Online Store.";

        mailMessage.Body = message;
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        mailMessage.IsBodyHtml = true;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new NetworkCredential("", "");
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mailMessage);
            ErrorLabel.Text = "Notification email sent!";
        }
        catch (Exception ex)
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = ex.ToString();
        }
    }

    protected void EmailUserCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (Response.Cookies["Settings"] != null)
        {
            if (Response.Cookies["Settings"]["EmailUser"] == "false")
            {
                Response.Cookies["Settings"]["EmailUser"] = "true";
            }
            else
            {
                Response.Cookies["Settings"]["EmailUser"] = "false";
            }
        }
    }

    protected void TransactionGridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        TransactionGridView.PageIndex = e.NewPageIndex;
        TransactionGridView.DataBind();
    }
}