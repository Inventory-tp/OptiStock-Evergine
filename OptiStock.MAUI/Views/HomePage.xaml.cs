using OptiStock;

namespace OptiStock.MAUI.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly MyApplication evergineApplication;

        public HomePage()
        {
            InitializeComponent();
            this.evergineApplication = new MyApplication();
            this.evergineView.Application = this.evergineApplication;
        }
    }
}