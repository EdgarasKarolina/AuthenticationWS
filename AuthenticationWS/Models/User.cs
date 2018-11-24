namespace AuthenticationWS.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public int IsAdmin { get; set; }
    }
}
