namespace Domain.Entities;

public class DepartmentManagerBaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Fromdate { get; set; }
    public DateTime Todate { get; set; }
    public int DepartmentId { get; set; }
    public int EmployeeId { get; set; }
}