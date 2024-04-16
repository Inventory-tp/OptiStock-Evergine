namespace OptiStock.MAUI
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            //Register all routes
            Routing.RegisterRoute(nameof(Views.HomePage), typeof(Views.HomePage));
            Routing.RegisterRoute(nameof(Views.LoginPage), typeof(Views.LoginPage));
            Routing.RegisterRoute(nameof(Views.ManageUsersPage), typeof(Views.ManageUsersPage));
            Routing.RegisterRoute(nameof(Views.NewUserPage), typeof(Views.NewUserPage));
        }
    }
}