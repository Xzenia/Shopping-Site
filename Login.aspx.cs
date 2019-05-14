using System;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["logout"] != null && Convert.ToString(Request.QueryString["logout"]).Equals("true"))
        {
            Session.Clear();
        }

        if (Session["CurrentAccount"] != null)
        {
            Response.Redirect("Home.aspx");
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
            Response.Redirect("Home.aspx");
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "User ID or Password is invalid!";
        }
    }
}