﻿using System;
using System.Data;
using System.IO;
using System.Web;

public partial class AddItem : System.Web.UI.Page
{
    private bool isAuthorized = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        AccountController AccountController = new AccountController();

        if (Session["CurrentAccount"] != null)
        {
            Account currentAccount = (Account)Session["CurrentAccount"];

            if (AccountController.isAccountAdmin(currentAccount.Id.ToString()))
            {
                isAuthorized = true;
            }
            else
            {
                isAuthorized = false;
                Response.Redirect("Index.aspx");
            }
        }
        else
        {
            isAuthorized = false;
            Response.Redirect("Index.aspx");
        }
    }

    protected void AddButton_Click(object sender, EventArgs e)
    {
        ItemController itemController = new ItemController();

        Item newItem = new Item();
        newItem.Name = ItemNameTextBox.Text;
        newItem.PricePerItem = Convert.ToDouble(PriceTextBox.Text);
        newItem.Description = DescriptionTextBox.Text;
        string uploadFolderPath = Server.MapPath(@"/product_images/" + newItem.Id + "-" + newItem.Name + "/");

        if (isAuthorized)
        {
            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            string filePath;
            if (ProductImageFileUpload.HasFile)
            {
                string uploadFilePath = uploadFolderPath + ProductImageFileUpload.FileName;
                ProductImageFileUpload.SaveAs(uploadFilePath);

                filePath = @"~/product_images/" + newItem.Id + "-" + newItem.Name + "/" + ProductImageFileUpload.FileName;
            }
            else
            {
                filePath = @"~/product_images/no_image.png";
            }

            newItem.ProductImagePath = filePath;

            itemController.addItem(newItem);

            ErrorLabel.Text = "Item added!";

            ItemNameTextBox.Text = "";
            PriceTextBox.Text = "";
            DescriptionTextBox.Text = "";

            ProductImageFileUpload.Dispose();
        }
        else
        {
            ErrorLabel.Text = "You are not authorized to enter new items in the database!";
        }
    }
}