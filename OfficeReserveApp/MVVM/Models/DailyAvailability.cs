using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.Models
{

    public enum StatusAvailability
    {
        Available = 0,
        Busy = 1,
        Closed = 2
    };

    public class DailyAvailability
    {
        public int OfficeDailyAvailabilityID { get; set; }
        public StatusAvailability Status { get; set; }
        public DateTime Day { get; set; }
    }
}
