using System;
using System.Data;
using System.IO;

public partial class ItemManager : System.Web.UI.Page
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
                RefreshTable();
            }
            else
            {
                isAuthorized = false;
            }
        }
        else
        {
            isAuthorized = false;
            Response.Redirect("Home.aspx");
        }
    }

    protected void ItemGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        ItemIDTextBox.Text = ItemGridView.SelectedRow.Cells[1].Text.ToString();
        ItemNameTextBox.Text = ItemGridView.SelectedRow.Cells[2].Text.ToString();
        PriceTextBox.Text = ItemGridView.SelectedRow.Cells[4].Text.ToString();
        StockTextBox.Text = ItemGridView.SelectedRow.Cells[3].Text.ToString();
        SalePriceTextBox.Text = ItemGridView.SelectedRow.Cells[7].Text.ToString();
    }

    private void RefreshTable()
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
        editedItem.SalePrice = Convert.ToDouble(SalePriceTextBox.Text);

        if (isAuthorized)
        {
            if (ProductImageFileUpload.HasFile)
            {
                string uploadFolderPath = Server.MapPath(@"~/product_images/" + editedItem.Id + "-" + editedItem.Name + "/");

                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                string uploadFilePath = uploadFolderPath + ProductImageFileUpload.FileName;

                ProductImageFileUpload.SaveAs(uploadFilePath);

                string filePath = @"~/product_images/" + editedItem.Id + "-" + editedItem.Name + "/" + ProductImageFileUpload.FileName;

                editedItem.ProductImagePath = filePath;
            }

            itemController.editItem(editedItem);

            itemController.updateSalePrice(editedItem.Id, editedItem.SalePrice);

            RefreshTable();
            ClearFields();
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
            RefreshTable();
            ClearFields();
        }
        else
        {
            ErrorLabel.Text = "You are not authorized to delete items in the inventory database!";
        }
    }

    private void ClearFields()
    {
        ItemIDTextBox.Text = "";
        ItemNameTextBox.Text = "";
        PriceTextBox.Text = "";
        StockTextBox.Text = "";
        SalePriceTextBox.Text = "";
    }
}