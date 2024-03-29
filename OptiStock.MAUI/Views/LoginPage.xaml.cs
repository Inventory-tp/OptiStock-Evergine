using OptiStock;

namespace OptiStock.MAUI.Views
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//home");
        }
    }
}
