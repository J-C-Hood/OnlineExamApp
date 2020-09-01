using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonProject.AdminDashBoardModel;
using Microsoft.AspNetCore.Components;
using OnlineExamApp.Model.AdminDashBoardModel;

namespace OnlineExamAppClient.Pages
{
    public partial class NewTest
    {
        [Parameter]
        public string CurrentUserName { get; set; }
        void CloseNewTest(EventArgs args)
        {
            OnCloseTest.InvokeAsync(true);
        }

        
        public NewTest()
        {
            //TestModel.EmailId = UserName;
        }
    }

       
}
