using OfficeReserveApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.Converters
{
    internal class StatusAvailabilityToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StatusAvailability status = (StatusAvailability)value;
            switch(status)
            {
                case StatusAvailability.Available:
                    return Color.FromArgb("#8c13910f");
                case StatusAvailability.Busy:
                    return Color.FromArgb("#Bfde8e04");
                case StatusAvailability.Closed:
                    return Color.FromArgb("#Bf910f0f");
                default: return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
