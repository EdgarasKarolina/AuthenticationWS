using AuthenticationWS.Utilities;
using MySql.Data.MySqlClient;

namespace AuthenticationWS.Models
{
    public class UserContext
    {
        public string ConnectionString { get; set; }

        public UserContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public int AuthenticateUser(string userName, string password)
        {
            var count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.AuthenticateUser, conn);
                cmd.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@UserPassword", MySqlDbType.VarChar).Value = password;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
            }
            return count;
        }
    }
}
