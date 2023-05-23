using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.ViewModels
{


    public class BaseViewModel
    {
        protected AuthenticationService AuthenticationService { get; private set; } = App.authenticationService;

        public BaseViewModel()
        {
            
        }

        public void UserAuthentication()
        {
            if (!AuthenticationService.UserIsAuthenticated())
            {
                Logout();
            }
        }

        public async void Logout()
        {
            AuthenticationService.Logout();

            RouteBasedOnState();

        }

        public async void Login(LoginRequestModel loginRequest) 
        {

            await AuthenticationService.Login(loginRequest);

            if (AuthenticationService.UserIsAuthenticated())
            {
                RouteBasedOnState();
            }
        }

        public void RouteBasedOnState()
        {
            if (AuthenticationService.UserIsAuthenticated())
            {
                if (AuthenticationService.User.Rol == Rol.Medewerker)
                {
                     Shell.Current.GoToAsync(state: "//WorkSpotOverviewPage");
                }else if (AuthenticationService.User.Rol == Rol.Officemanager)
                {
                    Shell.Current.GoToAsync(state: "//OfficeManagementOverviewPage");
                }
            }
            else
            {
                Shell.Current.GoToAsync(state: "//LoginPage");
            }
        }

        public Boolean UserIsAuthenticated()
        {
            return AuthenticationService.UserIsAuthenticated();
        }
    }
}
