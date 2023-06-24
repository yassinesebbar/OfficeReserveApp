using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OfficeReserveApp.MVVM.Models
{
   public static class SnackBar
    {
        public static void CustomMessage(string message, Color BackgroundColor, string font, Color TextColor)
        {
            var snackbar = CommunityToolkit.Maui.Alerts.Snackbar.Make(message, null, "OK", TimeSpan.FromSeconds(5), new CommunityToolkit.Maui.Core.SnackbarOptions
            {
                BackgroundColor = BackgroundColor,
                Font = Microsoft.Maui.Font.OfSize(font, 17, FontWeight.Bold, Microsoft.Maui.FontSlant.Default, true),
                ActionButtonFont = Microsoft.Maui.Font.OfSize(font, 16, FontWeight.Medium, Microsoft.Maui.FontSlant.Default, true),
                ActionButtonTextColor = TextColor,
                TextColor = TextColor
            });

            snackbar.Show();
        }

        public static void UnSuccesfull(string message)
        {
            SnackBar.CustomMessage(message, Color.FromArgb("#f7c72b06"), "Regular", Colors.White);
        }

        public static void Succesfull(string message)
        {
            SnackBar.CustomMessage(message, Color.FromArgb("#fabcd433"), "Regular", Colors.White);
        }

        public static void Result(ActionResult actionResult)
        {
            if (actionResult != null)
            {
                if (actionResult.IsSuccess)
                {
                    SnackBar.Succesfull(actionResult.Message);
                }
                else
                {
                    SnackBar.UnSuccesfull(actionResult.Message);
                }
            }
            else
            {
                SnackBar.UnSuccesfull("Oei, er is iets mis gegaan!");
            }
         
        }

    }
}
