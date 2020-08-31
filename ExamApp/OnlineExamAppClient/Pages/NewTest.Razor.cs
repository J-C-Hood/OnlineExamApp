using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonProject.AdminDashBoardModel;
using OnlineExamApp.Model.AdminDashBoardModel;

namespace OnlineExamAppClient.Pages
{
    public partial class NewTest
    {

        void CloseNewTest(EventArgs args)
        {
           OnCloseTest.InvokeAsync(true);
        }
    }
}
