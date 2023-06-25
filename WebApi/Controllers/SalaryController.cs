using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class SalaryController : ControllerBase
{
    private readonly SalaryService _salaryService;

    public SalaryController(SalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    [HttpGet("GetSalary")]
    public async Task<List<GetSalaryDto>> GetSalary()
    {
        return await _salaryService.GetSalary();
    }

    [HttpGet("GetSalaryById")]
    public async Task<GetSalaryDto> GetSalaryById(int id)
    {
        return await _salaryService.GetSalaryById(id);
    }

    [HttpPost("AddSalary")]
    public async Task<AddSalaryDto> AddSalary(AddSalaryDto salary)
    {
        return await _salaryService.AddSalary(salary);
    }

    [HttpPut("UpdateSalary")]
    public async Task<IActionResult> UpdateSalary(AddSalaryDto salary)
    {
        var resulr = await _salaryService.UpdateSalary(salary);
        return StatusCode((int)resulr.StatusCode, resulr);
    }

    [HttpDelete("DeleteSalary")]
    public async Task<IActionResult> DeleteSalary(int id)
    {
        var result = await _salaryService.DeleteSalary(id);
        return StatusCode((int)result.StatusCode, result);
    }
}