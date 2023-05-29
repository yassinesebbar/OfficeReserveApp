using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp
{
    public static class Constants
    {
        // API

        public static string BaseURL = "https://officereservesystem-sandbox.mxapps.io";

        public static string AuthenticationEndpoint = BaseURL + "/rest/user/service/login";
        public static string GetMyOfficeReservationsEndpoint = BaseURL +  "/rest/reservation/v1/service/myworkspotreservations";
        public static string GetMyOfficeDailyAvailabilityEndpoint = BaseURL + "/rest/reservation/v1/service/getoccupation";
        public static string OfficeEndpoint = "";

 


    }
}
