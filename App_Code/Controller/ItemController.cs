using System.Data.SqlClient;
using System.Data;
using System;
using System.Drawing;
using System.IO;

public class ItemController
{
    public void addItem(Item item)
    {
        SqlCommand command = new SqlCommand("AddItem", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Name", item.Name);
        command.Parameters.AddWithValue("@Stock", item.Quantity);
        command.Parameters.AddWithValue("@PricePerItem", item.PricePerItem);
        command.Parameters.AddWithValue("@ProductImagePath", item.ProductImagePath);
        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }

    public void editItem(Item item)
    {
        SqlCommand command = new SqlCommand("EditItem", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ItemID", item.Id);
        command.Parameters.AddWithValue("@Name", item.Name);
        command.Parameters.AddWithValue("@Stock", item.Quantity);
        command.Parameters.AddWithValue("@PricePerItem", item.PricePerItem);
        command.Parameters.AddWithValue("@ProductImagePath", item.ProductImagePath);
        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }

    public void deleteItem(int itemID)
    {
        SqlCommand command = new SqlCommand("DeleteItem", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ItemID", itemID);

        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }

    public void editItemStock(int itemID, int amount)
    {
        SqlCommand command = new SqlCommand("EditItemStock", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ItemID", itemID);
        command.Parameters.AddWithValue("@Stock", amount);

        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }


    public Item retrieveItem(int itemID)
    {
        SqlCommand command = new SqlCommand("RetrieveItem", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ItemID", itemID);

        Item item = new Item();

        ConstantVariables.connect.Open();

        SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            item.Id = Convert.ToInt32(dataReader["ItemID"]);
            item.Name = Convert.ToString(dataReader["Name"]);
            item.Quantity = Convert.ToInt32(dataReader["Stock"]);
            item.PricePerItem = Convert.ToDouble(dataReader["PricePerItem"]);

            item.ProductImagePath = Convert.ToString(dataReader["ProductImagePath"]);
        }

        ConstantVariables.connect.Close();

        return item;
    }

    public DataSet viewAllItems()
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter("ViewAllItems", ConstantVariables.connect);
        DataSet dataSet = new DataSet();

        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        dataAdapter.Fill(dataSet);

        return dataSet;
    }

    public void updateSalePrice(int itemId, double salePrice)
    {
        SqlCommand command = new SqlCommand("UpdateItemSalePrice", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ItemID", itemId);
        command.Parameters.AddWithValue("@SalePrice", salePrice);

        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }

    public DataSet viewItemsOnSale()
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter("RetrieveItemsOnSale", ConstantVariables.connect);
        DataSet dataSet = new DataSet();

        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        dataAdapter.Fill(dataSet);

        return dataSet;
    }
}