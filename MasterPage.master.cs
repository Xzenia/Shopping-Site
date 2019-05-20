using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie sessionCookie = Request.Cookies["Session"];

        if(sessionCookie != null && sessionCookie.Values["username"] != null)
        {
            AccountController accountController = new AccountController();
            Account loggedInAccount = accountController.retrieveAccountDetails(sessionCookie.Values["username"]);
            
            ProfileHyperlink.NavigateUrl = "~/ProfilePage.aspx";
            ProfileHyperlink.Text = "Logged in as " + loggedInAccount.FirstName + " " + loggedInAccount.LastName;

            if (accountController.isAccountAdmin(sessionCookie.Values["username"]))
            {
                AdminCornerLink.Visible = true;
            }
            else
            {
                AdminCornerLink.Visible = false;
            }

            if (!loggedInAccount.IsAccountConfirmed)
            {
                AccountConfirmationHyperlink.Visible = true;
            }
            else
            {
                AccountConfirmationHyperlink.Visible = false;
            }
        }
        else
        {
            AdminCornerLink.Visible = false;
            AccountConfirmationHyperlink.Visible = false;
            LogoutHyperlink.Visible = false;
        }
    }
}
