using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

public class AccountController
{
    public void addAccount(Account newAccount){
        SqlCommand command = new SqlCommand("AddAccount", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Username", newAccount.Username);
        command.Parameters.AddWithValue("@FirstName", newAccount.FirstName);
        command.Parameters.AddWithValue("@LastName", newAccount.LastName);
        command.Parameters.AddWithValue("@AccountAddress", newAccount.Address);
        command.Parameters.AddWithValue("@Password", newAccount.Password);
        command.Parameters.AddWithValue("@AccountType", newAccount.AccountType);
        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }

    public bool loginAccount(string username, string password){
        SqlCommand command = new SqlCommand ("AccountLogin", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Username", username);
        command.Parameters.AddWithValue("@Password", password);

        string accountUsername = "";
        string accountPassword = "";

        ConstantVariables.connect.Open();
        SqlDataReader dataReader = command.ExecuteReader();
        while (dataReader.Read()){
            accountUsername = Convert.ToString(dataReader["Username"]);
            accountPassword = Convert.ToString(dataReader["Password"]);
        }
        ConstantVariables.connect.Close();
        if (username.Equals(accountUsername) && password.Equals(accountPassword)){
            return true;
        } else {
            return false;
        }
    }

    public Account retrieveAccountDetails (string username){
        SqlCommand command = new SqlCommand ("RetrieveAccountDetails", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Username", username);
        
        ConstantVariables.connect.Open();
        SqlDataReader dataReader = command.ExecuteReader();
        Account account = new Account();
        while (dataReader.Read())
        {
            account.Username = dataReader["Username"].ToString();
            account.FirstName = Convert.ToString(dataReader["FirstName"]);
            account.LastName = Convert.ToString(dataReader["LastName"]);
            account.Address = Convert.ToString(dataReader["AccountAddress"]);
            account.Password = Convert.ToString(dataReader["Password"]);
            account.AccountType = (AccountType)dataReader["AccountType"];
        }
        ConstantVariables.connect.Close();

        return account; 
    }

    public bool isAccountAdmin(string username)
    {
        Account account = retrieveAccountDetails(username);
        if (account.AccountType == AccountType.Admin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool doesAccountExist(string username)
    {
        SqlCommand command = new SqlCommand("RetrieveUsernameCount", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Username", username);

        ConstantVariables.connect.Open();
        int count = (int)command.ExecuteScalar();
        ConstantVariables.connect.Close();

        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataSet viewAllAccounts(){
        ConstantVariables.connect.Open();
        SqlDataAdapter dataAdapter = new SqlDataAdapter("ViewAllAccounts", ConstantVariables.connect);
        dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet);
        ConstantVariables.connect.Close();
        return dataSet;
    }
}