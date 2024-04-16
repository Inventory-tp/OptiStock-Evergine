using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.Repositories;
using OptiStock.MAUI.Views;

namespace OptiStock.MAUI.ViewsModels
{
    public partial class ManageUsersViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;


        //Redirect from manageUserPage to NewUserPage
        [RelayCommand]
        async Task AddUSer()
        {
            await AppShell.Current.GoToAsync(nameof(NewUserPage));
        }

        public Task<List<UserModel>> getUsers() => _userRepository.getList();
       
    }
}
