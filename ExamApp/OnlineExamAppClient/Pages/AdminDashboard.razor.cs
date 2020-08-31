using CommonProject.AdminDashBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamAppClient.Pages
{
    public partial class AdminDashboard
    {
        private List<SimulateTestModel> Tests = new List<SimulateTestModel>();

        void Edit(SimulateTestModel item) => Console.WriteLine($"Edit item: {item.TestId}");
        void Remove(SimulateTestModel item) => Console.WriteLine($"Remove item: {item.TestId}");
        void Add(SimulateTestModel item) => Console.WriteLine($"Edit item: {item.TestId}");
        void Assign(SimulateTestModel item) => Console.WriteLine($"Remove item: {item.TestId}");

        void AddNewTest(EventArgs args)
        {
            IsAddNewTest = true;
        }

        void CloseNewTest(bool args)
        {
            IsAddNewTest = false;
        }

        public AdminDashboard()
        {
            //SimulateTestModel model = new SimulateTestModel();
            //model.TestName = "Test 1";
            //model.Duration = 1;
            //model.Percentage = 50;
            //model.SerialNumber = 1;
            //Tests.Add(model);
        }
    }
}
