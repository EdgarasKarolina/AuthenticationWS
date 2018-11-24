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

        /*
        public void CreateUser(string userName, string userPassword, string firstName, string lastName, string email, string phoneNumber, string country, int isAdmin)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateReservation, conn);
                    cmd.Parameters.Add("@berthId", MySqlDbType.Int16).Value = berthId;
                    cmd.Parameters.Add("@customerId", MySqlDbType.Int16).Value = customerId;
                    cmd.Parameters.Add("@checkIn", MySqlDbType.DateTime).Value = checkIn;
                    cmd.Parameters.Add("@checkOut", MySqlDbType.DateTime).Value = checkOut;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
        }
        */

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
