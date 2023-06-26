using OfficeReserveApp.MVVM.ViewModels;
using OfficeReserveApp.Converters;
using OfficeReserveApp.MVVM.Models;

namespace UnitTestOfficeReserveApp
{
    public class UnitTest3
    {
        ConferenceReservationViewModel ConferenceReservationViewModel = new ConferenceReservationViewModel(null);

        [Fact]
        public void CheckReservationValidationGoodInput()
        {
            Reservation reservation = new() { 
            Date = DateTime.Now.AddDays(2),
            StartTime = DateTime.Now.AddMinutes(1),
            EndTime = DateTime.Now.AddDays(1)
            };

            Assert.True(ConferenceReservationViewModel.ReservationIsValid(reservation));
            
        }

        [Fact]
        public void CheckReservationValidationBadInput()
        {
            Reservation reservation = new()
            {
                Date = DateTime.Now.AddDays(-2),
                StartTime = DateTime.Now.AddDays(1),
                EndTime = DateTime.Now
            };

            Assert.False(ConferenceReservationViewModel.ReservationIsValid(reservation));
        }


    }
}