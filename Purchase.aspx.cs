﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Purchase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemController itemController = new ItemController();
        DataSet itemDataSet = itemController.viewAllItems();
        ItemList.DataSource = itemDataSet;
        ItemList.DataBind();
    }
}