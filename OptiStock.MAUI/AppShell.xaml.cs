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
        }
    }
}