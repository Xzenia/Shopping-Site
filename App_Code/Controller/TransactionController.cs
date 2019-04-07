using System;
using System.Data.SqlClient;
using System.Data;

public class TransactionController
{
    public void addTransaction(Item item, Account account, double totalPrice)
    {
        SqlCommand command = new SqlCommand("AddTransaction", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Date", DateTime.Today.ToString("d"));
        command.Parameters.AddWithValue("@Time", DateTime.Now.ToString("h:mm:ss tt"));
        command.Parameters.AddWithValue("@FullName", account.FirstName + " " + account.LastName);
        command.Parameters.AddWithValue("@MemberID", account.MemberId);
        command.Parameters.AddWithValue("@ItemName", item.Name);
        command.Parameters.AddWithValue("@PricePerItem", item.PricePerItem);
        command.Parameters.AddWithValue("@Quantity", item.Quantity);
        command.Parameters.AddWithValue("@TotalItemPrice", item.PricePerItem * item.Quantity);
        command.Parameters.AddWithValue("@TotalTransactionPrice", totalPrice);

        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }

    public DataSet viewAllTransactions()
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter("ViewAllTransactions", ConstantVariables.connect);
        DataSet dataSet = new DataSet();

        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        dataAdapter.Fill(dataSet);

        return dataSet;
    }

    public DataTable viewTransaction(string username)
    {
        SqlCommand command = new SqlCommand("ViewTransaction", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@MemberID", username);

        DataTable transactionTable = new DataTable();

        ConstantVariables.connect.Open();
        transactionTable.Load(command.ExecuteReader());
        ConstantVariables.connect.Close();

        return transactionTable;
    }
}