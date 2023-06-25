namespace Domain.Entities;

public class JoinEmployeeDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<DepartmentBaseDto> DepartmentsName { get; set; }
}