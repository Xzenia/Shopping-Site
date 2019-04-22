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
        if(Session["CurrentAccount"] != null)
        {
            Account loggedInAccount = (Account)Session["CurrentAccount"];
            ProfileHyperlink.NavigateUrl = "~/ProfilePage.aspx";
            ProfileHyperlink.Text = "Logged in as " + loggedInAccount.FirstName + " " + loggedInAccount.LastName;
            if (loggedInAccount.AccountType == AccountType.Admin)
            {
                AdminCornerLink.Visible = true;
            }
            else
            {
                AdminCornerLink.Visible = false;
            }
        }
        else
        {
            AdminCornerLink.Visible = false;

        }
    }

    protected void LogoutLinkButton_Click(object sender, EventArgs e)
    {

    }
}
