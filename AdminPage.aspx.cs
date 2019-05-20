using System;
using System.Data;
using System.IO;
using System.Web;

public partial class AdminPage : System.Web.UI.Page
{
    private bool IsAuthorized;
    private ItemController ItemController;
    private AccountController AccountController;

    protected void Page_Load(object sender, EventArgs e)
    {
        ItemController = new ItemController();
        AccountController = new AccountController();

        HttpCookie sessionCookie = Request.Cookies["Session"];

        if (sessionCookie.Values["username"] != null)
        {
            Account currentAccount = AccountController.retrieveAccountDetails(sessionCookie.Values["username"]);

            if (AccountController.isAccountAdmin(currentAccount.Username))
            {
                IsAuthorized = true;
            }
            else
            {
                IsAuthorized = false;
            }
        }
        else
        {
            IsAuthorized = false;
        }

        if (!IsAuthorized)
        {
            Response.Redirect("Index.aspx");
        }
    }
}