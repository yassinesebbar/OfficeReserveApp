using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.Views;
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
        protected HttpClient Client { get; private set; } = App.client;


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

            RouteBasedOnUser();
        }

        public void RouteBasedOnUser()
        {
            if (AuthenticationService.UserIsAuthenticated())
            {
                if (AuthenticationService.User.Rol == Rol.Medewerker)
                {
                     Shell.Current.GoToAsync($"//{nameof(OfficeReservationOverviewPage)}");
                }else if (AuthenticationService.User.Rol == Rol.Officemanager)
                {
                    Shell.Current.GoToAsync($"//{nameof(OfficeManagementOverviewPage)}");
                }
                else
                {
                    // If user has a unknown role
                    Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
            }
            else
            {
                Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }

        public Boolean UserIsAuthenticated()
        {
            return AuthenticationService.UserIsAuthenticated();
        }
    }
}
