using System;
using System.IO;

public partial class AddItem : System.Web.UI.Page
{
    private bool isAuthorized = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        AccountController accountController = new AccountController();

        if (Session["CurrentAccount"] != null)
        {
            Account currentAccount = (Account) Session["CurrentAccount"];

            if (accountController.isAccountAdmin(currentAccount.Username))
            {
                isAuthorized = true;
            }
        }
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
        ItemController itemController = new ItemController();

        Item newItem = new Item();
        newItem.Name = ItemNameTextBox.Text;
        newItem.PricePerItem = Convert.ToDouble(PriceTextBox.Text);
        newItem.Quantity = Convert.ToInt32(StockTextBox.Text);

        string uploadFolderPath = Server.MapPath(@"/product_images/" + newItem.Id + "-" + newItem.Name + "/");
        string uploadFilePath = uploadFolderPath + ProductImageFileUpload.FileName;

        string filePath = @"~/product_images/" + newItem.Id + "-" + newItem.Name + "/" + ProductImageFileUpload.FileName;


        if (isAuthorized)
        {
            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            ProductImageFileUpload.SaveAs(uploadFilePath);

            newItem.ProductImagePath = filePath;

            itemController.addItem(newItem);

            ErrorLabel.Text = "Item added!";

            ItemNameTextBox.Text = "";
            PriceTextBox.Text = "";
            StockTextBox.Text = "";
            ProductImageFileUpload.Dispose();
        }
        else
        {
            ErrorLabel.Text = "You are not authorized to enter new items in the database!";
        }
    }
}