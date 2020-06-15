using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_managment.Data;
using test_managment.Models;

namespace test_managment.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<TestType, TestTypeVM>().ReverseMap();
            CreateMap<TestAllocation, TestAllocationVM>().ReverseMap();
            CreateMap<TestAllocation, EditTestAllocationVM>().ReverseMap();
            CreateMap<TestRequest, TestRequestVM>().ReverseMap();
            CreateMap<Patient, PatientVM>().ReverseMap();
        }
    }
}
