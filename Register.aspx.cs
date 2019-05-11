using System;

public partial class Register : System.Web.UI.Page
{
    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();
        Account newAccount = new Account();
        newAccount.FirstName = FirstNameTextBox.Text;
        newAccount.LastName = LastNameTextBox.Text;
        newAccount.Address = AddressTextBox.Text;
        newAccount.Email = EmailTextBox.Text;
        newAccount.AccountType = AccountType.Member;
        newAccount.Password = PasswordTextBox.Text;

        if (!accountController.doesAccountExist(UsernameTextBox.Text))
        {
            newAccount.Username = UsernameTextBox.Text;
            try
            {
                accountController.addAccount(newAccount);
            }
            catch
            {
                ErrorLabel.Text = "An error has occurred. Please enter your details once again.";
            }

            Session["CurrentAccount"] = newAccount;
            Response.Redirect("ConfirmEmail.aspx");
        }
        else
        {
            ErrorLabel.Text = "Account with that username already exists!";
        }
    }
}