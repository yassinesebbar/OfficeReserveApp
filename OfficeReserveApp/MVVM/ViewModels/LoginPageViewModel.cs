using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModels;
using PropertyChanged;

namespace OfficeReserveApp.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]


    public class LoginPageViewModel : BaseViewModel
    {
        public LoginRequestModel LoginRequest { get; set; } = new LoginRequestModel();

        public void LoginAction()
        {
            Login(LoginRequest);
        }

        public Boolean LoginIsSuccessful()
        {
            return AuthenticationService.UserIsAuthenticated();
        }

    }
}
