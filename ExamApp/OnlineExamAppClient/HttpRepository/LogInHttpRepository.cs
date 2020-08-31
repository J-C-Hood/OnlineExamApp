using Blazored.LocalStorage;
using CommonProject.AdminDashBoardModel;
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
        private string serviceEndPoint4 = "https://localhost:44375/api/AdminDashBoard/";


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

        public async Task<IEnumerable<SimulateTestModel>> GetTasks(string emailId)
        {
            //_client.BaseAddress = new Uri("https://localhost:44375");
            //List<SimulateTestModel> taskList = new List<SimulateTestModel>();

            //// Setting content type.  
            //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //// Initialization.  
            //HttpResponseMessage response = new HttpResponseMessage();

            //// HTTP GET  
            //response = await _client.GetAsync("AdminDashBoard/" + emailId).ConfigureAwait(false);

            //// Verification  
            //if (response.IsSuccessStatusCode)
            //{
            //    // Reading Response.  
            //    string result = response.Content.ReadAsStringAsync().Result;
            //    taskList = JsonSerializer.Deserialize<IEnumerable<SimulateTestModel>>(result).ToList();
            //}

            //return taskList;
            // var requestMessage = new HttpRequestMessage(HttpMethod.Get, serviceEndPoint2);
            // requestMessage.SetBrowserRequestMode(BrowserRequestMode.Cors);
            serviceEndPoint4 = serviceEndPoint4  + emailId;
            return await _client.GetJsonAsync<List<SimulateTestModel>>(serviceEndPoint4);
        }   
        
        public async Task<string> GetLoggedInUser()
        {
             var res=  await _authenticationStateProvider.GetAuthenticationStateAsync();
            return res.User.Identity.Name;


        }
       
    }
}
