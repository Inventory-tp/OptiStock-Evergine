using OptiStock.MAUI.ViewsModels;

namespace OptiStock.MAUI.Views
{
    public partial class ManageUsersPage : ContentPage
    {
        public ManageUsersPage(ManageUsersViewModel manageUsersViewModel)
        {
            InitializeComponent();
            BindingContext = manageUsersViewModel;
        }
    }
}