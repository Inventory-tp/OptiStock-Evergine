using OptiStock.MAUI.ViewsModels;

namespace OptiStock.MAUI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginPageViewModel loginPageViewModel)
        {
            InitializeComponent();
            BindingContext = loginPageViewModel;
        }
    }
}
