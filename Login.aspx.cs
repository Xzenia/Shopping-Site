using System;
using System.Web;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["logout"] != null && Convert.ToString(Request.QueryString["logout"]).Equals("true"))
        {
            Session.Clear();

            HttpCookie sessionCookie = new HttpCookie("Session");
            sessionCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(sessionCookie);

            Response.Redirect("Login.aspx");
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
            Account retrievedAccount = accountController.retrieveAccountDetails(UserIDTextBox.Text);
            Session["CurrentAccount"] = retrievedAccount;
            
            HttpCookie session = new HttpCookie("Session");
            session.Expires = DateTime.Now.AddHours(5);
            session.Values.Add("username", retrievedAccount.Username);
            Response.AppendCookie(session);

            Response.Redirect("Index.aspx");
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "User ID or Password is invalid!";
        }
    }
}