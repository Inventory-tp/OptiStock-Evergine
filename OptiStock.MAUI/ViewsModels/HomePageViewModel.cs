using CommunityToolkit.Mvvm.ComponentModel;
using OptiStock.MAUI.Evergine;
using OptiStock.MAUI.Models;
using System.Windows.Input;

namespace OptiStock.MAUI.ViewsModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        string _buttonText;

        /*[ObservableProperty]
        EvergineView _evergineView;*/

        [ObservableProperty]
        ICommand _onButtonClicked;

        private int count = 0;

        //private readonly MyApplication _evergineApplication;

        public HomePageViewModel()
        {
            /*
            _evergineApplication = new MyApplication();
            _evergineView.Application = _evergineApplication;
            new ObjectRotationModel(_evergineView);*/
            _onButtonClicked = new Command(SetButtonText);
        }

        void SetButtonText(object sender)
        {
            _buttonText = "Button Clicked " + count++;
        }
    }
}
