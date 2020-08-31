using CommonProject.Common;
using OnlineExamApp.Model.AdminDashBoardModel;
using OnlineExamApp.Model.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamAppClient.HttpRepository
{
     public interface ILogInHttpRepository
    {
        Task<LoginResult> Login(AuthenticateModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<AddTestModel> Addtest(AddTestModel testmodel);
    }
}
