using System.Data.SqlClient;

public class ConstantVariables
{
    public static SqlConnection connect = new SqlConnection(@"Data Source=(Localdb)\mssqllocaldb;AttachDbFilename='|DataDirectory|\SiteData.mdf';Integrated Security=True");
}