using AutoMapper;
using OnlineExamApp.Model;
using OnlineExamApp.Model.AdminDashBoardModel;
using OnlineExamApp.Model.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customeraccount, CustomerModel>();
            CreateMap<RegisterModel, Customeraccount>();
            CreateMap<CustomerUpdateModel, Customeraccount>();
            CreateMap<AddQuestionModel, Questions>();
            CreateMap<AddOptionsModel, Choicetable>();
            CreateMap<AddTestModel, Simtest>();
        }
    }
}
