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

        private ReservationService ReservationService { get; set; }
        public DailyAvailability SelectedDay { get; set; }
        public Boolean SelectDayIsEnabled
        { get 
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

        public TimeSpan StartTimeSpan { get; set; }
        public TimeSpan EndTimeSpan { get; set; }

        public List<DailyAvailability> ConferenceDailyAvailabilities { get; set; }
        public List<Reservation> ConferenceReservations { get; set; }
        public List<Conference> FilteredConferences { get; set; }
        public List<Reservation> MyConferenceReservations { get; set; }
        public List<Conference> Conferences { get; set; }
        public List<Office> Offices { get; set; }
        public Conference SelectedConference { get; set; }
        public Office SelectedOffice { get; set; }

        public ICommand DeleteConferenceReservationCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }




        public Boolean SelectConferenceIsEnabled { get {
                return SelectedOffice != null && FilteredConferences.Count > 0;
            } }

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

        public void UpdateData()
        {
          
            GetMyConferenceReservations();
        }

        public void dummyData()
        {

            DailyAvailability DA1 = new DailyAvailability{ 
                Day = DateTime.Now,
                OfficeDailyAvailabilityID = 1,
                Status = StatusAvailability.Available
            };

            DailyAvailability DA2 = new DailyAvailability
            {
                Day = DateTime.Now.AddDays(1),
                OfficeDailyAvailabilityID = 2,
                Status = StatusAvailability.Available
            };

            ConferenceDailyAvailabilities.Add(DA1);
            ConferenceDailyAvailabilities.Add(DA2);
            ConferenceDailyAvailabilities.Add(DA2);
            ConferenceDailyAvailabilities.Add(DA2);
            ConferenceDailyAvailabilities.Add(DA2);
            ConferenceDailyAvailabilities.Add(DA2);
            ConferenceDailyAvailabilities.Add(DA2);
            ConferenceDailyAvailabilities.Add(DA2);
       



            Reservation R1 = new Reservation
            {
                Date = DateTime.Now.AddDays(1),
                ReservationHolder = "Zalm van hek",
                StartTime = DateTime.Now.AddDays(1),
                EndTime = DateTime.Now.AddDays(1),
                ConferenceRoom = "Discovery Room",
                OfficeName = "Utrecht"
            };

            Reservation R2 = new Reservation
            {
                Date = DateTime.Now.AddDays(1),
                ReservationHolder = "Joep van den Ende",
                StartTime = DateTime.Now.AddDays(1),
                EndTime = DateTime.Now.AddDays(1),
                ConferenceRoom = "Meetup Room",
                OfficeName = "Breda"
            };

            ConferenceReservations.Add(R1);
            ConferenceReservations.Add(R2);
            ConferenceReservations.Add(R2);
            ConferenceReservations.Add(R2);
            ConferenceReservations.Add(R2);
            ConferenceReservations.Add(R2);
            ConferenceReservations.Add(R2);


            Office O1 = new Office
            {
                AmountWorkSpots = 5,
                Name = "Utrecht",
                OfficeID = 1
            };

            Office O2 = new Office
            {
                AmountWorkSpots = 5,
                Name = "Breda",
                OfficeID = 2
            };

            Conference C1 = new Conference
            {
                ConferenceID = 1,
                OfficeID = 1,
                Name = "Discovery Room",
                Seats = 12
            };

            Conference C2 = new Conference
            {
                ConferenceID = 2,
                OfficeID = 1,
                Name = "Disicion Room",
                Seats = 12
            };

            Conference C3 = new Conference
            {
                ConferenceID = 3,
                OfficeID = 2,
                Name = "Meetup Room",
                Seats = 12
            };

            Conference C4 = new Conference
            {
                ConferenceID = 4,
                OfficeID = 2,
                Name = "Standup Room",
                Seats = 12
            };

            Conference C5 = new Conference
            {
                ConferenceID = 5,
                OfficeID = 2,
                Name = "Project Radar Room",
                Seats = 12
            };


            Offices.Add(O1);
            Offices.Add(O2);

            Conferences.Add(C1);
            Conferences.Add(C2);
            Conferences.Add(C3);
            Conferences.Add(C4);
            Conferences.Add(C5);

        }

        public async void CreateConferenceReservation()
        {
            string process = Constants.CreateOffieceReservation_Process;

            AddToLoadingqueue(process);

            Reservation NewReservation = new Reservation {
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
                MyConferenceReservations = await ReservationService.TaskCreateConferenceReservation(NewReservation);
            }

            RemoveFromLoadingqueue(process);
        }

        public Boolean ReadyToCreateReservationCheck()
        {
            return SelectConferenceIsEnabled && this.SelectedDay != null && StartTimeSpan.Ticks > 0 && EndTimeSpan.Ticks > 0;
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
            MyConferenceReservations = await ReservationService.TaskDeleteMyConferenceReservation(reservation);

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
                ExportConferenceDate ConferenceDate = new ExportConferenceDate
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
