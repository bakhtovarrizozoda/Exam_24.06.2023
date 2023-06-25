using System.Net;
using AutoMapper;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DepartmentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<JoinDepartmentDto>> JoinDepartment()
    {
        var result = await (
            from d in _context.Departments
            join dm in _context.DepartmentManagers on d.Id equals dm.DepartmentId
                into departmentdefaultgroup
            from ddg in departmentdefaultgroup.DefaultIfEmpty()
            select new JoinDepartmentDto()
            {
                Id = d.Id,
                Name = d.Name,
                FullName = $"{ddg.FirstName} {ddg.LastName}"
            }).ToListAsync();
        return result;
    }
    
    public async Task<JoinDepartmentDto> JoinDepartmentById(int id)
    {
        var result = await (
            from d in _context.Departments
            join dm in _context.DepartmentManagers on d.Id equals dm.DepartmentId
                into departmentdefaultgroup
            from ddg in departmentdefaultgroup.DefaultIfEmpty()
            where d.Id == id
            select new JoinDepartmentDto()
            {
                Id = d.Id,
                Name = d.Name,
                FullName = $"{ddg.FirstName} {ddg.LastName}"
            }).FirstOrDefaultAsync();
        return result;
    }

    public async Task<List<GetDepartmentDto>> GetDepartment()
    {
        var department = await _context.Departments.ToListAsync();
        return _mapper.Map<List<GetDepartmentDto>>(department);
    }
    
    public async Task<GetDepartmentDto> GetDepartmentById(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        return _mapper.Map<GetDepartmentDto>(department);
    }

    public async Task<AddDepartmentDto> AddDepartment(AddDepartmentDto department)
    {
        var result = _mapper.Map<Department>(department);
        await _context.Departments.AddAsync(result);
        await _context.SaveChangesAsync();
        department.Id = result.Id;
        return department;
    }

    public async Task<Response<AddDepartmentDto>> UpdateDepartment(AddDepartmentDto department)
    {
        try
        {
            var find = await _context.Departments.FindAsync(department.Id);
            _mapper.Map(department, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AddDepartmentDto>(find);
            return new Response<AddDepartmentDto>(result);

        }
        catch (Exception e)
        {
            return new Response<AddDepartmentDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
        }
        
    }

    public async Task<Response<bool>> DeleteDepartment(int id)
    {
        try
        {
            var find = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(find);
            var result = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        
    }
}