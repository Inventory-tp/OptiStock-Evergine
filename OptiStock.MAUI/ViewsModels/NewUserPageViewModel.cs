using CommunityToolkit.Mvvm.ComponentModel;
using OptiStock.MAUI.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Windows.Input;
using OptiStock.MAUI.Services;
using OptiStock.MAUI.Services.Common;

namespace OptiStock.MAUI.ViewsModels
{
    public partial class NewUserPageViewModel : ObservableObject
    {
        private readonly IDataRepository<UserModel> _userRepository;

        [ObservableProperty]
        UserModel _user;

        [ObservableProperty]
        IEnumerable<UsersRights> _rights;

        [ObservableProperty]
        ICommand _save;
        public NewUserPageViewModel(IDataRepository<UserModel> userRepository)
        {
            _userRepository = userRepository;
            _save = new Command(AddUser);
        }

        async void AddUser() {
            if(User != null)
            {
                Result<UserModel> result = await _userRepository.Create(User);

                if (result.IsSuccess)
                {
                    CreateToast("The user "+ result.Value.Username + " have been created");
                }
                else
                {
                    CreateToast("Error : " + result.ErrorMessage);
                }
            }
        }

        private static async void CreateToast(string text)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            IToast toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
