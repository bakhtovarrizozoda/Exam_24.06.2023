namespace Domain.Entities;

public class GetDepartmentEmployeeDto : DepartmentEmployeeBaseDto
{
    public string DepartmentName { get; set; }
    public string EmployeeName { get; set; }
}