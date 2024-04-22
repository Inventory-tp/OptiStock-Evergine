using CommunityToolkit.Mvvm.ComponentModel;
using OptiStock.MAUI.State.Authenticators;

namespace OptiStock.MAUI.ViewsModels
{
    public class ConnectionStatusViewModel : ObservableObject
    {
        private readonly IAuthenticator _authenticator;

        public ConnectionStatusViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public bool IsLoggedIn  => _authenticator.IsLoggedIn;

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

    }
}
