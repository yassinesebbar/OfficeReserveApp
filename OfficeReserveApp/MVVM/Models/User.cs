using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.Models
{

   public enum Rol
    {
        Medewerker = 0,
        Officemanager = 1,
    };

    public class User
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public Rol Rol { get; set; }
    }


}
