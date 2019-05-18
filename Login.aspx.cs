using System;
using System.Web;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["logout"] != null && Convert.ToString(Request.QueryString["logout"]).Equals("true"))
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }

        if (Session["CurrentAccount"] != null)
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
            Account retrievedAccount = accountController.retrieveAccountDetails(UserIDTextBox.Text);
            Session["CurrentAccount"] = retrievedAccount;
            
            HttpCookie session = new HttpCookie("Session");
            Random random = new Random();
            session["id"] = Convert.ToString(random.Next(11111111, 99999999));

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