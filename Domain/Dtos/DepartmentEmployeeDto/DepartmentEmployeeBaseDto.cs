namespace Domain.Entities;

public class DepartmentEmployeeBaseDto
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Fromdate { get; set; }
    public DateTime Todate { get; set; }
}