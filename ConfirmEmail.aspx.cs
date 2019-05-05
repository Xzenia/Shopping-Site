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

    int confirmationCode = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentAccount"] != null)
        {
            if (IsPostBack)
            {
                confirmationCode = Convert.ToInt32(Session["ConfirmationCode"]);
            }
            else
            {
                Account temp = (Account)Session["CurrentAccount"];
                Account account = accountController.retrieveAccountDetails(temp.Username);

                if (!account.IsAccountConfirmed)
                {
                    sendConfirmationEmail(account.Email);
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
    }

    private void sendConfirmationEmail(string email)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("", "GreatFinds Team");
        mailMessage.To.Add(new MailAddress(email));

        mailMessage.Subject = "Account Confirmation";

        Random random = new Random();
        confirmationCode = random.Next(111111, 999999);
        Session["ConfirmationCode"] = confirmationCode;

        string message = "Greetings!<br/><br/>Please enter this six digit code into the confirmation code textbox to confirm your account and start shopping!<br/><br/><br/>" +
        "Confirmation Code: <b>"+confirmationCode.ToString()+"</b> <br/><br/><br/>"+"This is an automated message. Do not reply.<br/>" + "- GreatFinds Team";

        mailMessage.Body = message;
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        mailMessage.IsBodyHtml = true;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential("", "");
        smtpClient.EnableSsl = true;
     
        try
        {
            smtpClient.Send(mailMessage);

        }
        catch (Exception ex)
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = ex.ToString();
        }
    }

    protected void ConfirmButton_Click(object sender, EventArgs e)
    {
        if (ConfirmationCodeTextBox.Text.Equals(confirmationCode.ToString()))
        {
            Account temp = (Account)Session["CurrentAccount"];
            accountController.updateConfirmationStatus(temp.Username, true);

            Account account = accountController.retrieveAccountDetails(temp.Username);
            Session["CurrentAccount"] = account;

            Response.Redirect("Home.aspx");
        }
        else
        {
            ErrorLabel.ForeColor = System.Drawing.Color.Red;
            ErrorLabel.Text = "Confirmation Code is incorrect!";
        }
    }
}