
public class Account
{
    private int memberId;

    public int MemberId
    {
        get { return memberId; }
        set { memberId = value; }
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
}