using AutoMapper;
using EmployeeAPI.Contracts.Dto;
using EmployeeAPI.Domain.Models;

namespace EmployeeAPI.Mappings
{
    public class EmployeeMappings
    {
        public class EmployeeProfile : Profile
        {
            public EmployeeProfile()
            {
                CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position));
            }
        }
    }
}
