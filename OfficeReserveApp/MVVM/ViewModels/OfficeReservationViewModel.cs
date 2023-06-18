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

    public class OfficeReservationViewModel : BaseViewModel
    {

        public List<Reservation> MyOfficeReservations { get; set; }
        public List<DailyAvailability> OfficeDailyAvailabilities { get; set; }
        public DailyAvailability SelectedDay { get; set; }


        public ICommand DeleteOfficeReservationCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        /*Boolean to enable creating reservation after requirements are met*/
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

            Reservation NewReservation = new()
            {
                StartTime = new(SelectedDay.Day.Ticks + StartTimeSpan.Ticks),
                EndTime = new(SelectedDay.Day.Ticks + EndTimeSpan.Ticks),
                Date = SelectedDay.Day
            };

            if (ReservationIsValid(NewReservation))
            {

                ActionResult actionResult = await ReservationService.TaskCreateReservation(NewReservation);
                if (actionResult != null && actionResult.IsSuccess)
                {
                    GetMyOfficeReservations();
                    SnackBar.Succesfull(actionResult.Message);
                }
                else
                {
                    SnackBar.UnSuccesfull(actionResult.Message);
                }
            }

            RemoveFromLoadingqueue(process);
        }

        public async void DeleteOfficeReservation(object obj)
        {
            string process = Constants.DeleteOfficeReservation_Process;

            AddToLoadingqueue(process);

            Reservation reservation = (Reservation)obj;
            ActionResult actionResult = await ReservationService.TaskDeleteMyReservation(reservation);
            if (actionResult != null && actionResult.IsSuccess)
            {
                GetMyOfficeReservations();
                SnackBar.Succesfull(actionResult.Message);
            }
            else
            {
                SnackBar.UnSuccesfull(actionResult.Message);
            }

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

        /*If the status of a certain day is Closed then the day is not reservable*/
        public void CheckDayIsReservable()
        {
            if (SelectedDay.Status == StatusAvailability.Closed)
            {
                SelectedDay = null;

            }
        }

        public static Boolean ReservationIsValid(Reservation reservation)
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
