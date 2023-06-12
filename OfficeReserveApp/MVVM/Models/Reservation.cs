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
        public string ReservationHolder { get; set; }
        public DateTime EndTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime Date { get; set; }
        public int ReservationID { get; set; }
        public string date
        {
            set
            {
                Date = DateTime.Parse(value);
            }
            get
            {
                return Date.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string startTime
        {
            set
            {
                StartTime = DateTime.Parse(value);
            }
        }
        public string endTime
        {
            set
            {
                EndTime = DateTime.Parse(value);
            }
        }
        public string OfficeName { get; set; }
        public string ConferenceRoom { get; set; }
        public int ConferenceID { get; set; }
        public string timeFromTo
        {
            get
            {
                return StartTime.ToString("HH:mm") + " - " + EndTime.ToString("HH:mm");
            }
        }
    }
}
