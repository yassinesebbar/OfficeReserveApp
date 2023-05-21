using OfficeReserveApp.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OfficeReserveApp.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]


    public class LoginViewModel
    {

        public LoginRequestModel loginRequest { get; private set; } = new LoginRequestModel();


        public ICommand LoginCommand => new Command(() => { PerformLoginOperation(); });

        private async void PerformLoginOperation()
        {
            //Perform API Operation

            Preferences.Set("UserLoggedIn", true);

            await Shell.Current.GoToAsync(state:"//DashboardPage");
        }


        public LoginViewModel()
        {
            
        }
            


    }
}
