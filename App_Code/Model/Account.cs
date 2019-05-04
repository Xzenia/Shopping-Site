
public class Account
{
    private string username;

    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    private string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    private AccountType accountType;

    public AccountType AccountType
    {
        get { return accountType; }
        set { accountType = value; }
    }

    private bool isAccountConfirmed;

    public bool IsAccountConfirmed
    {
        get { return isAccountConfirmed; }
        set { isAccountConfirmed = value; }
    }
}

public enum AccountType
{
    Admin = 1,
    Member = 2
}