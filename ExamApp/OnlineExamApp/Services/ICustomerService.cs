using OnlineExamApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Services
{
    public interface ICustomerService
    {
        Customeraccount Authenticate(string username, string password);
        IEnumerable<Customeraccount> GetAll();
        Customeraccount GetById(int id);
        Customeraccount GetByEmailId(string emailid);
        Customeraccount Create(Customeraccount user, string password);
        void Update(Customeraccount user, string password = null);
        void Delete(int id);
    }
}
