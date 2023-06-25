using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class DepartmentEmployeeController : ControllerBase
{
    private readonly DepartmentEmployeeService _service;

    public DepartmentEmployeeController(DepartmentEmployeeService service)
    {
        _service = service;
    }

    [HttpGet("GetDepartmentEmployee")]
    public async Task<List<GetDepartmentEmployeeDto>> GetDepartmentEmployee()
    {
        return await _service.GetDepartmentEmployee();
    }

    [HttpGet("GetDepartmentEmployeeById")]
    public async Task<GetDepartmentEmployeeDto> GetDepartmentEmployeeById(int id)
    {
        return await _service.GetDepartmentEmployeeById(id);
    }

    [HttpPost("AddDepartmentEmployee")]
    public async Task<AddDepartmentEmployeeDto> AddDepartmentEmployee(AddDepartmentEmployeeDto departmentEmployee)
    {
        return await _service.AddDepartmentEmployee(departmentEmployee);
    }

    [HttpPost("UpdateDepartmentEmployee")]
    public async Task<IActionResult> UpdateDepartmentEmployee(
        AddDepartmentEmployeeDto departmentEmployee)
    {
        var result = await _service.UpdateDepartmentEmployee(departmentEmployee);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("DeleteDepartmentEmployee")]
    public async Task<IActionResult> DeleteDepartmentEmployee(int id)
    {
        var result = await _service.DeleteDepartmentEmployee(id);
        return StatusCode((int)result.StatusCode, result);
    }
}