using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiStock.MAUI.Views
{
    internal class LoginPage
    {
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/home");
        }
    }
}
