using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class DepartmentEmployee
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    [Required]
    public DateTime Fromdate { get; set; }
    [Required]
    public DateTime Todate { get; set; }
    public Department Department { get; set; }
    public Employee Employee { get; set; }
}