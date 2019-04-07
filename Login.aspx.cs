using System;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();
        bool isAccountValid = accountController.loginAccount(UserIDTextBox.Text, PasswordTextBox.Text);


        if (isAccountValid)
        {
            Account retrievedAccount = accountController.retrieveAccountDetails(UserIDTextBox.Text);
            Session["CurrentAccount"] = retrievedAccount;
            Session["CurrentAccountID"] = retrievedAccount.MemberId;
            Response.Redirect("Purchase.aspx");
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "User ID or Password is invalid!";
        }
    }
}