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

    public class ConferenceReservationViewModel : BaseViewModel
    {

        public DailyAvailability SelectedDay { get; set; }

        public List<DailyAvailability> ConferenceDailyAvailabilities { get; set; }
        public List<Reservation> ConferenceReservations { get; set; }
        public List<Conference> FilteredConferences { get; set; }
        public List<Reservation> MyConferenceReservations { get; set; }
        public List<Conference> Conferences { get; set; }
        public List<Office> Offices { get; set; }
        public Conference SelectedConference { get; set; }
        public Office SelectedOffice { get; set; }
        public Boolean CanActivateBarcode = true;

        public ICommand DeleteConferenceReservationCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public Boolean SelectConferenceIsEnabled { get {
                return SelectedOffice != null && FilteredConferences.Count > 0;
            } }

        public Boolean SelectDayIsEnabled
        {
            get
            {
                return SelectedOffice != null && SelectedConference != null;
            }
        }

        public Boolean ReadyToCreateReservation
        {
            get
            {
                return ReadyToCreateReservationCheck();
            }
        }

        public ConferenceReservationViewModel(Image loadingImg) :base(loadingImg)
        {
            ConferenceDailyAvailabilities = new List<DailyAvailability>();
            ConferenceReservations = new List<Reservation>();
            MyConferenceReservations = new List<Reservation>();
            FilteredConferences = new List<Conference>();
            Conferences = new List<Conference>();
            Offices = new List<Office>();
            ReservationService = new ReservationService();
            DeleteConferenceReservationCommand = new Command((object obj) => { DeleteConferenceReservations(obj); });
            CreateReservationCommand = new Command(CreateConferenceReservation);
            UpdateViewCommand = new Command(UpdateData);
        }

        public void UpdateData() { GetMyConferenceReservations();}

        public Conference GetConferenceById(int conferenceId)
        {
            return Conferences.Find(c => c.ConferenceID == conferenceId);
        }

        public async void CreateConferenceReservation()
        {
            string process = Constants.CreateOffieceReservation_Process;

            AddToLoadingqueue(process);

            Reservation NewReservation = new()
            {
                StartTime = new DateTime(SelectedDay.Day.Ticks + StartTimeSpan.Ticks),
                EndTime = new DateTime(SelectedDay.Day.Ticks + EndTimeSpan.Ticks),
                Date = SelectedDay.Day,
                ConferenceID = SelectedConference.ConferenceID,
                OfficeName = SelectedOffice.Name,
                ConferenceRoom = SelectedConference.Name,
                ReservationHolder = CurrentUser.Fullname
            };


            if (ReservationIsValid(NewReservation))
            {

                ActionResult actionResult = await ReservationService.TaskCreateConferenceReservation(NewReservation);
                if (actionResult != null && actionResult.IsSuccess)
                {
                    GetMyConferenceReservations();
                    SnackBar.Succesfull(actionResult.Message);
                }
                else
                {
                    SnackBar.UnSuccesfull(actionResult.Message);
                }

            }

            RemoveFromLoadingqueue(process);
        }

        public Boolean ReadyToCreateReservationCheck()
        {
            return SelectConferenceIsEnabled && this.SelectedDay != null && StartTimeSpan.Ticks > 0 && EndTimeSpan.Ticks > 0;
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

        public void SetConferenceByConferenceId(int conferenceId)
        {

            SelectedConference = null;
            SelectedOffice = null;
            SelectedDay = null;

            Conference foundConference = GetConferenceById(conferenceId);

            if (foundConference != null)
            {
                Office foundOffice = Offices.Find(f => f.OfficeID == foundConference.OfficeID);
                if (foundOffice != null)
                {
                    DailyAvailability foundAvailability = ConferenceDailyAvailabilities.OrderBy(o => o.Day).First();

                    if (foundAvailability != null)
                    {
                        SelectedOffice = foundOffice;
                        FilteredConferences = Conferences.FindAll(C => C.OfficeID == SelectedOffice.OfficeID);
                        SelectedConference = foundConference;
                        SelectedDay = foundAvailability;

                        GetReservationsByConferenceAndDate();
                    }
                }
            }

        }

        public async void GetMyConferenceReservations()
        {
            string process = Constants.GetConferenceReservations_Process;

            AddToLoadingqueue(process);

            MyConferenceReservations = await ReservationService.TaskGetMyConferenceReservations();

            RemoveFromLoadingqueue(process);
        }

        public async void DeleteConferenceReservations(object obj)
        {

            string process = Constants.DeleteMyConferenceReservations_Process;

            AddToLoadingqueue(process);

            Reservation reservation = (Reservation)obj;
            ActionResult actionResult = await ReservationService.TaskDeleteMyConferenceReservation(reservation);

            if (actionResult != null && actionResult.IsSuccess)
            {
                GetMyConferenceReservations();
                SnackBar.Succesfull(actionResult.Message);
            }
            else
            {
                SnackBar.UnSuccesfull(actionResult.Message);
            }

            RemoveFromLoadingqueue(process);
        }

        public async void GetOffices()
        {
            string process = Constants.GetOffices_Process;

            AddToLoadingqueue(process);

            Offices = await ReservationService.TaskGetOffices();

            RemoveFromLoadingqueue(process);

        }

        public async void GetConferences()
        {
            string process = Constants.GetConferences_Process;

            AddToLoadingqueue(process);

            Conferences = await ReservationService.TaskGetConferences();

            RemoveFromLoadingqueue(process);
        }

        public async void GetReservationsByConferenceAndDate()
        {
            string process = Constants.GetConferenceReservations_Process;

            AddToLoadingqueue(process);

            if (SelectedDay != null && SelectedConference != null)
            {
                ExportConferenceDate ConferenceDate = new()
                {
                    ConferenceID = SelectedConference.ConferenceID,
                    Date = SelectedDay.Day
                };

                ConferenceReservations = await ReservationService.TaskGetConferenceReservations(ConferenceDate);
            }

            RemoveFromLoadingqueue(process);        
        }


        public async void GetDailyAvailability()
        {
            string process = Constants.GetAvailabilityDays_Process;

            AddToLoadingqueue(process);

            ConferenceDailyAvailabilities = await ReservationService.TaskGetConferenceDailyAvailability();

            RemoveFromLoadingqueue(process);
        }


        public void FilterConferences()
        {
            if (SelectedOffice != null && Conferences != null && Conferences.Count > 0 )
            {
                FilteredConferences = Conferences.FindAll(C => C.OfficeID == SelectedOffice.OfficeID);

            }
        }


        
    }
}
