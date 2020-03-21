namespace AuthenticationWS.Models
{
    public class User
    {
        internal int UserId { get; set; }
        internal string UserName { get; set; }
        internal string UserPassword { get; set; }
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string Email { get; set; }
        internal string PhoneNumber { get; set; }
        internal string Country { get; set; }
        internal int IsAdmin { get; set; }
    }
}
