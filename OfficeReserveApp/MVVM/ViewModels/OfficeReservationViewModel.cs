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

    public class OfficeReservationViewModel : BaseViewModel
    {

        public List<Reservation> MyOfficeReservations { get; set; }
        public List<DailyAvailability> OfficeDailyAvailabilities { get; set; }
        private ReservationService ReservationService { get; set; }
        public DailyAvailability SelectedDay { get; set; }

        public TimeSpan StartTimeSpan { get; set; }
        public TimeSpan EndTimeSpan { get; set; }

        public ICommand DeleteOfficeReservationCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public Boolean ReadyToCreateReservation
        {
            get { 
            
            return ReadyToCreateReservationCheck();
            }
        }

        public OfficeReservationViewModel(Image loadingImg) : base(loadingImg)
        {
            MyOfficeReservations = new List<Reservation>();
            OfficeDailyAvailabilities = new List<DailyAvailability>();
            ReservationService = new ReservationService();

            DeleteOfficeReservationCommand = new Command((object obj) => { DeleteOfficeReservation(obj); });
            CreateReservationCommand = new Command(CreateReservation);
            UpdateViewCommand = new Command(UpdateData);
        }

        public void UpdateData()
        {
            GetDailyAvailability();
            GetMyOfficeReservations();
        }


        public async void CreateReservation()
        {
            string process = Constants.CreateOffieceReservation_Process;

            AddToLoadingqueue(process);

            Reservation NewReservation = new Reservation();
            NewReservation.StartTime = new DateTime(SelectedDay.Day.Ticks + StartTimeSpan.Ticks);
            NewReservation.EndTime = new DateTime(SelectedDay.Day.Ticks + EndTimeSpan.Ticks);
            NewReservation.Date = SelectedDay.Day;
            if (ReservationIsValid(NewReservation))
            {
               MyOfficeReservations = await ReservationService.TaskCreateReservation(NewReservation);
            }

            RemoveFromLoadingqueue(process);
        }

        public async void DeleteOfficeReservation(object obj)
        {
            string process = Constants.DeleteOfficeReservation_Process;

            AddToLoadingqueue(process);

            Reservation reservation = (Reservation)obj;
            MyOfficeReservations = await ReservationService.TaskDeleteMyReservation(reservation);

            RemoveFromLoadingqueue(process);

        }

        public async void GetMyOfficeReservations()
        {
            string process = Constants.GetMyOfficeReservations_Process;

            AddToLoadingqueue(process);

            MyOfficeReservations = await ReservationService.TaskGetMyOfficeReservations();

            RemoveFromLoadingqueue(process);

        }

        public async void GetDailyAvailability()
        {
            string process = Constants.GetDailyAvailability_Process;

            AddToLoadingqueue(process);

            OfficeDailyAvailabilities = await ReservationService.TaskGetMyOfficeDailyAvailability();

            RemoveFromLoadingqueue(process);
        }

        public Boolean ReadyToCreateReservationCheck()
        {
            return this.SelectedDay != null && StartTimeSpan.Ticks > 0 && EndTimeSpan.Ticks > 0;
        }


        public void CheckDayIsReservable()
        {
            if (SelectedDay.Status == StatusAvailability.Closed)
                SelectedDay = null;
        }

        public Boolean ReservationIsValid(Reservation reservation)
        {
            if (reservation.StartTime < DateTime.Now)
            {
                return false;
            }
            else if (reservation.StartTime > reservation.EndTime)
            {
                return false;
            }

            return true;
        }


    }
}
