using OptiStock.MAUI.Models;
using OptiStock.MAUI.ViewsModels;

namespace OptiStock.MAUI.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly MyApplication evergineApplication;
        public HomePage(HomePageViewModel homePageViewModel)
        {
            InitializeComponent();
            BindingContext = homePageViewModel;
            this.evergineApplication = new MyApplication();
            this.evergineView.Application = this.evergineApplication;

            this.BindingContext = new ObjectRotationModel(this.evergineView);
        }
    }
}