using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet itemDataSet = new DataSet();
        DataSet itemSaleDataSet = new DataSet();

        ItemController itemController = new ItemController();

        try
        {
            itemDataSet = itemController.viewAllItems();
            itemSaleDataSet = itemController.viewItemsOnSale();
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = "An error has occurred. Do not worry, this will be resolved soon!<br/> <br/> <br/>Exception message for nerds: " + ex.ToString();
        }

        DealsList.DataSource = itemSaleDataSet;
        DealsList.DataBind();

        ItemList.DataSource = itemDataSet;
        ItemList.DataBind();
    }
}