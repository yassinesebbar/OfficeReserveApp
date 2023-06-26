using OfficeReserveApp.MVVM.ViewModels;
using OfficeReserveApp.Converters;
using OfficeReserveApp.MVVM.Models;

namespace UnitTestOfficeReserveApp
{
    public class UnitTest1
    {
        StatusAvailabilityToColor ColorConverter = new StatusAvailabilityToColor();

        [Fact]
        public void CheckStatusAvailableToColor()
        {

            object value = 0;
            Color color = (Color)ColorConverter.Convert(value, null,null,null);

            Assert.Equal(color, Color.FromArgb("#8c13910f"));

        }

        [Fact]
        public void CheckStatusBusyToColor()
        {

            object value = 1;
            Color color = (Color)ColorConverter.Convert(value, null, null, null);

            Assert.Equal(color, Color.FromArgb("#Bfde8e04"));

        }

        [Fact]
        public void CheckStatusClosedToColor()
        {

            object value = 2;
            Color color = (Color)ColorConverter.Convert(value, null, null, null);

            Assert.Equal(color, Color.FromArgb("#Bf910f0f"));

        }
    }
}