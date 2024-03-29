namespace OptiStock.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.MinimumHeight = 600;
            window.MinimumWidth = 800;
  

            return window;
        }
    }
}