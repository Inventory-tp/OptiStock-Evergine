using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.Services;
using OptiStock.MAUI.Services.Common;
using OptiStock.MAUI.Views;

namespace OptiStock.MAUI.ViewsModels
{
    public partial class ManageUsersViewModel : ObservableObject
    {
        private readonly IDataRepository<UserModel> _userRepository;

        public ManageUsersViewModel(IDataRepository<UserModel> userRepository)
        {
            _userRepository = userRepository;
        }

        //Redirect from manageUserPage to NewUserPage
        [RelayCommand]
        async Task AddUser()
        {
            await AppShell.Current.GoToAsync(nameof(NewUserPage));
        }
        [RelayCommand]
        async Task<Result<IEnumerable<UserModel>>> GetUsers() => await _userRepository.GetAll();
    }
}
