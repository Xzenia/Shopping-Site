using System;

public partial class Login : System.Web.UI.Page
{
    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();
        bool isAccountValid = accountController.loginAccount(UserIDTextBox.Text, PasswordTextBox.Text);

        if (isAccountValid)
        {
            Account retrievedAccount = accountController.retrieveAccountDetails(UserIDTextBox.Text);
            Session["CurrentAccount"] = retrievedAccount;
            Response.Redirect("Home.aspx");
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "User ID or Password is invalid!";
        }
    }
}