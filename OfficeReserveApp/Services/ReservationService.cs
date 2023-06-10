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

    class ReservationService : BaseService
    {

        private ByteArrayContent ReservationToContentHeader(Reservation reservation)
        {
            var myContent = JsonSerializer.Serialize(reservation);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
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

        public async Task<List<Reservation>> TaskDeleteReservation(Reservation reservation)
        {
            List<Reservation> OfficeReservations = new List<Reservation>();
    
            var byteContent =  ReservationToContentHeader(reservation);

            var response =
               await Client.PostAsync(Constants.DeleteReservationEndpoint, byteContent);

            if (response.IsSuccessStatusCode)
            {
                if (response.IsSuccessStatusCode)
                {
                    OfficeReservations = await DeserializeReservations(response.Content);
                }
            }

            return OfficeReservations;
        }

        public async Task<List<Reservation>> TaskDCreateReservation(Reservation reservation)
        {
            List<Reservation> OfficeReservations = new List<Reservation>();
          
            var byteContent =  ReservationToContentHeader(reservation);

            var endpointCreate = Constants.CreateReservationEndpoint;
            var endpointDelete = Constants.DeleteReservationEndpoint;
            var response =
               await Client.PostAsync(Constants.CreateReservationEndpoint, byteContent);

            if (response.IsSuccessStatusCode)
            {
                if (response.IsSuccessStatusCode)
                {
                    OfficeReservations = await DeserializeReservations(response.Content);
                }
            }

            return OfficeReservations;
        }



    }
}
