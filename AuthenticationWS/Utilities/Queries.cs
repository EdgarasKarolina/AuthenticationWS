namespace AuthenticationWS.Utilities
{
    public static class Queries
    {
        public const string AuthenticateUser = "SELECT * from user WHERE UserName = @UserName AND UserPassword = @UserPassword;";
    }
}
