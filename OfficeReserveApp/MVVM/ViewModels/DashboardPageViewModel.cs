using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OfficeReserveApp.MVVM.ViewModels
{
    internal class DashboardPageViewModel
    {
        public ICommand LogoutCommand => new Command(() => { PerformLogoutOperation(); });

        private async void PerformLogoutOperation()
        {
            Preferences.Set("UserLoggedIn", false);
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
