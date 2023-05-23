using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OfficeReserveApp.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]


    public class LoginPageViewModel : BaseViewModel
    {
        public LoginRequestModel LoginRequest { get; set; } = new LoginRequestModel();

        public ICommand LoginCommand => new Command(() => { Login(LoginRequest); });

    }
}
