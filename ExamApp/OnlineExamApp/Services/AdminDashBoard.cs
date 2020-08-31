using OnlineExamApp.Model;
using OnlineExamApp.Model.AdminDashBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Services
{
    public class AdminDashBoard : IAdminDashBoard
    {
        private examlibrarydbContext _context;

        public AdminDashBoard(examlibrarydbContext context)
        {
            _context = context;
        }

        public Questions AddQuestion(Questions qn, Choicetable op)
        {
            _context.Questions.Add(qn);
            _context.SaveChanges();
            op.QuestionId = qn.QuestionId;
            _context.Choicetable.Add(op);
            _context.SaveChanges();
            return qn;
        }

        public int AssignToStudent(AssigntoStudentModel model)
        {
            Assignedtesttable obj = new Assignedtesttable();
            obj.TestId = model.TaskId;
            obj.EmailId = model.StudentId;
            _context.Assignedtesttable.Add(obj);
            _context.SaveChanges();
            return obj.AssignedTestId;
        }

        public Simtest Create(Simtest test)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Simtest> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Simtest user)
        {
            throw new NotImplementedException();
        }
    }
}
