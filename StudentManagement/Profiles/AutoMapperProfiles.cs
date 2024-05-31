﻿using AutoMapper;
using StudentManagement.DomainModels;
using StudentManagement.Profiles.AfterMap;
using DataModels= StudentManagement.DataModels;

namespace StudentManagement.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>().ReverseMap();
            CreateMap<DataModels.Gender, Gender>().ReverseMap();
            CreateMap<DataModels.Address, Address>().ReverseMap();
            CreateMap<UpdateStudentRequest,DataModels.Student>().AfterMap<UpdateStudentRequestAfterMap>();
        }
    }
}
