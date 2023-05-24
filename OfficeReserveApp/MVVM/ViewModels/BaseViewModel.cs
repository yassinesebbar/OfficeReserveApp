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
        protected AuthenticationService AuthenticationService { get; private set; }

        public BaseViewModel()
        {
            AuthenticationService= App.authenticationService;
        }

        public void Logout()
        {
            AuthenticationService.Logout();

            RouteBasedOnUser();

        }

        public async void Login(LoginRequestModel loginRequest) 
        {

            await AuthenticationService.Login(loginRequest);

            if (AuthenticationService.UserIsAuthenticated())
            {
                RouteBasedOnUser();
            }
        }

        public void RouteBasedOnUser()
        {
            if (AuthenticationService.UserIsAuthenticated())
            {
                if (AuthenticationService.User.Rol == Rol.Medewerker)
                {
                     Shell.Current.GoToAsync(state: Constants.WorkSpotOverview);
                }else if (AuthenticationService.User.Rol == Rol.Officemanager)
                {
                    Shell.Current.GoToAsync(state: Constants.OfficeManagerOverview);
                }
                else
                {
                    // If user has a unknown role
                    Shell.Current.GoToAsync(state: Constants.LoginPage);
                }
            }
            else
            {
                Shell.Current.GoToAsync(state: Constants.LoginPage);
            }
        }

        public Boolean UserIsAuthenticated()
        {
            return AuthenticationService.UserIsAuthenticated();
        }
    }
}
