using AuthenticationWS.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

        public void CreateUser(User user)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(Queries.CreateUser, conn);
                    cmd.Parameters.Add("@userName", MySqlDbType.VarChar).Value = user.UserName;
                    cmd.Parameters.Add("@userPassword", MySqlDbType.VarChar).Value = user.UserPassword;
                    cmd.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = user.LastName;
                    cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.Email;
                    cmd.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = user.PhoneNumber;
                    cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = user.Country;
                    cmd.Parameters.Add("@isAdmin", MySqlDbType.Int32).Value = 1;

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

        public List<object> GetUserIdEmailIsAdmin(string userName, string password)
        {
            var list = new List<object>();
            int userId = 0;
            string email = "";
            int isAdmin = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Queries.GetUserIdEmailIsAdmin, conn);
                cmd.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@UserPassword", MySqlDbType.VarChar).Value = password;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userId = reader.GetInt32(0);
                        email = reader.GetString(1);
                        isAdmin = reader.GetInt32(2);
                    }
                }
                list.Add(userId);
                list.Add(email);
                list.Add(isAdmin);
            }
            return list;
        }


    }
}
