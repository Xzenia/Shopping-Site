using System;
using System.Web;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie sessionCookie = Response.Cookies["Session"];

        if (Request.QueryString["logout"] != null && Convert.ToString(Request.QueryString["logout"]).Equals("true"))
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        if (sessionCookie != null && sessionCookie.Values["id"] != null)
        {
            Response.Redirect("Index.aspx");
        }
    }

    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();
        bool isAccountValid = false;
        
        try
        {
           isAccountValid = accountController.loginAccount(UserIDTextBox.Text, PasswordTextBox.Text);
        }
        catch
        {
            ErrorLabel.Text = "An error occurred! Please enter your details and try again.";
        }

        if (isAccountValid && IsPostBack)
        {
            string accountId = accountController.retrieveId(UserIDTextBox.Text);
            Account account = accountController.retrieveAccountDetails(accountId);

            Session["CurrentAccount"] = account;
            
            Response.Redirect("Index.aspx");
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "User ID or Password is invalid!";
        }
    }
}