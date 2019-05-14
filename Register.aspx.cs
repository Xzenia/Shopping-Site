using System;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentAccount"] != null)
        {
            Response.Redirect("Home.aspx");
        }
    }

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
            if (!accountController.doesEmailExist(EmailTextBox.Text))
            {
                newAccount.Username = UsernameTextBox.Text;
                try
                {
                    accountController.addAccount(newAccount);
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = "An error has occurred. Do not worry, this will be resolved soon!<br/> <br/> <br/>Exception message for nerds: "+ ex.ToString();
                }

                Session["CurrentAccount"] = newAccount;
                Response.Redirect("ConfirmEmail.aspx");
            }
            else
            {
                ErrorLabel.Text = "The email provided is already used for an existing account!";
            }
        }
        else
        {
            ErrorLabel.Text = "The username already exists!";
        }
    }
}