using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("JoinEmployee")]
    public async Task<List<JoinEmployeeDto>> JoinEmployee()
    {
        return await _employeeService.JoinEmployee();
    }

    [HttpGet("JoinEmployeeById")]
    public async Task<JoinEmployeeDto> JoinEmployeeById(int id)
    {
        return await _employeeService.JoinEmployeeById(id);
    }
    
    [HttpGet("GetEmployee")]
    public async Task<List<GetEmployeeDto>> GetEmployee()
    {
        return await _employeeService.GetEmployee();
    }

    [HttpGet("GetEmployeeById")]
    public async Task<GetEmployeeDto> GetEmployeeById(int id)
    {
        return await _employeeService.GetEmployeeById(id);
    }

    [HttpPost("AddEmployee")]
    public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto employee)
    {
        return await _employeeService.AddEmployee(employee);
    }

    [HttpPut("UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(AddEmployeeDto employee)
    {
        var result = await _employeeService.UpdateEmployee(employee);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var result = await _employeeService.DeleteEmployee(id);
        return StatusCode((int)result.StatusCode, result);
    }
    
}