using OptiStock.MAUI.Models;

namespace OptiStock.MAUI.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly MyApplication evergineApplication;

        private int count = 0;

        public HomePage()
        {
            InitializeComponent();
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