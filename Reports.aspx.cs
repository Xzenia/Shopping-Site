using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports : System.Web.UI.Page
{
    private bool isAuthorized;

    protected void Page_Load(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();
        HttpCookie sessionCookie = Request.Cookies["Session"];

        if (sessionCookie.Values["username"] != null)
        {
            if (accountController.isAccountAdmin(sessionCookie.Values["username"]))
            {
                isAuthorized = true;
            }
            else
            {
                isAuthorized = false;
            }
        }
        else
        {
            isAuthorized = false;
        }

        if (isAuthorized)
        {
            TransactionReportViewer.Visible = true;
        }
        else
        {
            TransactionReportViewer.Visible = false;
            Response.Redirect("Index.aspx");
        }
    }
}