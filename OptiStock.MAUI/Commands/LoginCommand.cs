using OptiStock.MAUI.State.Authenticators;
using OptiStock.MAUI.ViewsModels;
using System.Windows.Input;

namespace OptiStock.MAUI.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginPageViewModel _loginPageViewModel;
        private readonly IAuthenticator _authenticator;

        public LoginCommand(LoginPageViewModel loginPageViewModel, IAuthenticator authenticator)
        {
            _loginPageViewModel = loginPageViewModel;
            _authenticator = authenticator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await _authenticator.Login(_loginPageViewModel.User.Username, _loginPageViewModel.User.Username);
        }
    }
}
