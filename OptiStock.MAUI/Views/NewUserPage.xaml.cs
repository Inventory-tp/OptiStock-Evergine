using OptiStock.MAUI.ViewsModels;

namespace OptiStock.MAUI.Views;

public partial class NewUserPage : ContentPage
{
	public NewUserPage(NewUserPageViewModel newUserPageViewModel)
	{
		InitializeComponent();
		BindingContext = newUserPageViewModel;

    }
}