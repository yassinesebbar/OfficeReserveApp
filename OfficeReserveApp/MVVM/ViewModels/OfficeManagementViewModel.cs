using OfficeReserveApp.DTOModels;
using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OfficeReserveApp.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class OfficeManagementViewModel : BaseViewModel
    {
        public List<Reservation> OfficeReservations { get; set; }
        public List<DailyAvailability> OfficeDailyAvailabilities { get; set; }
        public DailyAvailability SelectedDay { get; set; }
        public Office OfficeInfo { get; set; }

        public ICommand DeleteOfficeReservationCommand { get; set; }
        public ICommand ChangeDailyAvailabilityCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public OfficeManagementViewModel(Image loadingImg) : base(loadingImg)
        {
            OfficeReservations = new List<Reservation>();
            OfficeDailyAvailabilities = new List<DailyAvailability>();
            ReservationService = new ReservationService();

            DeleteOfficeReservationCommand = new Command((object obj) => { DeleteOfficeReservation(obj); });
            ChangeDailyAvailabilityCommand = new Command(GetOfficeReservations);
            UpdateViewCommand = new Command(UpdateData);
        }

        public async void GetOfficeInfo()
        {
            OfficeInfo = await ReservationService.TaskGetMyOfficeInfo();
        }

        public async void GetOfficeReservations()
        {
            if (OfficeDailyAvailabilities.Count > 0)
            {
                string process = Constants.GetMyOfficeReservations_Process;

                AddToLoadingqueue(process);

                OfficeReservations = await ReservationService.TaskGetOfficeReservations(SelectedDay);

                RemoveFromLoadingqueue(process);
            }
          
        }

        public async void UpdateOffice()
        {
            string process = Constants.UpdateOffice_Process;

            AddToLoadingqueue(process);

            ActionResult actionResult = await ReservationService.TaskUpdateOffice(OfficeInfo);

            if (actionResult != null && actionResult.IsSuccess)
            {
                SnackBar.Succesfull(actionResult.Message);
            }
            else
            {
                SnackBar.UnSuccesfull(actionResult.Message);
            }

            RemoveFromLoadingqueue(process);
        }

        public async void GetDailyAvailability()
        {
            string process = Constants.GetDailyAvailability_Process;

            AddToLoadingqueue(process);

            OfficeDailyAvailabilities = await ReservationService.TaskGetOfficeDailyAvailability();

            if(OfficeDailyAvailabilities != null && OfficeDailyAvailabilities.Count > 0)
            {
                
                SelectedDay = OfficeDailyAvailabilities.OrderBy(o => o.Day).First();
            }
                

            RemoveFromLoadingqueue(process);
        }

        public async void DeleteOfficeReservation(object obj)
        {
            string process = Constants.DeleteOfficeReservation_Process;

            AddToLoadingqueue(process);

            Reservation reservation = (Reservation)obj;
            ActionResult actionResult = await ReservationService.TaskDeleteReservation(reservation);

            if (actionResult != null && actionResult.IsSuccess)
            {
                SnackBar.Succesfull(actionResult.Message);
            }
            else
            {
                SnackBar.UnSuccesfull(actionResult.Message);
            }

            RemoveFromLoadingqueue(process);

            UpdateData();
        }

        public void UpdateData()
        {
            GetDailyAvailability();
            GetOfficeReservations();
        }

    }
}
