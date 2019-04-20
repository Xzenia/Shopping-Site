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

        if (!accountController.doesAccountExist(UsernameTextBox.Text))
        {
            newAccount.Username = UsernameTextBox.Text;
            accountController.addAccount(newAccount);
            ErrorLabel.Text = "Account added! You may now shop for items in the online store!";
        }
        else
        {
            ErrorLabel.Text = "Account with that username already exists!";
        }


       
    }
}