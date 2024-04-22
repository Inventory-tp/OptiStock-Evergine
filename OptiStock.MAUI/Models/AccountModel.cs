namespace OptiStock.MAUI.Models
{
    //Entity of the current user using the application
    public class AccountModel : DomainObject
    {
        public UserModel AccountHolder {  get; set; }
    }
}
