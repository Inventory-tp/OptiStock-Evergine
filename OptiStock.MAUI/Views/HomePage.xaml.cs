using OptiStock.MAUI.ViewsModels;

namespace OptiStock.MAUI.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomePageViewModel homePageViewModel)
        {
            InitializeComponent();
            BindingContext = homePageViewModel;
            this.evergineApplication = new MyApplication();
            this.evergineView.Application = this.evergineApplication;

            this.BindingContext = new ObjectRotationModel(this.evergineView);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            buttonText.Text = "Button Clicked " + count++;
        }
    }
}