using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.Models
{
    public class Conference
    {
        public int ConferenceID { get; set; }
        public int OfficeID { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
    }
}
