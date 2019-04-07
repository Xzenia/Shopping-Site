using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Receipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["OrderList"] != null)
        {
            List<Item> orderList = (List<Item>)Session["OrderList"];
            double totalPrice = 0;
            foreach (Item item in orderList)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                cell1.Text = item.Name;
                cell2.Text = "Php "+item.PricePerItem;
                cell3.Text = "x" + item.Quantity;
                cell4.Text = "Php " + item.PricePerItem * item.Quantity;
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);

                totalPrice += item.PricePerItem * item.Quantity;

                OrderTable.Rows.Add(row);
            }
            TotalCostLabel.Text = "Total Cost: Php " + totalPrice;
        }
    }
}