namespace Domain.Entities;

public class GetDepartmentManagerDto : DepartmentManagerBaseDto
{
    public string EmployeeName { get; set; }
    public string DepartmentName { get; set; }
}