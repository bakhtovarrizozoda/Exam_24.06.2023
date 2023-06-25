using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentManagerController : ControllerBase
{
    private readonly DepartmentManagerService _service;

    public DepartmentManagerController(DepartmentManagerService service)
    {
        _service = service;
    }


    [HttpGet("JoinDepartmentManager")]
    public async Task<List<JoinDepartmentManagerDto>> JoinDepartmentManager()
    {
        return await _service.JoinDepartmentManager();
    }

    [HttpGet("JoinDepartmentManagerById")]
    public async Task<JoinDepartmentManagerDto> JoinDepartmentManagerById(int id)
    {
        return await _service.JoinDepartmentManagerById(id);
    }

    [HttpGet("GetDepartmentManager")]
    public async Task<List<GetDepartmentManagerDto>> GetDepartmentManager()
    {
        return await _service.GetDepartmentManager();
    }

    [HttpGet("GetDepartmentManagerById")]
    public async Task<GetDepartmentManagerDto> GetDepartmentManagerById(int id)
    {
        return await _service.GetDepartmentManagerById(id);
    }

    [HttpPost("AddDepartmentManager")]
    public async Task<AddDepartmentManagerDto> AddDepartmentManager(AddDepartmentManagerDto departmentManager)
    {
        return await _service.AddDepartmentManager(departmentManager);
    }

    [HttpPut("UpdateDepartmentManager")]
    public async Task<IActionResult> UpdateDepartmentManager(
        AddDepartmentManagerDto departmentManager)
    {
        var result = await _service.UpdateDepartmentManager(departmentManager);
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpDelete("DeleteDepartmentManager")]
    public async Task<IActionResult> DeleteDepartmentManager(int id)
    {
        var result = await _service.DeleteDepartmentManager(id);
        return StatusCode((int)result.StatusCode, result);
    }
}