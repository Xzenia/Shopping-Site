using System;
using System.Data;
using System.IO;

public partial class AdminPage : System.Web.UI.Page
{
    private bool isAuthorized;
    private ItemController itemController;
    private AccountController accountController;

    protected void Page_Load(object sender, EventArgs e)
    {
        itemController = new ItemController();
        accountController = new AccountController();

        if (Session["CurrentAccount"] != null)
        {
            Account currentAccount = (Account)Session["CurrentAccount"];

            if (accountController.isAccountAdmin(currentAccount.Username))
            {
                isAuthorized = true;
                refreshTable();
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

    }

    protected void ItemGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        ItemIDTextBox.Text = ItemGridView.SelectedRow.Cells[1].Text.ToString();
        ItemNameTextBox.Text = ItemGridView.SelectedRow.Cells[2].Text.ToString();
        PriceTextBox.Text =  ItemGridView.SelectedRow.Cells[4].Text.ToString();
        StockTextBox.Text = ItemGridView.SelectedRow.Cells[3].Text.ToString();
    }

    private void refreshTable()
    {
        DataSet itemDataSet = itemController.viewAllItems();
        ItemGridView.DataSource = itemDataSet;
        ItemGridView.DataBind();
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        Item editedItem = new Item();
        editedItem = itemController.retrieveItem(Convert.ToInt32(ItemIDTextBox.Text));
        editedItem.Name = ItemNameTextBox.Text;
        editedItem.PricePerItem = Convert.ToDouble(PriceTextBox.Text);
        editedItem.Quantity = Convert.ToInt32(StockTextBox.Text);

        if (isAuthorized)
        {
            if (ProductImageFileUpload.HasFile)
            {
                if (!Directory.Exists(Server.MapPath("~/product_images/" + editedItem.Id + "-" + editedItem.Name + "/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/product_images/" + editedItem.Id + "-" + editedItem.Name + "/"));
                }

                string uploadFolderPath = Server.MapPath(@"~/product_images/" + editedItem.Id + "-" + editedItem.Name + "/");

                string uploadFilePath = uploadFolderPath + ProductImageFileUpload.FileName;

                ProductImageFileUpload.SaveAs(uploadFilePath);

                string filePath = @"~/product_images/" + editedItem.Id + "-" + editedItem.Name + "/" + ProductImageFileUpload.FileName;

                editedItem.ProductImagePath = filePath;
            }
          
            itemController.editItem(editedItem);
            refreshTable();
            clearFields();
        }
        else
        {
            ErrorLabel.Text = "You are not authorized to update the inventory database!";
        }

    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        if (isAuthorized)
        {
            itemController.deleteItem(Convert.ToInt32(ItemIDTextBox.Text));
            refreshTable();
            clearFields();
        }
        else
        {
            ErrorLabel.Text = "You are not authorized to delete items in the inventory database!";
        }
    }

    public void clearFields()
    {
        ItemIDTextBox.Text = "";
        ItemNameTextBox.Text = "";
        PriceTextBox.Text = "";
        StockTextBox.Text = "";
    }
}