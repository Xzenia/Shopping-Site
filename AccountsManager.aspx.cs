using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccountsManager : System.Web.UI.Page
{
    private AccountController AccountController;
    private bool IsAuthorized;

    protected void Page_Load(object sender, EventArgs e)
    {
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
        else
        {
            RefreshTable();
        }
    }

    private void RefreshTable()
    {
        AccountGridView.DataSource = AccountController.viewAllAccounts();
        AccountGridView.DataBind();
    }


    protected void AccountGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        AccountIDTextBox.Text = AccountGridView.SelectedRow.Cells[1].Text;
        UsernameTextBox.Text = AccountGridView.SelectedRow.Cells[2].Text;
        FirstNameTextBox.Text = AccountGridView.SelectedRow.Cells[3].Text;
        LastNameTextBox.Text = AccountGridView.SelectedRow.Cells[4].Text;
        AddressTextBox.Text = AccountGridView.SelectedRow.Cells[5].Text;
        EmailTextBox.Text = AccountGridView.SelectedRow.Cells[6].Text;
        AccountTypeDropDownList.SelectedValue = AccountGridView.SelectedRow.Cells[8].Text;
    }

    protected void SaveChangesButton_Click(object sender, EventArgs e)
    {
        AccountType accountType = (AccountType) Convert.ToInt32(AccountTypeDropDownList.SelectedValue);
        AccountController.updateAccountType(UsernameTextBox.Text, accountType);

        ErrorLabel.Text = "Account Type updated!";

        RefreshTable();

        AccountIDTextBox.Text = "";
        UsernameTextBox.Text = "";
        FirstNameTextBox.Text = "";
        LastNameTextBox.Text = "";
        AddressTextBox.Text = "";
        EmailTextBox.Text = "";
        AccountTypeDropDownList.SelectedValue = "";
    }
}