using SQLite;

namespace OptiStock.MAUI.Models
{
    public class UserModel
    {
        //UUID in C# is generate with Guid
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public String password { get; set; }
        public UsersRights rights { get; set; }
    }
}
