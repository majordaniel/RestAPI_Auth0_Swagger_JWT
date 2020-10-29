using AutoMapper;
using RestAPIwithAuth0.Data.DTO.RequestsDTO;
using RestAPIwithAuth0.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIwithAuth0.Data.Configs
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, EmployeeRequestModel>().ReverseMap();

        }


    }
}
