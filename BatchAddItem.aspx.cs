using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class BatchAddItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        string excelUploadFilePath = Server.MapPath(@"/ExcelFiles/Uploads/");

        if (!Directory.Exists(excelUploadFilePath))
        {
            Directory.CreateDirectory(excelUploadFilePath);
        }

        Account currentAccount = (Account)Session["CurrentAccount"];

        string filePath = "";
        string date = DateTime.Today.ToShortDateString() + "-" + DateTime.Today.ToShortTimeString();
        if (ExcelFileUpload.HasFile)
        {
            filePath = excelUploadFilePath + ExcelFileUpload.FileName;
            ExcelFileUpload.SaveAs(filePath);
        }
        ItemController itemController = new ItemController();
        if (!filePath.Equals(""))
        {
            DataTable excelData = itemController.ProcessExcel(filePath);

            foreach (DataRow row in excelData.Rows)
            {
                Console.WriteLine("--- Row ---");
                foreach (var item in row.ItemArray)
                {
                    Console.Write("Item: ");
                    Console.WriteLine(item);
                }
            }
        }
    }
}