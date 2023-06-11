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
        public static string GetOfficeReservationsEndpoint = BaseURL + "/rest/reservation/v1/service/getofficereservations";
        public static string DeleteMyReservationEndpoint = BaseURL + "/rest/reservation/v1/service/deletemyofficereservation";
        public static string DeleteReservationEndpoint = BaseURL + "/rest/reservation/v1/service/deleteofficereservation";
        public static string CreateReservationEndpoint = BaseURL + "/rest/reservation/v1/service/createofficereservation";
        public static string GetMyOfficeDailyAvailabilityEndpoint = BaseURL + "/rest/reservation/v1/service/getoccupationmedewerker";
        public static string GetOfficeDailyAvailabilityEndpoint = BaseURL + "/rest/reservation/v1/service/getoccupationofficemanager";
        public static string GetMyOfficeInformation = BaseURL + "/rest/reservation/v1/service/getofficeinformation";
        public static string UpdateOffice = BaseURL + "/rest/reservation/v1/service/updateoffice";

        // Processes

        public static string CreateOffieceReservation_Process = "CreateOffieceReservationProcess";
        public static string DeleteOfficeReservation_Process = "DeleteOfficeReservationProcess";
        public static string GetMyOfficeReservations_Process = "GetMyOfficeReservationsProcess";
        public static string GetDailyAvailability_Process = "GetDailyAvailabilityProcess";
        public static string UpdateOffice_Process = "UpdateOfficeProcess";
    }
}
