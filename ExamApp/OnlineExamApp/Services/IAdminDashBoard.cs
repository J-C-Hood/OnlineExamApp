using OnlineExamApp.Model;
using OnlineExamApp.Model.AdminDashBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Services
{
    public interface IAdminDashBoard
    {
        IEnumerable<Simtest> GetAll();
        Simtest Create(Simtest test);
        void Update(Simtest user);
        Questions AddQuestion(Questions qn, Choicetable op);
        int AssignToStudent(AssigntoStudentModel model);

        void Delete(int id);
    }
}
