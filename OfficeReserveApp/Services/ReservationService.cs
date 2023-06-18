using OfficeReserveApp.DTOModels;
using OfficeReserveApp.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeReserveApp.Services
{

    [AddINotifyPropertyChangedInterface]

   public class ReservationService
    {

        private HttpClient Client { get;  set; } = App.client;

        private ByteArrayContent ObjectToContentHeader(object obj)
        {
            var myContent = JsonSerializer.Serialize(obj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        private async Task<ActionResult> DeserializeActionResult(HttpContent ActionResultContent)
        {
            ActionResult ActionResult = new ActionResult();


            using (var responseStream = await ActionResultContent.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<ActionResult>(responseStream);
                ActionResult = data;
            }

            return ActionResult;
        }

        private async Task<List<Reservation>> DeserializeReservations(HttpContent reservationsContent)
        {
            List<Reservation> Reservations = new List<Reservation>();


            using (var responseStream = await reservationsContent.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<List<Reservation>>(responseStream);
                Reservations = data;
            }

            return Reservations;
        }

       public async Task<List<Reservation>> TaskGetMyOfficeReservations()
        {
            List<Reservation> OfficeReservations = new List<Reservation>();
            var response = 
                await Client.GetAsync(Constants.GetMyOfficeReservationsEndpoint);

            if (response.IsSuccessStatusCode)
            {
                OfficeReservations = await DeserializeReservations(response.Content);
            }

            return OfficeReservations;
        }

        
       public async Task<List<Reservation>> TaskGetMyConferenceReservations()
        {
            List<Reservation> ConferenceReservations = new List<Reservation>();
            var response = 
                await Client.GetAsync(Constants.GetMyConferenceReservations);

            if (response.IsSuccessStatusCode)
            {
                ConferenceReservations = await DeserializeReservations(response.Content);
            }

            return ConferenceReservations;
        }
         
       public async Task<List<Reservation>> TaskGetConferenceReservations(ExportConferenceDate ConferenceDate)
        {
            List<Reservation> ConferenceReservations = new List<Reservation>();
            var byteContent = ObjectToContentHeader(ConferenceDate);

            var response = 
                await Client.PostAsync(Constants.GetConferenceReservations, byteContent);

            if (response.IsSuccessStatusCode)
            {
                ConferenceReservations = await DeserializeReservations(response.Content);
            }

            return ConferenceReservations;
        }



        public async Task<List<Reservation>> TaskGetOfficeReservations(DailyAvailability dailyAvailability)
        {
            List<Reservation> OfficeReservations = new List<Reservation>();

            var byteContent = ObjectToContentHeader(dailyAvailability);

            var response =
                await Client.PostAsync(Constants.GetOfficeReservationsEndpoint, byteContent);

            if (response.IsSuccessStatusCode)
            {
                OfficeReservations = await DeserializeReservations(response.Content);
            }

            return OfficeReservations;
        }
        
        public async Task<Office> TaskGetMyOfficeInfo()
        {
            Office Office = new Office();


            var response =
                await Client.GetAsync(Constants.GetMyOfficeInformation);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    Office = await JsonSerializer.DeserializeAsync<Office>(responseStream);
                }
            }

            return Office;
        }

        public async Task<ActionResult> TaskUpdateOffice(Office office)
        {
            ActionResult actionResult = new ActionResult();
            var byteContent = ObjectToContentHeader(office);

            var response =
                await Client.PostAsync(Constants.UpdateOffice, byteContent);

            if (response.IsSuccessStatusCode)
            {
                actionResult = await DeserializeActionResult(response.Content);
            };

            return actionResult;
        }
        
        public async Task<List<Office>> TaskGetOffices()
        {
            List<Office> Offices = new List<Office>();

            var response =
                await Client.GetAsync(Constants.GetOffices);


            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<Office>>(responseStream);
                    Offices = data;
                }
            };

            return Offices;
        }
               
        public async Task<List<Conference>> TaskGetConferences()
        {
            List<Conference> Conferences = new List<Conference>();

            var response =
                await Client.GetAsync(Constants.GetConferences);


            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<Conference>>(responseStream);
                    Conferences = data;
                }
            }

            return Conferences;
        }


        public async Task<List<DailyAvailability>> TaskGetMyOfficeDailyAvailability()
        {
            List<DailyAvailability> DailyAvailability = new List<DailyAvailability>();
            var response =
                await Client.GetAsync(Constants.GetMyOfficeDailyAvailabilityEndpoint);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<DailyAvailability>>(responseStream);
                    DailyAvailability = data;
                }
            }

            return DailyAvailability;
        }

        public async Task<List<DailyAvailability>> TaskGetOfficeDailyAvailability()
        {
            List<DailyAvailability> DailyAvailability = new List<DailyAvailability>();
            var response =
                await Client.GetAsync(Constants.GetOfficeDailyAvailabilityEndpoint);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<DailyAvailability>>(responseStream);
                    DailyAvailability = data;
                }
            }

            return DailyAvailability;
        }

        public async Task<List<DailyAvailability>> TaskGetConferenceDailyAvailability()
        {
            List<DailyAvailability> DailyAvailability = new List<DailyAvailability>();
            var response =
                await Client.GetAsync(Constants.GetAvailabilityDays);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<DailyAvailability>>(responseStream);
                    DailyAvailability = data;
                }
            }

            return DailyAvailability;
        }


        public async Task<ActionResult> TaskDeleteMyReservation(Reservation reservation)
        {
            ActionResult actionResult = new ActionResult();
    
            var byteContent = ObjectToContentHeader(reservation);


            var response =
               await Client.PostAsync(Constants.DeleteMyOfficeReservationEndpoint, byteContent);

            if (response.IsSuccessStatusCode)
            {
               actionResult = await DeserializeActionResult(response.Content);
            }

            return actionResult;
        }
        

        public async Task<ActionResult> TaskDeleteMyConferenceReservation(Reservation reservation)
        {
            ActionResult actionResult = new ActionResult();

            var byteContent = ObjectToContentHeader(reservation);

            var response =
               await Client.PostAsync(Constants.DeleteMyConferenceReservations, byteContent);

            if (response.IsSuccessStatusCode)
            {
                actionResult = await DeserializeActionResult(response.Content);
            }

            return actionResult;
        }


        public async Task<ActionResult> TaskDeleteReservation(Reservation reservation)
        {
            ActionResult actionResult = new ActionResult();


            var byteContent = ObjectToContentHeader(reservation);


            var response =
                await Client.PostAsync(Constants.DeleteReservationEndpoint, byteContent);
            if (response.IsSuccessStatusCode)
            {
                actionResult = await DeserializeActionResult(response.Content);
            }

            return actionResult;
        }

        public async Task<ActionResult> TaskCreateReservation(Reservation reservation)
        {
            ActionResult actionResult = new ActionResult();

            var byteContent = ObjectToContentHeader(reservation);

            var response =
               await Client.PostAsync(Constants.CreateReservationEndpoint, byteContent);

            if (response.IsSuccessStatusCode)
            {
                actionResult = await DeserializeActionResult(response.Content);
            }

            return actionResult;
        }
        
        public async Task<ActionResult> TaskCreateConferenceReservation(Reservation reservation)
        {
            ActionResult actionResult = new ActionResult();
          
            var byteContent = ObjectToContentHeader(reservation);

     
            var response =
               await Client.PostAsync(Constants.CreateConferenceReservation, byteContent);

            if (response.IsSuccessStatusCode)
            {
                actionResult = await DeserializeActionResult(response.Content);   
            }

            return actionResult;
        }



    }
}
