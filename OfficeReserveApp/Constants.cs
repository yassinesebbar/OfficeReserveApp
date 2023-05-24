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
        public static string UserEndpoint = "";
        public static string ReservationEndpoint = "";
        public static string OfficeEndpoint = "";

        // Pages
        public static string LoginPage = "//LoginPage";
        public static string OfficeManagerOverview = "//OfficeManagementOverviewPage";
        public static string WorkSpotOverview = "//WorkSpotOverviewPage";


    }
}
