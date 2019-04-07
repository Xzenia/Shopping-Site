using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentAccountID"] != null)
        {
            AccountController accountController = new AccountController();
            string userId = Session["CurrentAccountID"].ToString();
            Account account = accountController.retrieveAccountDetails(userId);

            MemberIDLabel.Text = account.MemberId.ToString();
            FirstNameLabel.Text = account.FirstName;
            LastNameLabel.Text = account.LastName;
            AddressLabel.Text = account.Address;

            if (account.AccountType == AccountType.Member)
            {
                AccountTypeLabel.Text = "Member";
            }
            else
            {
                AccountTypeLabel.Text = "Admin";
            }
        }
        else
        {
            ErrorLabel.Text = "You need to be registered and logged in to see your account details.";
        }
    }
}