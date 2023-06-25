using System.Net;
using AutoMapper;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentEmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DepartmentEmployeeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetDepartmentEmployeeDto>> GetDepartmentEmployee()
    {
        var result = await _context.DepartmentEmployees.ToListAsync();
        return _mapper.Map<List<GetDepartmentEmployeeDto>>(result);
    }
    
    public async Task<GetDepartmentEmployeeDto> GetDepartmentEmployeeById(int id)
    {
        var result = await _context.DepartmentEmployees.FindAsync(id);
        return _mapper.Map<GetDepartmentEmployeeDto>(result);
    }

    public async Task<AddDepartmentEmployeeDto> AddDepartmentEmployee(AddDepartmentEmployeeDto departmentEmployee)
    {
        var result = _mapper.Map<DepartmentEmployee>(departmentEmployee);
        await _context.DepartmentEmployees.AddAsync(result);
        await _context.SaveChangesAsync();
        departmentEmployee.Id = result.Id;
        return departmentEmployee;
    }

    public async Task<Response<AddDepartmentEmployeeDto>> UpdateDepartmentEmployee(AddDepartmentEmployeeDto departmentEmployee)
    {
        try
        {
            var fund = await _context.DepartmentEmployees.FindAsync(departmentEmployee.Id);
            _mapper.Map(departmentEmployee, fund);
            _context.Entry(fund).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AddDepartmentEmployeeDto>(fund);
            return new Response<AddDepartmentEmployeeDto>(result);
        }
        catch (Exception e)
        {
            return new Response<AddDepartmentEmployeeDto>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
    }

    public async Task<Response<bool>> DeleteDepartmentEmployee(int id)
    {
        try
        {
            var find = await _context.DepartmentEmployees.FindAsync(id);
            _context.DepartmentEmployees.Remove(find);
            var result = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}