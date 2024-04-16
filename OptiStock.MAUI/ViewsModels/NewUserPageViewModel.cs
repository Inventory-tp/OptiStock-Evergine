using CommunityToolkit.Mvvm.ComponentModel;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.Repositories;

namespace OptiStock.MAUI.ViewsModels
{
    public partial class NewUserPageViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;

        [ObservableProperty]
        UserModel _user;

        public Task addUser(string firstName, string lastName, string dateOfBirth, string password, UsersRights rights) {
            UserModel userModel = new UserModel();

            if(User != null)
            {
                return _userRepository.Add(User); //TODO faire la connection avec la page (la page manque encore ces bindings) et ajouter tous les param
            }
        }
    }
}
