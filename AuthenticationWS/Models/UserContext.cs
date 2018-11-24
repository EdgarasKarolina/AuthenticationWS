using AuthenticationWS.Utilities;
using MySql.Data.MySqlClient;
using System;

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

        public void CreateUser(string userName, string userPassword, string firstName, string lastName, string email, string phoneNumber, string country, int isAdmin)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateUser, conn);
                    cmd.Parameters.Add("@userName", MySqlDbType.VarChar).Value = userName;
                    cmd.Parameters.Add("@userPassword", MySqlDbType.VarChar).Value = userPassword;
                    cmd.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = firstName;
                    cmd.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = lastName;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = phoneNumber;
                    cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = country;
                    cmd.Parameters.Add("@lastName", MySqlDbType.Int32).Value = isAdmin;

                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
            }
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
