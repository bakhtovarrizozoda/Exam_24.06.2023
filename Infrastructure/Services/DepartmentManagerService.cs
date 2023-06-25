using System.Net;
using AutoMapper;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DepartmentManagerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DepartmentManagerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<JoinDepartmentManagerDto>> JoinDepartmentManager()
    {
        var result = await (
            from dm in _context.DepartmentManagers
            join d in _context.Departments on dm.DepartmentId equals d.Id
                into departmentdefaultgroup
            from ddg in departmentdefaultgroup.DefaultIfEmpty()
            select new JoinDepartmentManagerDto()
            {
                FullName = dm.FirstName + " " + dm.LastName,
                FromDate = dm.Fromdate,
                Todate = dm.Todate,
                DepartmentId = ddg.Id,
                DepartmentName = ddg.Name
            }).ToListAsync();
        return result;
    }
    
    public async Task<JoinDepartmentManagerDto> JoinDepartmentManagerById(int id)
    {
        var result = await (
            from dm in _context.DepartmentManagers
            join d in _context.Departments on dm.DepartmentId equals d.Id
                into departmentdefaultgroup
            from ddg in departmentdefaultgroup.DefaultIfEmpty()
            where dm.Id == id
            select new JoinDepartmentManagerDto()
            {
                FullName = dm.FirstName + " " + dm.LastName,
                FromDate = dm.Fromdate,
                Todate = dm.Todate,
                DepartmentId = ddg.Id,
                DepartmentName = ddg.Name
            }).FirstOrDefaultAsync();
        return result;
    }
    
    
    public async Task<List<GetDepartmentManagerDto>> GetDepartmentManager()
    {
        var result = await _context.DepartmentManagers.ToListAsync();
        return _mapper.Map<List<GetDepartmentManagerDto>>(result);
    }
    
    public async Task<GetDepartmentManagerDto> GetDepartmentManagerById(int id)
    {
        var result = await _context.DepartmentManagers.FindAsync(id);
        return _mapper.Map<GetDepartmentManagerDto>(result);
    }
    public async Task<GetDepartmentDto> GetDepartmentById(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        return _mapper.Map<GetDepartmentDto>(department);
    }
    
    public async Task<AddDepartmentManagerDto> AddDepartmentManager(AddDepartmentManagerDto departmentManager)
    {
        var result = _mapper.Map<DepartmentManager>(departmentManager);
        await _context.DepartmentManagers.AddAsync(result);
        await _context.SaveChangesAsync();
        departmentManager.Id = result.Id;
        return departmentManager;
    }

    public async Task<Response<AddDepartmentManagerDto>> UpdateDepartmentManager(AddDepartmentManagerDto departmentManager)
    {
        try
        {
            var fund = await _context.DepartmentManagers.FindAsync(departmentManager.Id);
            _mapper.Map(departmentManager, fund);
            _context.Entry(fund).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AddDepartmentManagerDto>(fund);
            return new Response<AddDepartmentManagerDto>(result);
        }
        catch (Exception e)
        {
            return new Response<AddDepartmentManagerDto>(HttpStatusCode.InternalServerError,
                new List<string>() { e.Message });
        }
    }

    public async Task<Response<bool>> DeleteDepartmentManager(int id)
    {
        try
        {
            var find = await _context.DepartmentManagers.FindAsync(id);
            _context.DepartmentManagers.Remove(find);
            var result = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}