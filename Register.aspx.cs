using System;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();
        Account newAccount = new Account();
        newAccount.FirstName = FirstNameTextBox.Text;
        newAccount.LastName = LastNameTextBox.Text;
        newAccount.Address = AddressTextBox.Text;
        newAccount.AccountType = AccountType.Member;
        newAccount.Password = PasswordTextBox.Text;
        newAccount.MemberId = AccountController.generateId();

        accountController.addAccount(newAccount);

        ErrorLabel.Text = "Account added! Your account number is "+newAccount.MemberId+". Please login your account to access the site's features.";
    }
}