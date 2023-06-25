using System.Net;
using AutoMapper;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class SalaryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SalaryService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetSalaryDto>> GetSalary()
    {
        var result = await _context.Salaries.ToListAsync();
        return _mapper.Map<List<GetSalaryDto>>(result);
    }

    public async Task<GetSalaryDto> GetSalaryById(int id)
    {
        var result = await _context.Salaries.FindAsync(id);
        return _mapper.Map<GetSalaryDto>(result);
    }

    public async Task<AddSalaryDto> AddSalary(AddSalaryDto salary)
    {
        var result = _mapper.Map<Salary>(salary);
        await _context.Salaries.AddAsync(result);
        await _context.SaveChangesAsync();
        salary.Id = result.Id;
        return salary;
    }

    public async Task<Response<AddSalaryDto>> UpdateSalary(AddSalaryDto salary)
    {
        try
        {
            var find = await _context.Salaries.FindAsync(salary.Id);
            _mapper.Map(salary, find);
            _context.Entry(find).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AddSalaryDto>(find);
            return new Response<AddSalaryDto>(result);
        }
        catch (Exception e)
        {
            return new Response<AddSalaryDto>(HttpStatusCode.InternalServerError, new List<string>() { e.Message });
        }
    }

    public async Task<Response<bool>> DeleteSalary(int id)
    {
        try
        {
            var find = await _context.Salaries.FindAsync(id);
            _context.Salaries.Remove(find);
            var result = await _context.SaveChangesAsync();
            return new Response<bool>(result == 1);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}