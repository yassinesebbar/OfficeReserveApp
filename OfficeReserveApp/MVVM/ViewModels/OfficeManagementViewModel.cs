using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.Services;
using PropertyChanged;
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

                AddToLoadingque(process);

                OfficeReservations = await ReservationService.TaskGetOfficeReservations(SelectedDay);

                RemoveFromLoadingque(process);
            }
          
        }

        public async void UpdateOffice()
        {
            string process = Constants.UpdateOffice_Process;

            AddToLoadingque(process);

            ActionResult actionResult = await ReservationService.TaskUpdateOffice(OfficeInfo);

            SnackBar.Result(actionResult);

            RemoveFromLoadingque(process);
        }

        public async void GetDailyAvailability()
        {
            string process = Constants.GetDailyAvailability_Process;

            AddToLoadingque(process);

            OfficeDailyAvailabilities = await ReservationService.TaskGetOfficeDailyAvailability();

            if(OfficeDailyAvailabilities != null && OfficeDailyAvailabilities.Count > 0)
            {
                
                SelectedDay = OfficeDailyAvailabilities.OrderBy(o => o.Day).First();
            }
                

            RemoveFromLoadingque(process);
        }

        public async void DeleteOfficeReservation(object obj)
        {
            string process = Constants.DeleteOfficeReservation_Process;

            AddToLoadingque(process);

            Reservation reservation = (Reservation)obj;
            ActionResult actionResult = await ReservationService.TaskDeleteReservation(reservation);

            SnackBar.Result(actionResult);

            RemoveFromLoadingque(process);

            UpdateData();
        }

        public void UpdateData()
        {
            GetDailyAvailability();
            GetOfficeReservations();
        }

    }
}
