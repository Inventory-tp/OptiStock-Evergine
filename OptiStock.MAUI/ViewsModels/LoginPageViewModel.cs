using CommunityToolkit.Mvvm.ComponentModel;
using OptiStock.MAUI.Commands;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.State.Authenticators;
using System.Windows.Input;

namespace OptiStock.MAUI.ViewsModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [ObservableProperty]
        UserModel _user;

        [ObservableProperty]
        ICommand loginCommand;

        private IAuthenticator _authenticator;

        public LoginPageViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            loginCommand = new LoginCommand(this, _authenticator);
        }

        /*private async void BtnLogin_Click(object sender)
        {
            
            await Shell.Current.GoToAsync("//home");
        }*/



        /*private async void BtnLogin_Click(object sender)
        {
            
            await Shell.Current.GoToAsync("//home");
        }*/
    }
}
