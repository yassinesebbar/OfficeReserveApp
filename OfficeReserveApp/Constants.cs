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
        public static string GetOffices = BaseURL + "/rest/reservation/v1/service/getoffices";
        public static string GetConferences = BaseURL + "/rest/reservation/v1/service/getconferences";
        public static string GetAvailabilityDays = BaseURL + "/rest/reservation/v1/service/getavailabilitydays";
        public static string GetMyConferenceReservations = BaseURL + "/rest/reservation/v1/service/getmyconferencereservations";
        public static string GetConferenceReservations = BaseURL + "/rest/reservation/v1/service/getconferencereservations";
        public static string DeleteMyConferenceReservations = BaseURL + "/rest/reservation/v1/service/deleteconferencereservation";
        public static string CreateConferenceReservation = BaseURL + "/rest/reservation/v1/service/createconferencereservation";

        // Processes

        public static string CreateOffieceReservation_Process = "CreateOffieceReservationProcess";
        public static string DeleteOfficeReservation_Process = "DeleteOfficeReservationProcess";
        public static string GetMyOfficeReservations_Process = "GetMyOfficeReservationsProcess";
        public static string GetDailyAvailability_Process = "GetDailyAvailabilityProcess";
        public static string UpdateOffice_Process = "UpdateOfficeProcess";
        public static string GetOffices_Process = "GetOfficesProcess";
        public static string GetConferences_Process = "GetConferencesProcess";
        public static string GetAvailabilityDays_Process = "GetAvailabilityDaysProcess";
        public static string GetConferenceReservations_Process = "GetConferenceReservationsProcess";
        public static string DeleteMyConferenceReservations_Process = "DeleteMyConferenceReservationsProcess";
        public static string CreateMyConferenceReservation_Process = "CreateMyConferenceReservationProcess";
    }
}
