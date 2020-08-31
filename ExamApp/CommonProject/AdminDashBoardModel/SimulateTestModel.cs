using System;
using System.Collections.Generic;
using System.Text;

namespace CommonProject.AdminDashBoardModel
{
    public class SimulateTestModel
    {
        public int SerialNumber { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; }
        public float? Duration { get; set; }
        public float? Percentage { get; set; }
    }
}
