namespace OptiStock.MAUI
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            //Register all routes
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("home", typeof(HomePage));
        }
    }
}