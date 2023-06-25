namespace Domain.Entities;

public class JoinDepartmentManagerDto
{
    public string FullName { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime Todate { get; set; }
}