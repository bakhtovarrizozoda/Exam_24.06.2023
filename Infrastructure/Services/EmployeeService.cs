using System.Net;
using AutoMapper;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<JoinEmployeeDto>> JoinEmployee()
    {
        var result = await (
            from e in _context.Employees
            select new JoinEmployeeDto()
            {
                Id = e.Id,
                FullName = e.FirstName + " " + e.LastName,
                DepartmentsName =
                    _mapper.Map<List<DepartmentBaseDto>>(e.DepartmentManagers.Select(x => x.Department).ToList())

            }).ToListAsync();
        return result;
    }
    
    public async Task<JoinEmployeeDto> JoinEmployeeById(int id)
    {
        var result = await (
            from e in _context.Employees
            where e.Id == id
            select new JoinEmployeeDto()
            {
                Id = e.Id,
                FullName = e.FirstName + " " + e.LastName,
                DepartmentsName =
                    _mapper.Map<List<DepartmentBaseDto>>(e.DepartmentManagers.Select(x => x.Department).ToList())

            }).FirstOrDefaultAsync();
        return result;
    }
    
    public async Task<List<GetEmployeeDto>> GetEmployee()
    {
        var employee = await _context.Employees.ToListAsync();
        return  _mapper.Map <List<GetEmployeeDto>>(employee);
    }

    public async Task<GetEmployeeDto> GetEmployeeById(int id)
    {
        var employe = await _context.Employees.FindAsync(id);
        return _mapper.Map<GetEmployeeDto>(employe);
    }

    public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto employee)
    {
        var employe = _mapper.Map<Employee>(employee);
        await _context.Employees.AddAsync(employe);
        await _context.SaveChangesAsync();
        employee.Id = employe.Id;
        return employee;
    }

    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto employee)
    {
        try
        {
            var find = await _context.Employees.FindAsync(employee.Id);
            _mapper.Map(employee, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AddEmployeeDto>(find);
            return new Response<AddEmployeeDto>(result);
        }
        catch (Exception e)
        {
            return new Response<AddEmployeeDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
        }
    }
    public async Task<Response<bool>> DeleteEmployee(int id)
    {
        try
        {
            var find = await _context.Employees.FindAsync(id);
            _context.Remove(find);
            var result = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}