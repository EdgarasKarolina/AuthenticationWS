﻿namespace AuthenticationWS.Utilities
{
    public static class Queries
    {
        public const string AuthenticateUser = "SELECT COUNT(*) FROM user WHERE UserName = @UserName AND UserPassword = SHA2(@UserPassword, 224);";

        public const string GetUserIdEmailIsAdmin = "SELECT UserId, Email, IsAdmin FROM user WHERE UserName = @UserName AND UserPassword = SHA2(@UserPassword, 224);";

        public const string GetUserName = "SELECT UserName FROM user WHERE UserId = @UserId;";

        public const string CreateUser = "INSERT INTO user (UserName, UserPassword, FirstName, LastName, Email, PhoneNumber, Country, IsAdmin)\n" +
                    "VALUES (@userName, SHA2(@userPassword, 224), @firstName, @lastName, @email, @phoneNumber, @country, @isAdmin);";
    }
}
