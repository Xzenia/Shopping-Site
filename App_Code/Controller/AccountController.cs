using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;

public class AccountController
{
    public void addAccount(Account newAccount)
    {
        SqlCommand command = new SqlCommand("AddAccount", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Username", newAccount.Username);
        command.Parameters.AddWithValue("@FirstName", newAccount.FirstName);
        command.Parameters.AddWithValue("@LastName", newAccount.LastName);
        command.Parameters.AddWithValue("@AccountAddress", newAccount.Address);
        command.Parameters.AddWithValue("@EmailAddress", newAccount.Email);
        command.Parameters.AddWithValue("@Password", ConvertNewPasswordToHash(newAccount.Password));
        command.Parameters.AddWithValue("@AccountType", newAccount.AccountType);
        command.Parameters.AddWithValue("@IsEmailConfirmed", 0);

        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
    }

    private string ConvertNewPasswordToHash(string password)
    {
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        string passwordHash = Convert.ToBase64String(hashBytes);

        return passwordHash;
    }

    private bool ConfirmPassword(string accountPassword, string inputPassword)
    {
        byte[] hashBytes = Convert.FromBase64String(accountPassword);
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);
        var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);

        for (int i=0; i < 20; i++)
        {
            if (hashBytes[i + 16] != hash[i])
            {
                return false;
            }
        }
        return true;
    }

    public bool loginAccount(string username, string password)
    {
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

        if (username.Equals(accountUsername))
        {
            if (ConfirmPassword(accountPassword, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public Account retrieveAccountDetails (string username)
    {
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
            account.Email = Convert.ToString(dataReader["EmailAddress"]);
            account.Password = Convert.ToString(dataReader["Password"]);
            account.AccountType = (AccountType)dataReader["AccountType"];

            if (Convert.ToInt32(dataReader["IsEmailConfirmed"]) == 1)
            {
                account.IsAccountConfirmed = true;
            }
            else
            {
                account.IsAccountConfirmed = false;
            }
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

    public void updateConfirmationStatus(string username, bool isEmailConfirmed)
    {
        SqlCommand command = new SqlCommand("UpdateConfirmationStatus", ConstantVariables.connect);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Username", username);
        if (isEmailConfirmed)
        {
            command.Parameters.AddWithValue("@IsEmailConfirmed", 1);
        }
        else
        {
            command.Parameters.AddWithValue("@IsEmailConfirmed", 0);
        }

        ConstantVariables.connect.Open();
        command.ExecuteNonQuery();
        ConstantVariables.connect.Close();
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