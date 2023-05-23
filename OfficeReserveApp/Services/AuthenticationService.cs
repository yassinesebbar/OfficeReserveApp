using OfficeReserveApp.ImportModels;
using OfficeReserveApp.MVVM;
using OfficeReserveApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeReserveApp.Services
{
    public class AuthenticationService : BaseService 
    { 
    

        public User User { get; private set; }

        public async Task Login(LoginRequestModel loginRequest)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", GetAuthString(loginRequest));            
            var response = await Client.PostAsync(Constants.AuthenticationEndpoint, null);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<ImportUser>(responseStream);

                    User = new User{
                        name = data.name,
                        lastName = data.lastname,
                        Rol = (Rol) data.rol
                    };
                }
            } 
        }


        public Boolean UserIsAuthenticated()
        {
            return User != null && Client.DefaultRequestHeaders.Authorization != null;
        }



        public void Logout()
        {
            User = null;
            Client.DefaultRequestHeaders.Authorization = null;
        }

        private string GetAuthString(LoginRequestModel loginRequest)
        {
            return Convert.ToBase64String(
                System.Text.UTF8Encoding.UTF8.GetBytes(
                $"{loginRequest.UserName}:{loginRequest.Password}"));
        }
    }
}
