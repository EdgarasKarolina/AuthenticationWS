namespace AuthenticationWS.Utilities
{
    public static class Queries
    {
        public const string AuthenticateUser = "SELECT count(*) from user WHERE UserName = @UserName AND UserPassword = @UserPassword;";

        public const string CreateUser = "INSERT INTO user (UserName, UserPassword, FirstName, LastName, Email, PhoneNumber, Country, IsAdmin)\n" +
                    "VALUES (@userName, @userPassword, @firstName, @lastName, @email, @phoneNumber, @country, @isAdmin);";
    }
}
