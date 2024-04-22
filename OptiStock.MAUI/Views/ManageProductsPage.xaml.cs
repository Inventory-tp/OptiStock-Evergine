using OptiStock.MAUI.ViewsModels;

namespace OptiStock.MAUI.Views;

public partial class ManageProductsPage : ContentPage
{
	public ManageProductsPage(ManageProductsPageViewModel manageProductsPageViewModel)
	{
		InitializeComponent();
		BindingContext = manageProductsPageViewModel;
    }
}