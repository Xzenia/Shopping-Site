﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet itemDataSet = new DataSet(); 
        ItemController itemController = new ItemController();
        try
        {
            itemDataSet = itemController.viewAllItems();
        }
        catch
        {
            Response.Redirect("Home.aspx");
        }

        DealsList.DataSource = itemDataSet;
        DealsList.DataBind();

        ItemList.DataSource = itemDataSet;
        ItemList.DataBind();
    }
}