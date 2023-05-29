using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.Models
{

    [AddINotifyPropertyChangedInterface]
    public class Reservation
    {

        private DateTime endTime { get; set; }

        public DateTime startTime { get; set; }

        public DateTime date { get; set; }

        public string Date
        {
            set
            {
                date = DateTime.Parse(value);
            }
        }
        public string StartTime
        {
            set
            {
                startTime = DateTime.Parse(value);
            }
        }
        public string EndTime
        {
            set
            {
                endTime = DateTime.Parse(value);
            }
        }
        public string OfficeName { get; set; }
        public string ConferenceRoom { get; set; }
        public string timeFromTo
        {
            get
            {
                return startTime.ToString("HH:mm") + " - " + endTime.ToString("HH:mm");
            }
        }
    }
}
