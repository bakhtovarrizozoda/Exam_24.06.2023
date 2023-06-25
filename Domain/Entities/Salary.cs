using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Salary
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int Amout { get; set; }
    [Required]
    public DateTime Fromdate { get; set; }
    [Required]
    public DateTime Todate { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}