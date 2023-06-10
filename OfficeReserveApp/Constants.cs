using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp
{
    public static class Constants
    {
        // API Endpoints

        public static string BaseURL = "https://officereservesystem-sandbox.mxapps.io";

        public static string AuthenticationEndpoint = BaseURL + "/rest/user/service/login";
        public static string GetMyOfficeReservationsEndpoint = BaseURL +  "/rest/reservation/v1/service/myworkspotreservations";
        public static string DeleteReservationEndpoint = BaseURL + "/rest/reservation/v1/service/deleteofficereservation";
        public static string CreateReservationEndpoint = BaseURL + "/rest/reservation/v1/service/createofficereservation";
        public static string GetMyOfficeDailyAvailabilityEndpoint = BaseURL + "/rest/reservation/v1/service/getoccupation";
        public static string OfficeEndpoint = "";

        // Processes

        public static string CreateOffieceReservation_Process = "CreateOffieceReservationProcess";
        public static string DeleteOfficeReservation_Process = "DeleteOfficeReservationProcess";
        public static string GetMyOfficeReservations_Process = "GetMyOfficeReservationsProcess";
        public static string GetDailyAvailability_Process = "GetDailyAvailabilityProcess";
    }
}
