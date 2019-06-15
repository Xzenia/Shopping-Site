using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilePage : System.Web.UI.Page
{
    private Account account;
    private AccountController accountController;

    protected void Page_Load(object sender, EventArgs e)
    {
        accountController = new AccountController();
       
        if (Session["CurrentAccount"] != null)
        {
            account = (Account)Session["CurrentAccount"];

            if (!IsPostBack)
            {
                UsernameTextBox.Text = account.Username;
                FirstNameTextBox.Text = account.FirstName;
                LastNameTextBox.Text = account.LastName;
                EmailTextBox.Text = account.Email;
                AddressTextBox.Text = account.Address;
            }
        }
        else
        {
            ErrorLabel.Text = "You need to be logged in to edit your profile.";
            ContentTable.Visible = false;
            ConfirmButton.Visible = false;
        }
    }

    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        if (Session["CurrentAccount"] != null)
        {
            Account editedAccount = new Account();
            editedAccount.Id = account.Id;
            editedAccount.Username = UsernameTextBox.Text;
            editedAccount.FirstName = FirstNameTextBox.Text;
            editedAccount.LastName = LastNameTextBox.Text;
            editedAccount.Address = AddressTextBox.Text;
            editedAccount.Email = EmailTextBox.Text;
            editedAccount.IsAccountConfirmed = account.IsAccountConfirmed;
            editedAccount.AccountType = account.AccountType;

            if (!PasswordTextBox.Text.Equals(""))
            {
                if (accountController.confirmPassword(editedAccount.Password, PasswordTextBox.Text))
                {
                    ErrorLabel.Text = "Your password should be different from your old password!";
                }
                else
                {
                    editedAccount.Password = accountController.convertNewPasswordToHash(PasswordTextBox.Text);
                    accountController.editAccount(editedAccount);

                    Session["CurrentAccount"] = editedAccount;
                    ErrorLabel.Text = "Your account information has been updated!";
                }
            }
            else
            {
                editedAccount.Password = account.Password;
                accountController.editAccount(editedAccount);

                Session["CurrentAccount"] = editedAccount;
                ErrorLabel.Text = "Your account information has been updated!";
            }
        }
        else
        {
            ErrorLabel.Text = "You need to be registered and logged in to edit your account details.";
        }
    }
}