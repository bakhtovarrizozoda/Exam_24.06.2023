using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities;

public class DepartmentManager
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    public DateTime Fromdate { get; set; }
    [Required]
    public DateTime Todate { get; set; }
    public int DepartmentId { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public Department Department { get; set; }
}