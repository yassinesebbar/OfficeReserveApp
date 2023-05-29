using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class OfficeReservationOverviewModel : BaseViewModel
    {
        public List<Reservation> MyOfficeReservations { get; set; }
        public List<DailyAvailability> OfficeDailyAvailabilities { get; set; }
        private ReservationService ReservationService { get; set; }
        public User CurrentUser { get; private set; }

        public OfficeReservationOverviewModel() 
        {
            MyOfficeReservations = new List<Reservation>();
            OfficeDailyAvailabilities = new List<DailyAvailability>();
            CurrentUser = AuthenticationService.User;
            ReservationService =  new ReservationService();
           
        }

        public async void GetMyOfficeReservations()
        {
            MyOfficeReservations = await ReservationService.TaskGetMyOfficeReservations();
        }

        public async void GetDailyAvailability()
        {
            OfficeDailyAvailabilities = await ReservationService.TaskGetMyOfficeDailyAvailability();
        }

    }
}
