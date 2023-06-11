using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.Models
{

    [AddINotifyPropertyChangedInterface]

    public class Office
    {
        public string Name { get; set; }
        public int KantoorID { get; set; }
        public int AmountWorkSpots { get; set; }
    }
}
