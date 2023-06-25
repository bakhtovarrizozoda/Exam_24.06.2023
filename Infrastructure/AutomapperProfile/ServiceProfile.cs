using AutoMapper;
using Domain.Entities;

namespace Infrastructure.AutomapperProfile;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Employee, GetEmployeeDto>().ReverseMap();
        CreateMap<AddEmployeeDto, Employee>().ReverseMap();
        CreateMap<Department, DepartmentBaseDto>().ReverseMap();

        CreateMap<Salary, GetSalaryDto>().ReverseMap();
        CreateMap<AddSalaryDto, Salary>().ReverseMap();

        CreateMap<Department, GetDepartmentDto>().ReverseMap();
        CreateMap<AddDepartmentDto, Department>().ReverseMap();

        CreateMap<DepartmentEmployee, GetDepartmentEmployeeDto>().ReverseMap();
        CreateMap<AddDepartmentEmployeeDto, DepartmentEmployee>().ReverseMap();

        CreateMap<DepartmentManager, GetDepartmentManagerDto>().ReverseMap();
        CreateMap<AddDepartmentManagerDto, DepartmentManager>().ReverseMap();
    }
}