using OfficeReserveApp.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeReserveApp.Services
{

    [AddINotifyPropertyChangedInterface]

    class ReservationService : BaseService
    {

       public async Task<List<Reservation>> TaskGetMyOfficeReservations()
        {
            List<Reservation> OfficeReservations = new List<Reservation>();
            var response = 
                await Client.GetAsync(Constants.GetMyOfficeReservationsEndpoint);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<Reservation>>(responseStream);
                    OfficeReservations = data;
                }
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


        
    }
}
