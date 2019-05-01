using System.Data.SqlClient;

public class ConstantVariables
{
    public static SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\SiteData.mdf';Integrated Security=True");
}