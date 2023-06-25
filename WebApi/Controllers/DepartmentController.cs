using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("JoinDepartment")]
    public async Task<List<JoinDepartmentDto>> JoinDepartment()
    {
        return await _departmentService.JoinDepartment();
    }

    [HttpGet("JoinDepartmentById")]
    public async Task<JoinDepartmentDto> JoinDepartmentById(int id)
    {
        return await _departmentService.JoinDepartmentById(id);
    }
    
    [HttpGet("GetDepartment")]
    public async Task<List<GetDepartmentDto>> GetDepartment()
    {
        return await _departmentService.GetDepartment();
    }

    [HttpGet("GetDepartmentById")]
    public async Task<GetDepartmentDto> GetDepartmentById(int id)
    {
        return await _departmentService.GetDepartmentById(id);
    }

    [HttpPost("AddDepartment")]
    public async Task<AddDepartmentDto> AddDepartment(AddDepartmentDto department)
    {
        return await _departmentService.AddDepartment(department);
    }

    [HttpPut("UpdateDepartment")]
    public async Task<IActionResult> UpdateDepartment(AddDepartmentDto department)
    {
        var result = await _departmentService.UpdateDepartment(department);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("DeleteDepartment")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var result = await _departmentService.DeleteDepartment(id);
        return StatusCode((int)result.StatusCode, result);
    }
}