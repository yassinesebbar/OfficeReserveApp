
using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.Views;
using OfficeReserveApp.Services;
using PropertyChanged;
using System.Windows.Input;


namespace OfficeReserveApp.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]

    public class BaseViewModel
    {

        public User CurrentUser { get; private set; }
        protected ReservationService ReservationService { get; set; }

        /*  Maui has an bug with enableing  animation of image through binding. I had to retrieve the image from view and manipulate it from view model.*/
        private readonly Image LoadingImage;
        protected AuthenticationService AuthenticationService { get; private set; }
        protected HttpClient Client { get; private set; } = App.client;
        public ICommand LogoutCommand => new Command(() => { Logout(); });

  

        /*        while array is not empty animate the loading image */
        public Boolean IsLoading
        {
            get {
                return Loadingqueue.Count > 0;
            } 
        }
        private List<string> Loadingqueue { get;  set; } = new List<string>();

        public BaseViewModel(Image image = null)
        {
            AuthenticationService = App.authenticationService;
            LoadingImage= image;
            CurrentUser = AuthenticationService.User;

        }

/*        Add active processes to Loadingqueue array while array is niet empty animate the loading image
*/        public void AddToLoadingqueue(string process)
        {
            Loadingqueue.Add(process);
            if (LoadingImage != null)
            {
                LoadingImage.IsAnimationPlaying = IsLoading;
            }
        }

        public  void RemoveFromLoadingqueue(string process)
        {
            Loadingqueue.Remove(process);
            if (LoadingImage != null)
            {
                LoadingImage.IsAnimationPlaying = IsLoading;
            }
        }

    

        public void Logout()
        {
            AuthenticationService.Logout();
            var app = Application.Current as OfficeReserveApp.App;
            app.MainPage = new AppShell();
        }

        public async void Login(LoginRequestModel loginRequest)
        {
            await AuthenticationService.Login(loginRequest);
            RouteBasedOnIdenitity();
        }

/*        when the user logs in he will be routed based off identity
*/        public void RouteBasedOnIdenitity()
        {
            if (AuthenticationService.UserIsAuthenticated())
            {
                if (AuthenticationService.User.Rol == Rol.Medewerker)
                {
                    Shell.Current.GoToAsync($"//{nameof(OfficeReservationOverviewPage)}");
                }
                else if (AuthenticationService.User.Rol == Rol.Officemanager)
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

        private Boolean UserIsAuthenticated()
        {
            return AuthenticationService.UserIsAuthenticated();
        }
    }
}
