namespace OptiStock.MAUI.Models
{
    public class UserModel : DomainObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UsersRights Rights { get; set; }
    }
}
