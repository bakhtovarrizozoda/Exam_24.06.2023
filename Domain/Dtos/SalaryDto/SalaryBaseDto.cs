namespace Domain.Entities;

public class SalaryBaseDto
{
    public int Id { get; set; }
    public int Amout { get; set; }
    public DateTime Fromdate { get; set; }
    public DateTime Todate { get; set; }
    public int EmployeeId { get; set; }
}