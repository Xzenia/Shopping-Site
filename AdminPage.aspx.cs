using System;
using System.Data;
using System.IO;

public partial class AdminPage : System.Web.UI.Page
{
    private bool IsAuthorized;
    private ItemController ItemController;
    private AccountController AccountController;

    protected void Page_Load(object sender, EventArgs e)
    {
        ItemController = new ItemController();
        AccountController = new AccountController();

        if (Session["CurrentAccount"] != null)
        {
            Account currentAccount = (Account)Session["CurrentAccount"];

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
            Response.Redirect("Home.aspx");
        }
    }
}