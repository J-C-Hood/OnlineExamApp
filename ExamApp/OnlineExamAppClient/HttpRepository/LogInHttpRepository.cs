using Blazored.LocalStorage;
using CommonProject.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using OnlineExamApp.Model.AdminDashBoardModel;
using OnlineExamApp.Model.CustomerModel;
using OnlineExamAppClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineExamAppClient.HttpRepository
{
    public class LogInHttpRepository : ILogInHttpRepository
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        private readonly HttpClient _client;
        private string serviceEndPoint = "https://localhost:44375/Customeraccounts/authenticate";
        private string serviceEndPoint2 = "https://localhost:44375/Customeraccounts/register";
        private string serviceEndPoint3 = "https://localhost:44375/api/admindashboard/addtest";


        public LogInHttpRepository(HttpClient client, AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _client = client;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResult> Login(AuthenticateModel loginModel)
        {
            var loginAsJson = JsonSerializer.Serialize(loginModel);

            var response = await _client.PostAsync(serviceEndPoint, new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.EmailId);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {           
            var result = await _client.PostJsonAsync<RegisterResult>(serviceEndPoint2, registerModel);

            return result;
        }

        public async Task<AddTestModel> Addtest(AddTestModel testmodel)
        {
            var result = await _client.PostJsonAsync<AddTestModel>(serviceEndPoint3, testmodel);

            return result;
        }

    }
}
