using AutoMapper;
using JobJournal.Shared;
using JobJournal.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobJournal.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();

            CreateMap<CompanyContact, CompanyContactDTO>()
                .ForMember(m => m.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));

            CreateMap<CompanyContactDTO, CompanyContact>()
                .ForMember(m => m.Company, opt => opt.Ignore());

            CreateMap<ApplicationMethod, ApplicationMethodDTO>().ReverseMap();

            CreateMap<ApplicationStatus, ApplicationStatusDTO>().ReverseMap();

            CreateMap<JobApplication, JobApplicationDTO>()
                .ForMember(m => m.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
                .ForMember(m => m.ApplicationStatus, opt => opt.MapFrom(src => src.ApplicationStatus.Status))
                .ForMember(m => m.ApplicationMethod, opt => opt.MapFrom(src => src.ApplicationMethod.Method));

            CreateMap<JobApplicationDTO, JobApplication>()
                .ForMember(m => m.ApplicationStatus, opt => opt.Ignore())
                .ForMember(m => m.ApplicationMethod, opt => opt.Ignore());

        }
    }
}
