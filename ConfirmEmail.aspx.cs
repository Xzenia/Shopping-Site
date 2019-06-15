using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
public partial class ConfirmEmail : System.Web.UI.Page
{
    AccountController accountController = new AccountController();

    Account account;

    int confirmationCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentAccount"] != null)
        {
            account = (Account)Session["CurrentAccount"];

            if (IsPostBack)
            {
                confirmationCode = Convert.ToInt32(Session["ConfirmationCode"]);
            }
            else
            {
                Random random = new Random();
                confirmationCode = random.Next(111111111,999999999);

                Session["ConfirmationCode"] = confirmationCode;

                string message = "Eureka Human!<br/><br/>Please enter this six digit code into the confirmation code textbox to confirm your account and start buying our products!<br/><br/><br/>" +
        "Confirmation Code: <b>"+confirmationCode.ToString()+"</b> <br/><br/><br/>"+"This is an automated message. Do not reply.<br/>" + "- GreatFinds Team";

                if (!account.IsAccountConfirmed)
                {
                    accountController.sendEmail(account.Id.ToString(), account.Email, "Confirm your email", message);

                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            } 
        }
    }

 
    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        if (ConfirmationCodeTextBox.Text.Trim().Equals(confirmationCode.ToString()))
        {
            accountController.updateConfirmationStatus(account.Id.ToString(), true);
            Session["CurrentAccount"] = accountController.retrieveAccountDetails(account.Id.ToString());

            Response.Redirect("Index.aspx");
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "Confirmation Code is incorrect!";
        }
    }
}