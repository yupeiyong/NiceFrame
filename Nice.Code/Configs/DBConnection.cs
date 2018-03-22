using NFine.Code;
using Nice.Common.Security;


namespace Nice.Common.Configs
{
    public class DbConnection
    {
        public static bool Encrypt { get; set; }
        public DbConnection(bool encrypt)
        {
            Encrypt = encrypt;
        }
        public static string ConnectionString
        {
            get
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["NiceDbContext"].ConnectionString;
                if (Encrypt == true)
                {
                    return DesEncrypt.Decrypt(connection);
                }
                else
                {
                    return connection;
                }
            }
        }
    }
}
