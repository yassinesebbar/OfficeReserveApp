using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]

    public class LoginRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
